
using Bakim.Business.Abstracts;
using Bakim.Core.Utilities.Helpers.File;
using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileHelper _fileHelper;
        private readonly IStockService _stockService;
        private readonly IMachineService _machineService;
        private readonly IVarlikService _varlikService;
        private readonly IWorkTaskService _workTaskService;

        public FileManager(UserManager<ApplicationUser> userManager, IFileHelper fileHelper,IStockService stockService,IMachineService machineService,IVarlikService varlikService,IWorkTaskService workTaskService)
        {
            _userManager = userManager;
            _fileHelper = fileHelper;
            _stockService = stockService;
            _machineService = machineService;
            _varlikService = varlikService;
            _workTaskService = workTaskService;
        }

        public async Task<IResult> Add(IFormFile file, ApplicationUser user)
        {
            string folderName = "avatars";
            if (!string.IsNullOrEmpty(user.ImagePath))
            {
                _fileHelper.Remove(user.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            user.ImagePath = imageResult.Message;
            await _userManager.UpdateAsync(user);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }




        public async Task<IResult> AddForStock(IFormFile file, Stock stock)
        {
            string folderName ="stocks";
             if (!string.IsNullOrEmpty(stock.ImagePath))
            {
                _fileHelper.Remove(stock.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            stock.ImagePath = imageResult.Message;
            _stockService.Update(stock);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

        public async Task<IResult> AddForMachine(IFormFile file,Machine machine)
        {
            string folderName ="machines";
            if(!string.IsNullOrEmpty(machine.ImagePath))
            {
                _fileHelper.Remove(machine.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if(!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi");
            }

            machine.ImagePath = imageResult.Message;
            _machineService.Update(machine);
            return new SuccessResult("Resim Başarıyla Yüklendi");
            
        }


         public async Task<IResult> AddForVarlik(IFormFile file,Varlik varlik)
        {
            string folderName ="varliks";
            if(!string.IsNullOrEmpty(varlik.ImagePath))
            {
                _fileHelper.Remove(varlik.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if(!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi");
            }

            varlik.ImagePath = imageResult.Message;
            _varlikService.Update(varlik);
            return new SuccessResult("Resim Başarıyla Yüklendi");
            
        }

        public async Task<IResult> AddForIsEmri(IFormFile file, WorkTask task)
        {
            string folderName = "worktasks";
            if(!string.IsNullOrEmpty(task.ImagePath))
            {
                _fileHelper.Remove(task.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if(!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi");
            }

            task.ImagePath = imageResult.Message;
            _workTaskService.Update(task);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }


    }
}
