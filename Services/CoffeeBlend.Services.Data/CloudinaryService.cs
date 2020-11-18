namespace CoffeeBlend.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            await using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);

            var destinationImage = memoryStream.ToArray();

            UploadResult uploadResult = null;

            await using var destinationStream = new MemoryStream(destinationImage);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, destinationStream),
            };

            uploadResult = await this.cloudinary.UploadAsync(uploadParams);

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
