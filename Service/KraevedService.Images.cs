using KraevedAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace KraevedAPI.Service
{
    public partial class KraevedService : IKraevedService
    {
        /// <summary>
        /// Загрузка изображения на сервер
        /// </summary>
        /// <param name="imageFiles">Коллекция файлов с изображениями</param>
        /// <returns></returns>
        public async Task<List<string>> UploadImages(IEnumerable<IFormFile> imageFiles)
        {
            var result = new List<string>();

            IEnumerable<IFormFile> filteredImageFiles = imageFiles.Where(item => item.Length > 0) ?? [];

            if (!filteredImageFiles.Any()) {
                throw new Exception(ServiceConstants.Exception.FileIsEmpty);
            }

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 20
            };

            await Parallel.ForEachAsync(imageFiles, options, async (imageFile, token) => 
            {
                if (imageFile.Length == 0) {
                    throw new Exception(ServiceConstants.Exception.FileIsEmpty);
                }
                
                var rootFolder = Directory.GetCurrentDirectory();

                var path = Path.Combine(rootFolder, "images");

                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }

                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };
                if (!allowedExtension.Contains(ext)) {
                    throw new Exception(ServiceConstants.Exception.WrongExtension);
                }

                var uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileNameWithPath = Path.Combine(path, newFileName);

                var fileStream = new FileStream(fileNameWithPath, FileMode.Create);
                await imageFile.CopyToAsync(fileStream, token);
                result.Add(newFileName);
            });

            return result;
        }
    }
}
