using Bakim.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Bakim.Core.Utilities.Helpers.File
{
    public class FileHelper : IFileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        public void CheckDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExist(IFormFile file)
        {

            if (file == null && file.Length == 0)
            {
                return new ErrorResult("En az bir dosya yüklemelisiniz.");

            }
            return new SuccessResult();
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".jpg" && type != ".png" && type != ".jfif")
            {
                return new ErrorResult("Lütfen bir resim dosyası seçiniz.");
            }
            return new SuccessResult();
        }

        public void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = System.IO.File.Create(directory))
            {

                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        public IResult Remove(string path,string foldername)
        {
                    string _folderName = "\\app\\images\\PATH\\";

            _folderName = _folderName.Replace("PATH",foldername);
            RemoveOldFile((_currentDirectory + _folderName + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        public void RemoveOldFile(string directory)
        {
            if (System.IO.File.Exists(directory.Replace("/", "\\")))
            {
                System.IO.File.Delete(directory.Replace("/", "\\"));
            }
        }

        public IResult Update(IFormFile file, string imagePath,string folderName)
        {
                    string _folderName = "\\app\\images\\PATH\\";
            _folderName = _folderName.Replace("PATH",folderName);


            List<string> ImagePaths = new List<string>();

            var fileExists = CheckFileExist(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName); 
            var typeValid = CheckFileTypeValid(type);
            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            var randomName = Guid.NewGuid().ToString();

            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));


        }

        public IResult Upload(IFormFile file,string folderName)
        {
                    string _folderName = "\\app\\images\\PATH\\";
            _folderName = _folderName.Replace("PATH",folderName);
            List<string> ImagePaths = new List<string>();

            var fileExists = CheckFileExist(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }
            var randomName = Guid.NewGuid().ToString();


            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);


            return new SuccessResult(randomName + type);

        }










        
    }
}
