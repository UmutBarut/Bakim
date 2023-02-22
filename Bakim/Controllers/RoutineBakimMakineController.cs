using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Bakim.Controllers
{
    public class RoutineBakimMakineController : Controller
    {
        private readonly IRoutineBakimMakineService _routineBakimMakineService;

        private readonly IMachineService _machineservice;

        private readonly IProductionSectionService _productionsectionservice;

        private readonly IRoutineBakimDetayService _routineBakimDetayService;


        public RoutineBakimMakineController(IRoutineBakimDetayService routineBakimDetayService, IRoutineBakimService routinebakimservice, IProductionSectionService productionSectionService, IMachineService machineService, IRoutineBakimMakineService routineBakimMakineService)
        {
            routineBakimMakineService = _routineBakimMakineService;
            machineService = _machineservice;
            productionSectionService = _productionsectionservice;
            routineBakimDetayService = _routineBakimDetayService;
            
           
            
            
        }
        



    }
}