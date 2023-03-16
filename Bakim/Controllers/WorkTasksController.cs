using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Dataaccess.Concrete.Contexts;
using Bakim.Entity;
using Bakim.Entity.Dto;
using Bakim.Entity.Views;
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
        private readonly IVarlikService _varlikService;
        private readonly IStockService _stockService;
        private readonly ITask_StockService _task_StockService;
        public WorkTasksController(ICallService callService,IWorkTaskService workTaskService, UserManager<ApplicationUser> userManager, IWorkTaskTransferService workTaskTransferService, IWorkTaskUserService workTaskUserService, ISectionFaultService sectionFaultService, ISectionService sectionService, IFileService fileService,IVarlikService varlikService, IStockService stockService,ITask_StockService task_StockService)
        {
            _callService = callService;
            _workTaskService = workTaskService;
            _userManager = userManager;
            _workTaskTransferService = workTaskTransferService;
            _workTaskUserService = workTaskUserService;
            _sectionFaultService = sectionFaultService;
            _sectionService = sectionService;
            _fileService = fileService;
            _varlikService = varlikService;
            _stockService = stockService;
            _task_StockService = task_StockService;
            
        }

        public async Task<IActionResult> WorkTasks(int id)
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

            // foreach(var item in tasks)
            // {
            //     item.Creator = await _userManager.FindByIdAsync(item.CreatorId);
            //     item.Receiver = await _userManager.FindByIdAsync(item.ReceiverId);
            //     item.Starter = await _userManager.FindByIdAsync(item.StarterId);

            //     List<WorkTaskTransfer> workTaskTransfers = _workTaskTransferService.GetAll(item.TaskId).Data;
            //     foreach(var worktransfer in workTaskTransfers)
            //     {
            //         worktransfer.TransferredUser = await _userManager.FindByIdAsync(worktransfer.TransferredUserId);
            //     }

            //      var dto = new WorkTaskDto()
            //     {
            //         WorkTask = item,
            //         WorkTaskTransfers = workTaskTransfers,
            //         WorkTaskUsers = _workTaskUserService.GetTaskUsers(item.TaskId).Data,
            //         SectionDto = sectionDto
            //     };
            //     dtos.Add(dto);
            //     foreach (var worktaskuser in dto.WorkTaskUsers)
            //     {
            //         worktaskuser.User = await _userManager.FindByIdAsync(worktaskuser.UserId);
            //     }
            // }
           
            TaskViewModel model = new()
            {
                AllUsers = users,
                SectionDto = sectionDto,
                Task = task,
                Dtos = dtos,
                WorkTasks = tasks,
                User = await _userManager.GetUserAsync(HttpContext.User)
            };
           

            return View(model);
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

           var Contexts = new ApplicationDbContext();
             

            var result = new TaskViewModel()
            {

                User = user,
                WorkTasks = tasks,
                AllUsers = users,
                Dtos = dtos,
                SectionDto = sectionDto,
                atanankullanicilars = Contexts.atanankullanicilars.ToList()
            };
                
              return DataSourceLoader.Load(result.atanankullanicilars, loadOptions);
        }


        public object WorkTaskTable(DataSourceLoadOptions loadOptions)
        {
            using var context = new ApplicationDbContext();
            var query = context.atanankullanicilars.ToList();

            query = query.GroupBy(d => d.TaskId).Select(s=> new atanankullanicilar
            {
                TaskId = s.Key,
                TaskTitle = s.First().TaskTitle.Replace("ı", "i").Replace("İ", "I").Replace("Ğ", "G").Replace("ğ", "g").Replace("ş", "s").Replace("Ü", "U").Replace("Ş", "S").Replace("ç","c").Replace("Ç","C"),
                CreatedDate = s.First().CreatedDate,
                Durum = s.First().Durum,
                İlerleme = s.First().İlerleme,
                InProcess = s.First().InProcess,
                IsActive = s.First().IsActive,
                IsCompleted = s.First().IsCompleted,
                ReceiverId = s.First().ReceiverId,
                StarterId = s.First().StarterId,
                TaskDescription = s.First().TaskDescription?.Replace("ı", "i").Replace("İ", "I").Replace("Ğ", "G").Replace("ğ", "g").Replace("ş", "s").Replace("Ü", "U").Replace("Ş", "S").Replace("ç","c").Replace("Ç","C")
            }).ToList();
            return DataSourceLoader.Load(query,loadOptions);

        }

        public object Durum(DataSourceLoadOptions loadOptions)
        {

           using(var Contexts = new ApplicationDbContext())
           {
                var query = Contexts.atanankullanicilars.ToList();

                return DataSourceLoader.Load(query,loadOptions);
           }
        }



        public object usergetir(DataSourceLoadOptions loadOptions)
        {
            var users = _userManager.Users.ToList();

            return DataSourceLoader.Load(users, loadOptions);
        }
       
        
        // public async Task<IActionResult> IsEmirleri()
        // {
        //     var tasks = _workTaskService.GetTasks().Data;
        //     List<WorkTaskDto> dtos = new();
        //     var sections = _sectionService.GetAll().Data;
        //     var sectionFaults = _sectionFaultService.GetAll().Data;
        //     SectionDto sectionDto = new SectionDto()
        //     {
        //         Sections = sections,
        //         SectionFaults = sectionFaults
        //     };
            
        //     foreach (var item in tasks)
        //     {
        //         item.Creator = await _userManager.FindByIdAsync(item.CreatorId);
        //         item.Receiver = await _userManager.FindByIdAsync(item.ReceiverId);
        //         item.Starter = await _userManager.FindByIdAsync(item.StarterId);
 
        //         List<WorkTaskTransfer> workTaskTransfers = _workTaskTransferService.GetAll(item.TaskId).Data;
        //         foreach (var worktransfer in workTaskTransfers)
        //         {
        //             worktransfer.TransferredUser = await _userManager.FindByIdAsync(worktransfer.TransferredUserId);
        //         }
                
        //         var dto = new WorkTaskDto()
        //         {
        //             WorkTask = item,
        //             WorkTaskTransfers = workTaskTransfers,
        //             WorkTaskUsers = _workTaskUserService.GetTaskUsers(item.TaskId).Data,
        //             SectionDto = sectionDto
        //         };
        //         dtos.Add(dto);
        //         foreach (var worktaskuser in dto.WorkTaskUsers)
        //         {
        //             worktaskuser.User = await _userManager.FindByIdAsync(worktaskuser.UserId);
        //         }
        //     }
        //     var user = await _userManager.GetUserAsync(HttpContext.User);
        //     var users = _userManager.Users.ToList();
           
        //     var result = new WorkTaskViewModel() 
        //     { 
        //         User = user, 
        //         WorkTasks = tasks,
        //         AllUsers = users,
        //         Dtos = dtos,
        //         SectionDto = sectionDto 

        //         };
        //     return View("is-emirleri",result);
        // }


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

        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            var sections = _sectionService.GetAll().Data;
            var sectionFaults = _sectionFaultService.GetAll().Data;
            var users = _userManager.Users.ToList();
            var varliks = _varlikService.GetAll().Data;
            
            SectionDto sectionDto = new SectionDto()
           {
                Sections = sections,
                SectionFaults = sectionFaults
           };
            
           TaskViewModel model = new TaskViewModel()
           {
                User = await _userManager.GetUserAsync(HttpContext.User),
                Section = _sectionService.GetAll().Data.FirstOrDefault(),
                SectionFaults = _sectionFaultService.GetAll().Data,
                SectionDto = sectionDto,
                AllUsers = users,
                varliks = varliks
           }; 
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddTask([FromForm]IFormFile file,WorkTask task,Varlik varlik)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var section = _sectionService.GetById(task.SectionId).Data;
            var sectionFault = _sectionFaultService.GetById(task.SectionFaultId).Data;
            var varlikk = _varlikService.GetById(c=>c.VarlikId == varlik.VarlikId).Data;
            
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

            return RedirectToAction("WorkTasks");
        }
        

        
        [HttpGet]
        public async Task<IActionResult> StartTask(int? id)
        {
            var task = _workTaskService.GetTasks(c=>c.TaskId == id).Data.FirstOrDefault();
            List<WorkTaskDto> dtos = new();
            var sections = _sectionService.GetAll().Data;
            var sectionFaults = _sectionFaultService.GetAll().Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var worktaskusers = _workTaskUserService.GetTaskUsers(task.TaskId).Data;
            var WorkTaskTransfer = _workTaskTransferService.GetAll(task.TaskId).Data;

             WorkTaskDto workTaskDto = new WorkTaskDto()
            {
                 WorkTaskUsers = worktaskusers,
                 WorkTask = task
            };
           
            SectionDto sectionDto = new SectionDto()
            {
                Sections = sections,
                SectionFaults = sectionFaults
            };

            TaskViewModel model = new()
            {
                Task = task,
                SectionDto = sectionDto,
                Dtos = dtos,
                User = user
                
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StartTask(WorkTask Task, int id)
        {

            var task = _workTaskService.GetSingle(c => c.TaskId == id).Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);

            WorkTaskUser workTaskUser = new()
            {
                StartedDate = DateTime.Now,
                InProcess = true,
                User = user,
                UserId = user.Id, 
                WorkTask = task,
                WorkTaskId = task.TaskId
            };

            task.InProcess = true;
            task.Starter = user;
            task.StarterId = user.Id;
            task.ProcessStartedDate = DateTime.Now;

            _workTaskUserService.Add(workTaskUser);
            _workTaskService.Update(task);

            return RedirectToAction("WorkTasks");
        }

        [HttpGet]
        public async Task<IActionResult> EndTask(int? id)
        {
            var task = _workTaskService.GetTasks(c=>c.TaskId == id).Data.FirstOrDefault();
            List<WorkTaskDto> dtos = new();  
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var worktaskusers = _workTaskUserService.GetTaskUsers(task.TaskId).Data;

             
            var stoklar = _stockService.StockList().Data;


            TaskViewModel model = new()
            {
                Task = task,
                User = user,
                stock = stoklar,
                Dtos = dtos,
                WorkTaskUsers = worktaskusers
               
            };
           
            return View(model);
        }

        
        [HttpGet]
        public object StokGetir(DataSourceLoadOptions loadOptions)
        {
            var result = _stockService.StockList().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }
        

        [HttpGet]
        public object GetAllStockForTask(DataSourceLoadOptions loadOptions,int id)
        {
            
            var result = _task_StockService.GetAll(c=>c.TaskId == id).Data;
            return DataSourceLoader.Load(result, loadOptions);
        } 

        [HttpPost]
        public async Task<bool> AddStockForTask(int stockId,int stockAmount,int taskId)
        {
            _task_StockService.Add(new(){StockId = stockId,StockAmount=stockAmount,TaskId=taskId}); 

            return true;
        }

        [HttpPut]
        public IActionResult UpdateStockForTask(int key, string values) 
        {
            var stockfortask = _task_StockService.GetAll(c=>c.Task_StockId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values,stockfortask);
            var result = _task_StockService.Update(stockfortask);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteStockForTask(int key)
        {
            var stockfortask = _task_StockService.GetAll(c=>c.Task_StockId == key).Data.FirstOrDefault();
            var result = _task_StockService.Delete(stockfortask);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> EndTask(TaskViewModel p, int id){
            var task = _workTaskService.GetSingle(c => c.TaskId == id).Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userTask = _workTaskUserService.GetTaskUsers(task.TaskId).Data.Where(c => c.UserId == user.Id).FirstOrDefault();
            userTask.Description = p.Description;
            userTask.InProcess = false;
            userTask.CompletedDate = DateTime.Now;
            var count = _workTaskUserService.GetTaskUsers(task.TaskId).Data.Where(c=>c.InProcess == true).Count();
            if (count == 1)
            {
                await CloseTask(id,p);
            }
            _workTaskUserService.Update(userTask);
            
            
            return RedirectToAction("WorkTasks");
        }

        public async Task<IActionResult> CloseTask(int id, TaskViewModel p)
        {
            var task = _workTaskService.GetSingle(t => t.TaskId == id).Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userTasks = _workTaskUserService.GetTaskUsers(id).Data;
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
            return RedirectToAction("WorkTasks");
        }


       

        public async Task<IActionResult> TransferTask(int taskId, ApplicationUser user)
        {
            var task = _workTaskService.GetSingle(c => c.TaskId == taskId).Data;
            var userToTransfer = await _userManager.FindByIdAsync(user.Id);
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            WorkTaskUser workTaskUser = _workTaskUserService.GetTaskUsers(taskId).Data.Where(c=>c.UserId == currentUser.Id).FirstOrDefault();
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

            return RedirectToAction("WorkTasks");
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
            return RedirectToAction("Worktasks");
        }

        [HttpGet]
        public async Task<IActionResult> TaskDetails(int id)
        {
            var task = _workTaskService.GetSingle(c=>c.TaskId == id).Data;
            var section = _sectionService.GetAll().Data.FirstOrDefault();
            var sectionFault = _sectionFaultService.GetAll().Data.FirstOrDefault();
            var varlik = _varlikService.GetAll().Data.FirstOrDefault();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var users = _userManager.Users.ToList();

            if (task.ReceiverId != null)
            {
                task.Receiver = await _userManager.FindByIdAsync(task.ReceiverId);
            }
            var taskUsers = _workTaskUserService.GetTaskUsers(id).Data;
            var taskTransfers = _workTaskTransferService.GetAll(id).Data;
            foreach (var taskUser in taskUsers)
            {
                taskUser.User = await _userManager.FindByIdAsync(taskUser.UserId);
                taskUser.WorkTask = task;
            }
            foreach (var taskTransfer in taskTransfers)
            {
                taskTransfer.TransferredUser = await _userManager.FindByIdAsync(taskTransfer.TransferredUserId);
            }
            TaskViewModel model = new TaskViewModel()
            {
                Task = task,
                WorkTaskTransfers = taskTransfers,
                WorkTaskUsers = taskUsers,
                Section = section,
                SectionFault = sectionFault,
                varlik = varlik,
                User = currentUser,
                AllUsers = users
            };
            return View(model);
        }

        [HttpPost]
        public async Task<bool> EndTaskSaveButton(int id, string aciklama)
        {
            var task = _workTaskService.GetSingle(c=>c.TaskId == id).Data;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userTask = _workTaskUserService.GetTaskUsers(task.TaskId).Data.Where(c => c.UserId == user.Id).FirstOrDefault();
            
            userTask.Description = aciklama;

           _workTaskUserService.Update(userTask);

            return true;
        }

        
    }
}