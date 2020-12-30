using MFF.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Utility
{
    public interface IFileService
    {
        Task<FileResponseModel> Upload(IFormFile file);
        Task<FileResponseModel> SaveHasThumbnail(string postId, IFormFile file);
        Task<FileResponseModel> SavePostContent(string folderName, IFormFile file);
        Task<bool> Delete(string fileName);
        Task<bool> DeleteFolder(string folderName);
        string ToFullUrl(string url);
    }
}
