using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Entity;
using Bakim.ViewModels;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bakim.Controllers
{

    [Authorize]
    public class RoutineBakimController : Controller
    {
        private readonly IRoutineBakimService _routinebakimservice;
        private readonly IMachineService _machineservice;

        private readonly IProductionSectionService _productionsectionservice;

        private readonly IRoutineBakimDetayService _routineBakimDetayService;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IRoutineBakimMakineService _routineBakimMakineService;
        private readonly IRoutineBakimTuruService _routineBakimTuruService;


        public RoutineBakimController(IRoutineBakimTuruService routineBakimTuruService,IRoutineBakimMakineService routineBakimMakineService,UserManager<ApplicationUser> userManager, IRoutineBakimDetayService routineBakimDetayService, IRoutineBakimService routinebakimservice, IProductionSectionService productionSectionService, IMachineService machineService)
        {
            _routinebakimservice = routinebakimservice;
            _machineservice = machineService;
            _productionsectionservice = productionSectionService;
            _routineBakimDetayService = routineBakimDetayService;
            _userManager = userManager;
            _routineBakimMakineService = routineBakimMakineService;
            _routineBakimTuruService = routineBakimTuruService;
        }

        public IActionResult Index()
        {
            // _routinebakimservice.Add(new(){
            //     BakimAciklamasi="afasdadasda",
            //     BakimAdi = "aaaaaaa",
            //     BakimTarihi = DateTime.Now,
            //     PlanlamaTarihi = DateTime.Now,
            //     UserId = "12323132"

            // });
            var liste = _productionsectionservice.GetAll();
            return View(liste.Data);
        }

        public IActionResult BirimDetay(int sectionId)
        {
            var machines = _machineservice.GetMachines(m => m.ProductionSectionId == sectionId);
            return View(machines.Data);
        }

        public List<ProductionSection> BirimleriGetir()
        {
            var birimler= _productionsectionservice.GetAll();
            return birimler.Data;
        }

        public IActionResult MachineDetay(int machineId)
        {
            var machine = _machineservice.GetMachines(c => c.MachineId == machineId).Data.First();
            return View(machine);
        }

        public IActionResult RoutineBakimMakine(int machineId)
        {
            var machine = _machineservice.GetMachines(c => c.MachineId == machineId).Data.First();
            return View(machine);
        }

        public IActionResult BakimPlanla()
        {

            return View();
        }

        public IActionResult BakimListele()
        {

            return View();
        }

        public IActionResult GenelBakimP()
        {

            return View();
        }

        public IActionResult MakineBakimP()
        {
            var birimler = _productionsectionservice.GetAll().Data;
            return View(birimler);
        }
        public async Task<List<Bakim.Entity.Machine>> GetMachinesBySection(int sectionId)
        {
            var machines = _machineservice.GetMachines(c => c.ProductionSectionId == sectionId).Data;
            return machines;
        }



        [HttpGet]
        public object BakimlariGetir(DataSourceLoadOptions loadOptions)
        {
            var result = _routinebakimservice.RoutineBakimList().Data;
            var makinelerbakimlarlisteler = _routineBakimMakineService.GetAll().Data;
            var modelList = new List<RoutineBakimMakineViewModel>();
            if (result != null)
            {
                foreach (var i in result)
                {
                    var model = new RoutineBakimMakineViewModel()
                    {
                        BakimAciklamasi = i.BakimAciklamasi,
                        BakimAdi = i.BakimAdi,
                        BakimTarihi = i.BakimTarihi,
                        PlanlamaTarihi = i.PlanlamaTarihi,
                        RoutineBakimId = i.RoutineBakimId,
                        UserId = i.UserId
                    };
                    modelList.Add(model);
                }
            }
            if (makinelerbakimlarlisteler != null)
            {
                foreach (var i in makinelerbakimlarlisteler)
                {
                    var model = new RoutineBakimMakineViewModel()
                    {
                        BakimAciklamasi = i.BakimAciklamasi,
                        BakimAdi = i.BakimAdi,
                        BakimTarihi = i.BakimTarihi,
                        PlanlamaTarihi = i.PlanlamaTarihi,
                        RoutineBakimId = i.RoutineBakimId,
                        UserId = i.UserId,
                        MachineId = i.MachineId
                    };
                    modelList.Add(model);
                }
            }

            return DataSourceLoader.Load(modelList, loadOptions);
        }

        [HttpGet]
        public object MakineListele(DataSourceLoadOptions loadOptions)
        {
            var result = _machineservice.GetMachines().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpGet]
        public object UserList(DataSourceLoadOptions loadOptions)
        {
            var result = _userManager.Users.ToList();
            return DataSourceLoader.Load(result, loadOptions);
        }

        // [HttpGet]
        // public object (DataSourceLoadOptions loadOptions){
        //     var result = _calendarService.CalendarList().Data;
        // }


        // [HttpDelete]
        // public IActionResult DeleteRoutineBakim(int key)
        // {
        //     var department = _departmentService.GetDepartment(key).Data;
        //     var result = _departmentService.Delete(department);
        //     return Ok(result);
        // }
        
        [HttpGet]
        public async Task<object> TurleriGetir(DataSourceLoadOptions loadOptions)
        {
            var result = _routineBakimTuruService.GetAll().Data;
            return DataSourceLoader.Load(result,loadOptions);
        }
    }
}