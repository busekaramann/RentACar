using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        void DeleteOldFile(string directory);
        void CreateFile(string directory, IFormFile formFile);
        void CheckDirectoryExists(string directory);
        IResult CheckFileTypeValid(string type);
        IResult CheckFileExists(IFormFile formFile);
        IResult Upload (IFormFile formFile);
        IResult Update(IFormFile formFile, string imagePath);
        IResult Delete(string path);
    }
}
