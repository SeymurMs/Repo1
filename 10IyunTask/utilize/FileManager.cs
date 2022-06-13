using Microsoft.AspNetCore.Http;
using System.IO;

namespace _10IyunTask.utilize
{
    public static class FileManager
    {
        public static string SaveImg(this IFormFile file , string root , string path, string fileName)
        {
            string rootPath = Path.Combine(root, path);
            string fullPath= Path.Combine(rootPath, fileName);
            using (FileStream fs = new FileStream(fullPath ,FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return fileName;
        }

        public static void DeleteFile(string root , string path, string fileName)
        {
            string rootPath = Path.Combine(root, path);
            string fullPath = Path.Combine(rootPath, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}
