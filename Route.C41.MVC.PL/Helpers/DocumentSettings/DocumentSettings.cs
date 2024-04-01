using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Route.C41.MVC.PL.Helpers.DocumentSettings
{
    public static class DocumentSettings
    {
        public static string Upload(IFormFile file , string folderName)
        {
            //1 Genereate folderPath to include it with the file name
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folderName);

            //2 Generate the file name , to appeand it with the folderPath later

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";


            //3 , combine the two to generate the file full path :)
            string filePath = Path.Combine(folderPath, fileName);

            // 4 create the stream

           using var fileStream = new FileStream(filePath, FileMode.CreateNew);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static void Delete(string folderName , string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Files",folderName,fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
