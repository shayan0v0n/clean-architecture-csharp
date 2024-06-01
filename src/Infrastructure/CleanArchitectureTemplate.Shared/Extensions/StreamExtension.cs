using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Shared.Extensions
{
    public static class StreamExtension
    {
        public async static Task<string> ReadStreamInChunksAsync(this Stream stream)
        {
            const int readChunkBufferLength = 4096;

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = await reader.ReadBlockAsync(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                await textWriter.WriteAsync(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }
    }
}
