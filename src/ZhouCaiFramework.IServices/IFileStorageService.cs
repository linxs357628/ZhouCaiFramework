using System;
using System.IO;
using System.Threading.Tasks;

namespace ZhouCaiFramework.IServices
{
    public interface IFileStorageService
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="fileName">原始文件名</param>
        /// <returns>存储后的文件路径</returns>
        Task<string> SaveFileAsync(Stream fileStream, string fileName);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteFileAsync(string filePath);

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件流</returns>
        Task<Stream> GetFileAsync(string filePath);

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否存在</returns>
        Task<bool> ExistsAsync(string filePath);

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件信息(大小、修改时间等)</returns>
        Task<FileInfo> GetFileInfoAsync(string filePath);

        /// <summary>
        /// 获取文件URL
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>可访问的URL</returns>
        Task<string> GetFileUrlAsync(string filePath);
    }
}
