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
    public class CalendarController : Controller
    {

        private readonly ICalendarService _calendarService;
        private readonly IRoutineBakimService _routinebakimservice;
        private readonly IMachineService _machineservice;

        private readonly IProductionSectionService _productionsectionservice;

        private readonly IRoutineBakimDetayService _routineBakimDetayService;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IRoutineBakimMakineService _routineBakimMakineService;
        private readonly IRoutineBakimTuruService _routineBakimTuruService;

        public CalendarController(ICalendarService calendarService, IRoutineBakimTuruService routineBakimTuruService, IRoutineBakimMakineService routineBakimMakineService, UserManager<ApplicationUser> userManager, IRoutineBakimDetayService routineBakimDetayService, IRoutineBakimService routinebakimservice, IProductionSectionService productionSectionService, IMachineService machineService)
        {
            _calendarService = calendarService;
            _routinebakimservice = routinebakimservice;
            _machineservice = machineService;
            _productionsectionservice = productionSectionService;
            _routineBakimDetayService = routineBakimDetayService;
            _userManager = userManager;
            _routineBakimMakineService = routineBakimMakineService;
            _routineBakimTuruService = routineBakimTuruService;
        }

        public ActionResult Overview()
        {

            RoutineMakineBakimPViewModel result = new()
            {
                RoutineBakimTuruListele = _routineBakimTuruService.GetAll().Data,
                ProductionSectionListele = _productionsectionservice.GetMachineGroups().Data
            };

            return View(result);
        }



        [HttpPost]
        public async Task<PlannlamaViewModel> PlaniTamamla(PlannlamaViewModel model)
        {
            
            return model;
        }



        [HttpGet]
        public object GetCalendarList(DataSourceLoadOptions loadOptions)
        {
            var data = _calendarService.CalendarList().Data;
            return DataSourceLoader.Load(data, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(string values)
        {
            var calendar = new Bakim.Entity.Calendar();
            var result = _calendarService.Add(calendar);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var calendar = _calendarService.CalendarList(c => c.CalendarId == key).Data.First();
            var result = _calendarService.Update(calendar);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var calendar = _calendarService.CalendarList(c => c.CalendarId == key).Data.First();
            var result = _calendarService.Delete(calendar);
            return Ok(result);
        }


        [HttpGet]
        public async Task<object> TurleriGetir(DataSourceLoadOptions loadOptions)
        {
            var result = _routineBakimTuruService.GetAll().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }





    }
}