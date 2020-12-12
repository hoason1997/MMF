using MFF.DTO.Constants;
using MFF.DTO.Helpers;
using MFF.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Utility
{
    public class FileService : IFileService
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        [Obsolete]
        public FileService(IHostingEnvironment hostingEnvironment
            , IHttpContextAccessor httpContextAccessor)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        [Obsolete]
        public async Task<FileResponseModel> Upload(IFormFile file)
        {
            var rawPath = Path.Combine(hostingEnvironment.ContentRootPath, Constant.FILE_PATH);
            if (!Directory.Exists(rawPath))
                Directory.CreateDirectory(rawPath);

            var newFileName = $"{DateTime.Now.ToString("yyyyMMdd")}_{CommonHelper.NewGuid()}{Path.GetExtension(file.FileName).ToLower()}";
            var filePath = Path.Combine(rawPath, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);

            var url = $"{Constant.FILE_PATH}/{newFileName}";
            var response = new FileResponseModel
            {
                Url = url,
                FullUrl = ToFullUrl($"/{url}")
            };

            return response;
        }

        [Obsolete]
        public async Task<FileResponseModel> SaveHasThumbnail(string folderName, IFormFile file)
        {

            var resourceUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/{ Constant.FILE_PATH}/{folderName}";

            var rawPath = Path.Combine(Constant.FILE_PATH, folderName);
            if (!Directory.Exists(rawPath))
                Directory.CreateDirectory(rawPath);

            var newFileName = $"{DateTime.Now.ToString(Constant.FileTime)}{Path.GetExtension(file.FileName).ToLower()}";
            var filePath = Path.Combine(rawPath, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);

            
            var thumbnailFileName = $"t{newFileName}"; ;
            var thumbnailPath = Path.Combine(rawPath, thumbnailFileName);

            var ms = new MemoryStream();
            file.CopyTo(ms);
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(fileStream);
                fileStream.Close();
                {
                    string ImageType = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower().Trim();
                    Image image = Image.FromStream(ms);
                    Image thumb = image.GetThumbnailImage(600, 450, () => false, IntPtr.Zero);
                    thumb.Save(Path.ChangeExtension(thumbnailPath, ImageType));
                }
                ms.Close();
            }

            var response = new FileResponseModel
            {
                Url = filePath,
                FullUrl = $"{resourceUrl}/{newFileName}",
                ThumbnailUrl = thumbnailPath,
                ThumbnailFullUrl = $"{resourceUrl}/{thumbnailFileName}"
            };
            return response;
        }

        [Obsolete]
        public async Task<FileResponseModel> SavePostContent(string folderName, IFormFile file)
        {
            var resourceUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/{ Constant.FILE_PATH}/{folderName}";

            var rawPath = Path.Combine(hostingEnvironment.ContentRootPath, Constant.FILE_PATH + "/" + folderName);
            if (!Directory.Exists(rawPath))
                Directory.CreateDirectory(rawPath);


            var newFileName = $"{DateTime.Now.ToString("yyyyMMdd")}_{CommonHelper.NewGuid()}{Path.GetExtension(file.FileName).ToLower()}";
            var filePath = Path.Combine(rawPath, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);

            var url = $"{Constant.FILE_PATH}/{folderName}/{newFileName}";

            var response = new FileResponseModel
            {
                Url = url,
                FullUrl = $"{resourceUrl}/{newFileName}",
            };
            return response;
        }

        [Obsolete]
        public async Task<bool> Delete(string fileName)
        {
            var rawPath = Path.Combine(hostingEnvironment.ContentRootPath, Constant.FILE_PATH);
            if (!Directory.Exists(rawPath)) return false;

            var path = Path.Combine(rawPath, fileName);

            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }
        [Obsolete]
        public async Task<bool> DeleteFolder(string folderName)
        {
            var rawPath = Path.Combine(hostingEnvironment.ContentRootPath, Constant.FILE_PATH);

            if (!Directory.Exists(rawPath)) return false;

            var path = Path.Combine(rawPath, folderName);

            try
            {
                Directory.Delete(path, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public string ToFullUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            return $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{url}";
        }
    }
}
