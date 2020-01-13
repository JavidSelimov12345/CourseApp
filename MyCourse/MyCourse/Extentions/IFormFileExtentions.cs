using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Extentions
{
    public static class IFormFileExtentions
    {
        public static bool isImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static bool lessThan(this IFormFile file,int mb)
        {
            return file.Length / 1024 / 1024 <mb;
        }

        public async  static  Task<string> Save(this IFormFile file,string root,string folder)
        {

            string path = Path.Combine(root, "images");
            string fileName = Path.Combine(folder, Guid.NewGuid().ToString() + file.FileName);

            string resultPath = Path.Combine(path, fileName);

            using (FileStream filestream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }

            return fileName;

        }

        public async static Task<string> SaveBackSlash(this IFormFile file, string root, string folder)
        {

            string path = Path.Combine(root, "images");
            string fileName = folder+"/" +Guid.NewGuid().ToString() + file.FileName;
            
            string resultPath = Path.Combine(path, fileName);

            using (FileStream filestream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }

            return fileName;

        }

    }
}
