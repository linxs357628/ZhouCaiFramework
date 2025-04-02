using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhouCaiFramework.Common
{
    public static class StreamExtensions
    {
        public static int CopyTo(Stream stream, Stream targetStream)
        {
            return CopyTo(stream, targetStream, 4096);
        }

        public static int CopyTo(Stream stream, Stream targetStream, int bufferSize)
        {
            if (!stream.CanRead)
            {
                throw new InvalidOperationException("This Stream Is Not CanRead!");
            }

            if (!targetStream.CanWrite)
            {
                throw new InvalidOperationException("This targetStream Is Not CanWrite!");
            }

            if (bufferSize <= 0)
            {
                throw new InvalidOperationException("bufferSize must more than 0");
            }

            byte[] buffer = new byte[bufferSize];
            long offset = 0L;
            long offset2 = 0L;
            if (stream.CanSeek)
            {
                offset = stream.Position;
            }

            if (targetStream.CanSeek)
            {
                offset2 = targetStream.Position;
            }

            int num = 0;
            int num2;
            while ((num2 = stream.Read(buffer, 0, bufferSize)) > 0)
            {
                targetStream.Write(buffer, 0, num2);
                num += num2;
            }

            if (targetStream.CanSeek)
            {
                targetStream.Seek(offset2, SeekOrigin.Begin);
            }

            if (stream.CanSeek)
            {
                stream.Seek(offset, SeekOrigin.Begin);
            }

            return num;
        }

        public static MemoryStream CopyToMemory(this Stream stream)
        {
            MemoryStream memoryStream = null;
            memoryStream = ((!stream.CanSeek) ? new MemoryStream() : new MemoryStream((int)stream.Length));
            CopyTo(stream, memoryStream);
            if (memoryStream.CanSeek)
            {
                memoryStream.Seek(0L, SeekOrigin.Begin);
            }

            return memoryStream;
        }

        public static bool SaveToFile(this Stream stream, string filePath, FileMode mode)
        {
            return stream.SaveToFile(filePath, mode, 1024);
        }

        public static bool SaveToFile(this Stream stream, string filePath, FileMode mode, int bufferSize)
        {
            if (stream == null)
            {
                return false;
            }

            if (bufferSize <= 0)
            {
                return false;
            }

            long offset = 0L;
            if (stream.CanSeek)
            {
                offset = stream.Position;
            }

            using (FileStream fileStream = new FileStream(filePath, mode))
            {
                byte[] array = new byte[bufferSize];
                int count;
                while ((count = stream.Read(array, 0, array.Length)) > 0)
                {
                    fileStream.Write(array, 0, count);
                }
            }

            if (stream.CanSeek)
            {
                stream.Seek(offset, SeekOrigin.Begin);
            }

            return true;
        }

        public static bool SaveToFile(this MemoryStream msStream, string filePath, FileMode mode)
        {
            if (msStream == null || msStream.Length <= 0)
            {
                return false;
            }

            long offset = 0L;
            if (msStream.CanSeek)
            {
                offset = msStream.Position;
            }

            using (Stream stream = new FileStream(filePath, mode))
            {
                stream.Write(msStream.ToArray(), 0, (int)msStream.Length);
            }

            if (msStream.CanSeek)
            {
                msStream.Seek(offset, SeekOrigin.Begin);
            }

            return true;
        }
    }
}