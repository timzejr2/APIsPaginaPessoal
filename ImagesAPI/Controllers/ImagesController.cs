using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImagesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        string ErrorMessage;
        string imageResponse;

        private readonly string _connectionString;
        private readonly string _images;

        public ImagesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("BlobConnectionString");
            _images = configuration.GetValue<string>("BlobImages");
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            string photoName = $"{Guid.NewGuid()}";

            if (image == null) return BadRequest();

            var supportedTypes = new[] { "jpg", "jpeg", "img", "bitmap", "png" };
            var fileExt = System.IO.Path.GetExtension(image.FileName).Substring(1);
            Console.WriteLine(fileExt);
            if (!supportedTypes.Contains(fileExt))
            {
                ErrorMessage = "File Extension Is InValid - Only Upload jpg/jpeg/png/bitmap File";
                return BadRequest(ErrorMessage);
            }
            else
            {
                //string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, _fotosMaquetes);

                BlobContainerClient container = new(_connectionString, _images);

                BlobClient blob = container.GetBlobClient($"{photoName}-{image.FileName}");
                System.Console.WriteLine(image.FileName);
                using (var photo = new MemoryStream())
                {
                    await image.CopyToAsync(photo);
                    photo.Position = 0;
                    await blob.UploadAsync(photo);
                }

                imageResponse = photoName + "-" + image.FileName;

                return Ok(imageResponse);
            }
        }

        [HttpDelete("delete_photo")]
        public async Task<IActionResult> DeleteImage(string image)
        {
            BlobContainerClient container = new(_connectionString, _images);
            BlobClient blob = container.GetBlobClient(image);

            blob.DeleteIfExistsAsync();

            return Ok("Imagem excluida com sucesso!");
        }
    }
}
