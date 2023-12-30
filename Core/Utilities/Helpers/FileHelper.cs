using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static  string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";
        public void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExists(IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0) {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (!type.Equals(".jpeg") && !type.Equals(".png") && !type.Equals(".jpg")) { return new ErrorResult(); }
            return new SuccessResult();
        }

        public void CreateFile(string directory, IFormFile formFile)
        {
            using (FileStream fs = File.Create(directory))
            {
                formFile.CopyTo(fs);
                fs.Flush();
            }
        }

        public IResult Delete(string path)
        {
            DeleteOldFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        public void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        public IResult Update(IFormFile formFile, string imagePath)
        {
            var fileExists = CheckFileExists(formFile);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, formFile);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Upload(IFormFile formFile)
        {
            var fileExists = CheckFileExists(formFile);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, formFile);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
    }
}
