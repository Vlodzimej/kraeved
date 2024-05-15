using KraevedAPI.Constants;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<String>?> UploadImage(IFormFile imageFile) {
            string newFileName;
            
            try {
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
                newFileName = uniqueString + ext;
                var fileNameWithPath = Path.Combine(path, newFileName);

                var fileStream = new FileStream(fileNameWithPath, FileMode.Create);
                await imageFile.CopyToAsync(fileStream);
            }

            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }

            return Ok(new { newFileName });
        }
    }
}