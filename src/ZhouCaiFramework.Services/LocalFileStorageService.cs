using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ZhouCaiFramework.Common.Exceptions;
using ZhouCaiFramework.IServices;

namespace ZhouCaiFramework.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly ILogger<LocalFileStorageService> _logger;
        private readonly string _storagePath;

        public LocalFileStorageService(ILogger<LocalFileStorageService> logger)
        {
            _logger = logger;
            _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(_storagePath);
        }

        public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                if (fileStream == null || fileStream.Length == 0)
                    throw new ArgumentException("文件流不能为空");

                if (string.IsNullOrWhiteSpace(fileName))
                    throw new ArgumentException("文件名不能为空");

                var extension = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(extension))
                    throw new ArgumentException("文件必须包含扩展名");

                var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(_storagePath, uniqueFileName);

                // 确保目录存在
                Directory.CreateDirectory(_storagePath);

                // 使用FileShare.None防止并发写入
                using var output = new FileStream(
                    filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);

                await fileStream.CopyToAsync(output);
                fileStream.Close();

                // 验证文件确实已保存
                if (!File.Exists(filePath))
                    throw new IOException("文件保存验证失败");

                return filePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "保存文件失败");
                throw new FileStorageException("文件保存失败", ex);
            }
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("文件路径不能为空");

                if (!File.Exists(filePath))
                    return false;

                // 检查文件是否被占用
                bool isFileLocked = true;
                int retryCount = 0;
                const int maxRetry = 3;

                while (isFileLocked && retryCount < maxRetry)
                {
                    try
                    {
                        using (File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            isFileLocked = false;
                        }
                    }
                    catch (IOException)
                    {
                        retryCount++;
                        if (retryCount >= maxRetry)
                            throw new FileStorageException($"文件被占用，无法删除: {filePath}");

                        await Task.Delay(500 * retryCount);
                    }
                }

                File.Delete(filePath);

                // 验证文件确实已删除
                await Task.Delay(100);
                if (File.Exists(filePath))
                    throw new FileStorageException($"文件删除验证失败: {filePath}");

                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "删除文件权限不足");
                throw new FileStorageException("没有删除文件的权限", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除文件失败");
                throw new FileStorageException("文件删除失败", ex);
            }
        }

        public Task<bool> ExistsAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    return Task.FromResult(false);

                return Task.FromResult(File.Exists(filePath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "检查文件存在状态失败");
                throw new FileStorageException("检查文件存在状态失败", ex);
            }
        }

        public Task<FileInfo> GetFileInfoAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("文件路径不能为空");

                var fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists)
                    throw new FileNotFoundException("文件不存在", filePath);

                return Task.FromResult(fileInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取文件信息失败");
                throw new FileStorageException("获取文件信息失败", ex);
            }
        }

        public Task<string> GetFileUrlAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("文件路径不能为空");

                if (!File.Exists(filePath))
                    throw new FileNotFoundException("文件不存在", filePath);

                // 本地存储返回文件物理路径
                // 实际项目中可配置基础URL转换为HTTP访问路径
                return Task.FromResult(filePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取文件URL失败");
                throw new FileStorageException("获取文件URL失败", ex);
            }
        }

        public Task<Stream> GetFileAsync(string filePath)
        {
            try
            {
                return Task.FromResult<Stream>(File.OpenRead(filePath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "读取文件失败");
                throw;
            }
        }
    }
}