using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;
using Bakim.Entity.Dto;
using Bakim.ViewModels;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bakim.Controllers
{
     [Authorize]
    public class WorkTasksController : Controller
    {
        private readonly ICallService _callService;
        private readonly IWorkTaskService _workTaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWorkTaskTransferService _workTaskTransferService;
        private readonly IWorkTaskUserService _workTaskUserService;
        private readonly ISectionFaultService _sectionFaultService;
        private readonly ISectionService _sectionService;
        private readonly IFileService _fileService;
        public WorkTasksController(ICallService callService,IWorkTaskService workTaskService, UserManager<ApplicationUser> userManager, IWorkTaskTransferService workTaskTransferService, IWorkTaskUserService workTaskUserService, ISectionFaultService sectionFaultService, ISectionService sectionService, IFileService fileService)
        {
            _callService = callService;
            _workTaskService = workTaskService;
            _userManager = userManager;
            _workTaskTransferService = workTaskTransferService;
            _workTaskUserService = workTaskUserService;
            _sectionFaultService = sectionFaultService;
            _sectionService = sectionService;
            _fileService = fileService;
        }

        public IActionResult deneme(int id)
        {

            var tasks = _workTaskService.GetTasks().Data;
            
            List<WorkTaskDto> dtos = new();
            var sections = _sectionService.GetAll().Data;
            var task = _workTaskService.GetSingle(c=> c.TaskId == id).Data;
            var sectionFaults = _sectionFaultService.GetAll().Data;
            var users = _userManager.Users.ToList();
            SectionDto sectionDto = new SectionDto()
            {
                Sections = sections,
                SectionFaults = sectionFaults
            };

            DenemeViewModel model = new()
            {
                AllUsers = users,
                SectionDto = sectionDto,
                Task = task
                
                

                
            };

            using( var Contexts = new ApplicationDbContext())
            {
                var query = Contexts.atanankullanicilars.ToList();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<DenemeViewModel> GetWorkTask(int id)
        {
            DenemeViewModel model = new()
            {
                Task = _workTaskService.GetSingle(c=> c.TaskId == id).Data,
                User = await _userManager.FindByIdAsync(_workTaskService.GetSingle(c=>c.TaskId == id).Data.CreatorId)
            };

            return model;
        }

        [HttpGet]
        public async Task<object> GetIsEmri(DataSourceLoadOptions loadOptions)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var tasks = _workTaskService.GetTasks().Data;
            var users = _userManager.Users.ToList();
            List<WorkTaskDto> dtos = new();
            var sections = _sectionService.GetAll().Data;
            var sectionFaults = _sectionFaultService.GetAll().Data;

            SectionDto sectionDto = new SectionDto()
            {
                Sections = sections,
                SectionFaults = sectionFaults 
            };
             
             var result = new WorkTaskViewModel() 
            { 
                User = user, 
                WorkTasks = tasks,
                AllUsers = users,
                Dtos = dtos,
                SectionDto = sectionDto   

            };
                
              return DataSourceLoader.Load(result.WorkTasks, loadOptions);
        }

        public object usergetir(DataSourceLoadOptions loadOptions)
        {
            var users = _userManager.Users.ToList();

            return DataSourceLoader.Load(users, loadOptions);
        }
       
        
        public async Task<IActionResult> IsEmirleri()
        {
            var tasks = _workTaskService.GetTasks().Data;
            List<WorkTaskDto> dtos = new();
            var sections = _sectionService.GetAll().Data;
            var sectionFaults = _sectionFaultService.GetAll().Data;
            SectionDto sectionDto = new SectionDto()
            {
                Sections = sections,
                SectionFaults = sectionFaults
            };
            
            foreach (var item in tasks)
            {
                item.Creator = await _userManager.FindByIdAsync(item.CreatorId);
                item.Receiver = await _userManager.FindByIdAsync(item.ReceiverId);
                item.Starter = await _userManager.FindByIdAsync(item.StarterId);
 
                List<WorkTaskTransfer> workTaskTransfers = _workTaskTransferService.GetAll(item.TaskId).Data;
                foreach (var worktransfer in workTaskTransfers)
                {
                    worktransfer.TransferredUser = await _userManager.FindByIdAsync(worktransfer.TransferredUserId);
                }
                
                var dto = new WorkTaskDto()
                {
                    WorkTask = item,
                    WorkTaskTransfers = workTaskTransfers,
                    WorkTaskUsers = _workTaskUserService.GetTaskUsers(item.TaskId).Data,
                    SectionDto = sectionDto
                };
                dtos.Add(dto);
                foreach (var worktaskuser in dto.WorkTaskUsers)
                {
                    worktaskuser.User = await _userManager.FindByIdAsync(worktaskuser.UserId);
                }
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var users = _userManager.Users.ToList();
           
            var result = new WorkTaskViewModel() 
            { 
                User = user, 
                WorkTasks = tasks,
                AllUsers = users,
                Dtos = dtos,
                SectionDto = sectionDto 

                };
            return View("is-emirleri",result);
        }





         public IActionResult Index()
        {
         
            return View();
        }
        
         public IActionResult MachineTickets(){
            var result = _callService.GetAll().Data;
            return View(result);
        }

        [HttpGet]
        public object GetTasks(DataSourceLoadOptions loadOptions)
        {
            
            var result = _workTaskService.GetTasks().Data.OrderByDescending(d => d.CreatedDate);
           
            return DataSourceLoader.Load(result, loadOptions);
        }
        [HttpPost]
        public async Task<IActionResult> InsertTask(string values)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var task = new WorkTask();
            JsonConvert.PopulateObject(values, task);
            task.Creator = user;
            task.CreatorId = user.Id;
            task.CreatedDate = DateTime.Now;
            var result = _workTaskService.Add(task);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(int key, string values)
        {
            var task = _workTaskService.GetTasks(w=>w.TaskId == key).Data.First();
            JsonConvert.PopulateObject(values, task);
            if (task.IsCompleted == true)
            {
                task.CompletedDate = DateTime.Now;
            }
            var result = _workTaskService.Update(task);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int key)
        {
            var task = _workTaskService.GetTasks(w => w.TaskId == key).Data.First();
            var result = _workTaskService.Delete(task);
            return Ok(result);
        }
        [HttpGet]
            public object GetCalls(DataSourceLoadOptions loadOptions)
            {
                var result = _callService.GetAll();
                return DataSourceLoader.Load(result.Data,loadOptions);
            }

        

        [HttpPut]
        public async Task<IActionResult> UpdateCall(string key, string values)
        {
            var CallDtoViewModel = _callService.GetAll().Data.Where(d=>d.CallId == int.Parse(key)).First();
            JsonConvert.PopulateObject(values, CallDtoViewModel);
            if (!CallDtoViewModel.IsActive)
            {
               CallDtoViewModel.ComplationDate = DateTime.Now;
            }
            var result = _callService.UpdateCall(CallDtoViewModel);
            if (result.Success)
            {
                return Ok("Çağrı Güncellendi");
            }
            else
            {
                return BadRequest("Çağrı güncellenirken hata oluştu.");
            }
        }

        
       [HttpPost]
        public async Task<IActionResult> StartTask(int Id)
        {
            // var task = _workTaskService.GetSingle(c => c.TaskId == Id).Data;
            // var user = await _userManager.GetUserAsync(HttpContext.User);
            // task.ProcessStartedDate = DateTime.Now;
            // task.InProcess = true;
            // task.Starter = user;
            // task.StarterId = user.Id;
            // WorkTaskUser workTaskUser = new()
            // {
            //     StartedDate = DateTime.Now,
            //     InProcess = true,
            //     User = user,
            //     UserId = user.Id,
            //     WorkTask = task,
            //     WorkTaskId = task.TaskId
            // };
            // _workTaskUserService.Add(workTaskUser);
            // _workTaskService.Update(task);
            return RedirectToAction("deneme","Worktasks");
        }

        [HttpPost]
        public async Task<IActionResult> EndTask(EndTaskViewModel p){
            var task = _workTaskService.GetSingle(c => c.TaskId == p.TaskId).Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userTask = _workTaskUserService.GetTaskUsers(task.TaskId).Data.Where(c => c.UserId == user.Id).First();
            userTask.Description = p.Description;
            userTask.InProcess = false;
            userTask.CompletedDate = DateTime.Now;
            var count = _workTaskUserService.GetTaskUsers(task.TaskId).Data.Where(c=>c.InProcess == true).Count();
            if (count == 1)
            {
                await CloseTask(p);
            }
            _workTaskUserService.Update(userTask);
            
            
            return RedirectToAction("IsEmirleri","Worktasks");
        }

        public async Task<IActionResult> CloseTask(EndTaskViewModel p)
        {
            var task = _workTaskService.GetSingle(t => t.TaskId == p.TaskId).Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userTasks = _workTaskUserService.GetTaskUsers(p.TaskId).Data;
            foreach (var uTask in userTasks)
            {
                uTask.InProcess = false;
                uTask.Description = p.Description;
                
            _workTaskUserService.Update(uTask);           
            }
            task.IsCompleted = true;
            task.InProcess = false;
            task.CompletedDate = DateTime.Now;
            task.IsActive = false;
            _workTaskService.Update(task);
            return RedirectToAction("IsEmirleri","Worktasks");
        }


        public async Task<IActionResult> AddTask([FromForm]IFormFile file,WorkTask task)
        {
           
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var section = _sectionService.GetById(task.SectionId).Data;
            var sectionFault = _sectionFaultService.GetById(task.SectionFaultId).Data;
            
            if (task.ReceiverId != null)
            {
                var receiver = await _userManager.FindByIdAsync(task.ReceiverId);
                task.Receiver = receiver;
            }

            task.CreatedDate = DateTime.Now;
            task.Creator = user;
            task.CreatorId = user.Id;
            task.InProcess = false;
            task.IsActive = true;
            task.TaskTitle = section.SectionName + " - " + sectionFault.SectionFaultName;
            

            _workTaskService.Add(task);
            _fileService.AddForIsEmri(file,task);
            
            
            
            return RedirectToAction("deneme");
        }

        public async Task<IActionResult> TransferTask(int taskId, ApplicationUser user)
        {
            var task = _workTaskService.GetSingle(c => c.TaskId == taskId).Data;
            var userToTransfer = await _userManager.FindByIdAsync(user.Id);
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            WorkTaskUser workTaskUser = _workTaskUserService.GetTaskUsers(taskId).Data.Where(c=>c.UserId == currentUser.Id).First();
            workTaskUser.UserId = userToTransfer.Id;
            workTaskUser.User = userToTransfer;
            _workTaskUserService.Update(workTaskUser);
            var transfer = new WorkTaskTransfer()
            {
                TransferredDate = DateTime.Now,
                TransferredUser = userToTransfer,
                TransferredUserId = userToTransfer.Id,
                WorkTaskId = task.TaskId,
                WorkTask = task,
                
                
            };
            _workTaskService.Update(task);
            _workTaskTransferService.Add(transfer);

            return RedirectToAction("IsEmirleri","Worktasks");
        }

        public async Task<IActionResult> AddUserToTask(int taskId)
        {
            var task = _workTaskService.GetSingle(c => c.TaskId == taskId).Data;
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            WorkTaskUser user = new WorkTaskUser()
            {
                User = currentUser,
                UserId = currentUser.Id,
                WorkTask = task,
                WorkTaskId = task.TaskId,
                InProcess = true,
                StartedDate = DateTime.Now
                
            };
            _workTaskUserService.Add(user);
            return RedirectToAction("IsEmirleri","Worktasks");
        }

        public async Task<IActionResult> TaskDetails(int taskId)
        {
            var task = _workTaskService.GetSingle(c => c.TaskId == taskId).Data;
            if (task.ReceiverId != null)
            {
                task.Receiver = await _userManager.FindByIdAsync(task.ReceiverId);
            }
            var taskUsers = _workTaskUserService.GetTaskUsers(taskId).Data;
            var taskTransfers = _workTaskTransferService.GetAll(taskId).Data;
            foreach (var taskUser in taskUsers)
            {
                
                taskUser.User = await _userManager.FindByIdAsync(taskUser.UserId);
                taskUser.WorkTask = task;
            }
            foreach (var taskTransfer in taskTransfers)
            {
                taskTransfer.TransferredUser = await _userManager.FindByIdAsync(taskTransfer.TransferredUserId);
            }
            WorkTaskDto dto = new WorkTaskDto()
            {
                WorkTask = task,
                WorkTaskTransfers = taskTransfers,
                WorkTaskUsers = taskUsers
            };
            return View(dto);
        }
    }
}