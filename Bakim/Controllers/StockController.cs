using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Entity;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bakim.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly IStockService _stockservice;
        private readonly IStockGroupService _stockgroupservice;
        private readonly IStokKategoriService _stokKategoriService;
        private ApplicationUser applicationUser;
        private readonly UserManager<ApplicationUser> _userManager;

        public StockController(IStockService stockservice, IStockGroupService stockgroupservice,IStokKategoriService stokKategoriService,UserManager<ApplicationUser> userManager)
        {
            _stockservice = stockservice;
            _stockgroupservice = stockgroupservice;
            _stokKategoriService = stokKategoriService;
            _userManager = userManager;
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
            var liste = _stockservice.StockList();
            return View(liste.Data);
        }


        public IActionResult StockGroup(int StockGroupId)
        {
            var stockgroup = _stockgroupservice.StockGroupList();
            return View(stockgroup.Data);
        }

       

        [HttpPost]
        public async Task<IActionResult> Insert(string values)
        {
            var stock = new Stock();
            JsonConvert.PopulateObject(values, stock);
            var result = _stockservice.Add(stock);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var stock = _stockservice.StockList().Data.Where(v => v.StockId == key).FirstOrDefault();
            JsonConvert.PopulateObject(values, stock);
            var result = _stockservice.Update(stock);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var stock = _stockservice.StockList().Data.Where(v => v.StockId == key).FirstOrDefault();
            var result = _stockservice.Delete(stock);
            return Ok(result);
        }







    }
}