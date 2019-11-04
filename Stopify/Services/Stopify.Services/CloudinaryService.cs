using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Stopify.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadPictureAsync(IFormFile pictureFile , string fileName)
        {
            byte[] destinationData;

            using (var ms = new MemoryStream())
            {
                await pictureFile.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;


            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams imageUploadParams = new ImageUploadParams
                {
                    Folder = "product_images",
                    File = new FileDescription(fileName, ms)
                };

                uploadResult = this.cloudinary.Upload(imageUploadParams);

            }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
