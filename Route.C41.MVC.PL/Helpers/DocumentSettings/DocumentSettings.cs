using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Route.C41.MVC.PL.Helpers.DocumentSettings
{
    public static class DocumentSettings
    {
        public static async Task<string> Upload(IFormFile file , string folderName)
        {
            //1 Genereate folderPath to include it with the file name
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //2 Generate the file name , to appeand it with the folderPath later

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";


            //3 , combine the two to generate the file full path :)
            string filePath = Path.Combine(folderPath, fileName);

            // 4 create the stream
        
           using var fileStream = new FileStream(filePath, FileMode.CreateNew);
            await file.CopyToAsync(fileStream);
            return fileName;
        }

        public static void Delete(string folderName , string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","files",folderName,fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
