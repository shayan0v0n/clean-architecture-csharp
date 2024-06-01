using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Shared.Extensions
{
    public class FileExtension
    {
        public static string SaveFileToCDN(string CDN, string path, IFormFile file)
        {
            string directory = $"{CDN}\\{path}";
            string localPath = $"{path}\\{file.FileName}";
            string fullPath = $"{CDN}\\{localPath}";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            byte[] fileArray;
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fileArray = memoryStream.ToArray();
            }

            File.WriteAllBytes(fullPath, fileArray);
            return localPath;
        }

        public static string SaveFileToCDN(string CDN, string path, IFormFile file, string fileName = "")
        {
            _ = string.IsNullOrEmpty(fileName) ? fileName = file.FileName : fileName += Path.GetExtension(file.FileName);
           
            string directory = $"{CDN}\\{path}";
            string localPath = $"{path}\\{fileName}";
            string fullPath = $"{CDN}\\{localPath}";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            byte[] fileArray;
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fileArray = memoryStream.ToArray();
            }

            File.WriteAllBytes(fullPath, fileArray);
            return localPath.Replace('\\','/');
        }
    }
}
