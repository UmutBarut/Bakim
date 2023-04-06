using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using Bakim.Entity;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Bakim.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Bakim.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DescribingController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IVarlikGroupService _varlikGroupService;
        private readonly IStockGroupService _stockGroupService;
        private readonly IDetayGroupService _detayGroupService;
        private readonly IProductionSectionService _productionSectionService;
        private readonly IStokKategoriService _stokKategoriService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileService _fileService;
        private readonly ITedarikciFirmaService _tedarikciFirmaService;
        private readonly IVarlikService _varlikService;
        private readonly IStok_FirmaService _stok_FirmaService;
        private readonly IBirimService _birimService;
        private readonly IRutinBakimKategorisiService _rutinBakimKategorisiService;
        private readonly IRutinBakimService _rutinBakimService;
        private readonly ISectionFaultCategoryService _sectionFaultCategoryService;
        private readonly ISectionFaultService _sectionFaultService;
        private readonly ISectionService _sectionService;

        public DescribingController(IStockGroupService stockGroupService, IVarlikGroupService varlikGroupService, IStockService stockService, IDetayGroupService detayGroupService, IProductionSectionService productionSectionService, IStokKategoriService stokKategoriService, UserManager<ApplicationUser> userManager, IFileService fileService, ITedarikciFirmaService tedarikciFirmaService, IVarlikService varlikService, IStok_FirmaService stok_FirmaService,IBirimService birimService,IRutinBakimKategorisiService rutinBakimKategorisiService,IRutinBakimService rutinBakimService,ISectionFaultCategoryService sectionFaultCategoryService,ISectionFaultService sectionFaultService,ISectionService sectionService)
        {
            _stockGroupService = stockGroupService;
            _varlikGroupService = varlikGroupService;
            _stockService = stockService;
            _detayGroupService = detayGroupService;
            _productionSectionService = productionSectionService;
            _stokKategoriService = stokKategoriService;
            _userManager = userManager;
            _fileService = fileService;
            _tedarikciFirmaService = tedarikciFirmaService;
            _varlikService = varlikService;
            _stok_FirmaService = stok_FirmaService;
            _birimService = birimService;
            _rutinBakimKategorisiService = rutinBakimKategorisiService;
            _rutinBakimService = rutinBakimService;
            _sectionFaultCategoryService = sectionFaultCategoryService;
            _sectionFaultService = sectionFaultService;
            _sectionService = sectionService;
        }

        public IActionResult VarlikGroup()
        {
            return View();
        }

        public IActionResult DetayGroup()
        {
            var model = _varlikGroupService.GetAll().Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult DetayGroup(DetayGroup detayGroup)
        {
            _detayGroupService.Add(detayGroup);
            return RedirectToAction("DetayGroup");
        }

        public IActionResult StokKategori()
        {
            var model = _stockGroupService.GetAll().Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult StokKategori(StokKategori stokKategori)
        {
            _stokKategoriService.Add(stokKategori);
            return RedirectToAction("StokKategori");
        }



        public IActionResult Varlik()
        {
            DescribeViewModel vm = new DescribeViewModel()
            {
                DetayGrubu = _detayGroupService.GetAll().Data,
                UretimBolumu = _productionSectionService.GetAll().Data,
                VarlikGrubu = _varlikGroupService.GetAll().Data
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Varlik(IFormFile file, Varlik varlik)
        {
            varlik.CorporationId = 1;
            varlik.UploadDate = DateTime.Now;

            _varlikService.Add(varlik);
            _fileService.AddForVarlik(file, varlik);
            return RedirectToAction("VarlikListe", "Varlik");
        }



        public IActionResult TedarikciFirma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TedarikciFirma(TedarikciFirma tedarikciFirma)
        {
            _tedarikciFirmaService.Add(tedarikciFirma);
            return RedirectToAction("TedarikciFirma");
        }


        public IActionResult StockGroup()
        {
            return View();
        }

        public IActionResult Stock()
        {
            StockViewModel model = new StockViewModel()
            {
                stokKategori = _stokKategoriService.GetAll().Data.FirstOrDefault(),
                tedarikciFirmalar = _tedarikciFirmaService.GetAll().Data,
                stockGrubu = _stockGroupService.GetAll().Data,
                stokfirma = _stok_FirmaService.GetAll().Data
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Stock(IFormFile file, Stock stock, int[] firmalar)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            stock.CorporationId = user.CorporationId;
            stock.UploadDate = DateTime.Now;
            _stockService.Add(stock);
            _fileService.AddForStock(file, stock);
            foreach (var item in firmalar)
            {
                Stok_Firma stokfirma = new()
                {
                    FirmaId = item,
                    StockId = stock.StockId
                };
                _stok_FirmaService.Add(stokfirma);
            }
            return RedirectToAction("StokListe", "Varlik");
        }


        public List<TedarikciFirma> GetFirma()
        {
            var model = _tedarikciFirmaService.GetAll().Data;
            return model;
        }


        public List<VarlikGroup> GetVarlikGroups()
        {
            var model = _varlikGroupService.GetAll().Data;
            return model;
        }

        public List<DetayGroup> GetDetayGroups()
        {
            var model = _detayGroupService.GetAll().Data;
            return model;
        }

        public async Task<List<DetayGroup>> KategoriGetiren(int getiren)
        {
            var kategoriler = _detayGroupService.GetAll(c => c.VarlikGroupId == getiren).Data;

            return kategoriler;
        }

        public async Task<List<StokKategori>> KategoriGetir(int getiren)
        {
            var kategoriler = _stokKategoriService.GetAll(c => c.StockGroupId == getiren).Data;

            return kategoriler;
        }



        [HttpGet]
        public object GetAllDetayGroup(DataSourceLoadOptions loadOptions)
        {
            var result = _detayGroupService.GetAll(c=> c.Pasif == false).Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddDetayGroup(string values)
        {
            var detayGroup = new DetayGroup();
            JsonConvert.PopulateObject(values, detayGroup);
            var result = _detayGroupService.Add(detayGroup);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateDetayGroup(int key, string values)
        {
            var detayGroup = _detayGroupService.GetAll(c => c.DetayGroupId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values, detayGroup);
            var result = _detayGroupService.Update(detayGroup);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteDetayGroup(int key)
        {
            var detayGroup = _detayGroupService.GetAll(c => c.DetayGroupId == key).Data.FirstOrDefault();
            detayGroup.Pasif = true;
            var result = _detayGroupService.Update(detayGroup);
            return Ok(result);
        }


        [HttpGet]
        public object GetVarlikGroups(DataSourceLoadOptions loadOptions)
        {
            var result = _varlikGroupService.GetAll().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }


        [HttpGet]
        public object GetAllVarlikGroup(DataSourceLoadOptions loadOptions)
        {
            var result = _varlikGroupService.GetAll(c=> c.Pasif == false).Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddVarlikGroup(string values)
        {
            var varlikGroup = new VarlikGroup();
            JsonConvert.PopulateObject(values, varlikGroup);
            var result = _varlikGroupService.Add(varlikGroup);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateVarlikGroup(int key, string values)
        {
            var varlikGroup = _varlikGroupService.GetAll(c => c.VarlikGroupId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values, varlikGroup);
            var result = _varlikGroupService.Update(varlikGroup);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteVarlikGroup(int key)
        {
            var varlik = _varlikGroupService.GetAll(c => c.VarlikGroupId == key).Data.FirstOrDefault();
            varlik.Pasif = true;
            var result = _varlikGroupService.Update(varlik);
            return Ok(result);
        }




        [HttpGet]
        public object GetAllStockGroup(DataSourceLoadOptions loadOptions)
        {
            var result = _stockGroupService.GetAll(c=> c.Pasif == false).Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddStockGroup(string values)
        {
            var StockGroup = new StockGroup();
            JsonConvert.PopulateObject(values, StockGroup);
            var result = _stockGroupService.Add(StockGroup);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateStockGroup(int key, string values)
        {
            var StockGroup = _stockGroupService.GetAll(c => c.StockGroupId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values, StockGroup);
            var result = _stockGroupService.Update(StockGroup);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteStockGroup(int key)
        {
            var StockGroup = _stockGroupService.GetAll(c => c.StockGroupId == key).Data.FirstOrDefault();
            StockGroup.Pasif = true;
            var result = _stockGroupService.Update(StockGroup);
            return Ok(result);
        }






        [HttpGet]
        public object GetAllStokKategori(DataSourceLoadOptions loadOptions)
        {
            var result = _stokKategoriService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddStokKategori(string values)
        {
            var stokKategori = new StokKategori();
            JsonConvert.PopulateObject(values, stokKategori);
            var result = _stokKategoriService.Add(stokKategori);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateStokKategori(int key, string values)
        {
            var stokKategori = _stokKategoriService.GetAll(c => c.StokKategoriId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values, stokKategori);
            var result = _stokKategoriService.Update(stokKategori);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteStokKategori(int key)
        {
            var stokKategori = _stokKategoriService.GetAll(c => c.StokKategoriId == key).Data.FirstOrDefault();
            stokKategori.Pasif = true;
            var result = _stokKategoriService.Update(stokKategori);
            return Ok(result);
        }






        [HttpGet]
        public object GetAllStock(DataSourceLoadOptions loadOptions)
        {
            var result = _stockService.StockList().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(string values)
        {
            var Stock = new Stock();
            JsonConvert.PopulateObject(values, Stock);
            var result = _stockService.Add(Stock);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateStock(int key, string values)
        {
            var Stock = _stockService.StockList(c => c.StockId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values, Stock);
            var result = _stockService.Update(Stock);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteStock(int key)
        {
            var Stock = _stockService.StockList(c => c.StockId == key).Data.FirstOrDefault();
            var result = _stockService.Delete(Stock);
            return Ok(result);
        }




        [HttpGet]
        public object GetAllFirma(DataSourceLoadOptions loadOptions)
        {
            var firmalar = _tedarikciFirmaService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(firmalar, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddFirma(string values)
        {
            var firmalar = new TedarikciFirma();
            JsonConvert.PopulateObject(values, firmalar);
            var result = _tedarikciFirmaService.Add(firmalar);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateFirma(int key, string values)
        {
            var firmalar = _tedarikciFirmaService.GetAll(c => c.FirmaId == key).Data.FirstOrDefault();
            JsonConvert.PopulateObject(values, firmalar);
            var result = _tedarikciFirmaService.Update(firmalar);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteFirma(int key)
        {
            var firma = _tedarikciFirmaService.GetAll(c => c.FirmaId == key).Data.FirstOrDefault();
            firma.Pasif=true;
            var result = _tedarikciFirmaService.Update(firma);
            return Ok(result);
        }


        public IActionResult ProductionSection()
        {
            return View();
        }

        [HttpGet]
        public object GetAllProductionSection(DataSourceLoadOptions loadOptions)
        {
            var ps = _productionSectionService.GetAll(c=> c.Pasif == false).Data;
            return DataSourceLoader.Load(ps, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductionSection(string values)
        {
            var ps = new ProductionSection();
            JsonConvert.PopulateObject(values, ps);
            var result = _productionSectionService.Add(ps);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProductionSection(int key, string values)
        {
            var ps = _productionSectionService.GetById(c=>c.ProductionSectionId == key).Data;
            JsonConvert.PopulateObject(values, ps);
            var result = _productionSectionService.Update(ps);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteProductionSection(int key)
        {
            var ps = _productionSectionService.GetAll(c=> c.ProductionSectionId == key).Data.FirstOrDefault();
            ps.Pasif=true;
            var result = _productionSectionService.Update(ps);
            return Ok(result);
        }




        public IActionResult BirimTanimlama()
        {
            return View();
        }

         [HttpGet]
        public object GetAllBirimler(DataSourceLoadOptions loadOptions)
        {
            var birim = _birimService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(birim, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddBirim(string values)
        {
            var birim = new Birim();
            JsonConvert.PopulateObject(values, birim);
            var result = _birimService.Add(birim);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateBirim(int key, string values)
        {
            var birim = _birimService.GetById(c=> c.BirimId == key).Data;
            JsonConvert.PopulateObject(values, birim);
            var result = _birimService.Update(birim);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteBirim(int key)
        {
            var birim = _birimService.GetAll(c => c.BirimId == key).Data.FirstOrDefault();
            birim.Pasif=true;
            var result = _birimService.Update(birim);
            return Ok(result);
        }





         public IActionResult RutinBakimKategorisi()
        {
            return View();
        }

         [HttpGet]
        public object GetAllRutinBakimKategori(DataSourceLoadOptions loadOptions)
        {
            var kategori = _rutinBakimKategorisiService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(kategori, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddRutinBakimKategori(string values)
        {
            var kategori = new RutinBakimKategorisi();
            JsonConvert.PopulateObject(values, kategori);
            kategori.UploadDate = DateTime.Now;
            var result = _rutinBakimKategorisiService.Add(kategori);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateRutinBakimKategori(int key, string values)
        {
            var kategori = _rutinBakimKategorisiService.GetById(c=> c.KategoriId == key).Data;
            JsonConvert.PopulateObject(values, kategori);
            var result = _rutinBakimKategorisiService.Update(kategori);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteRutinBakimKategori(int key)
        {
            var kategori = _rutinBakimKategorisiService.GetAll(c => c.KategoriId == key).Data.FirstOrDefault();
            kategori.Pasif=true;
            var result = _rutinBakimKategorisiService.Update(kategori);
            return Ok(result);
        }




          public IActionResult RutinBakim()
        {
           RutinBakimViewModel model = new RutinBakimViewModel()
           {
                Kategoriler = _rutinBakimKategorisiService.GetAll().Data,
                Bakimlar = _rutinBakimService.GetAll().Data
           };

            return View(model);
        }

         [HttpGet]
        public object GetAllRutinBakim(DataSourceLoadOptions loadOptions)
        {
            var bakim = _rutinBakimService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(bakim, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddRutinBakim(string values)
        {
            var bakim = new RutinBakim();
            JsonConvert.PopulateObject(values, bakim);
            bakim.UploadDate = DateTime.Now;
            var result = _rutinBakimService.Add(bakim);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateRutinBakim(int key, string values)
        {
            var bakim = _rutinBakimService.GetById(c=> c.RutinBakimId == key).Data;
            JsonConvert.PopulateObject(values, bakim);
            var result = _rutinBakimService.Update(bakim);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteRutinBakim(int key)
        {
            var bakim = _rutinBakimService.GetAll(c => c.RutinBakimId == key).Data.FirstOrDefault();
            bakim.Pasif=true;
            var result = _rutinBakimService.Update(bakim);
            return Ok(result);
        }



        public IActionResult SectionFaultCategory()
        {
            return View();
        }

        [HttpGet]
        public object GetAllSectionFaultCategory(DataSourceLoadOptions loadOptions)
        {
            var sectionFaultCategory = _sectionFaultCategoryService.GetAll(c=>c.Pasif == false).Data.OrderByDescending(c=>c.FaultCategoryId).ToList();
            return DataSourceLoader.Load(sectionFaultCategory, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddSectionFaultCategory(string values)
        {
            var sectionFaultCategory = new SectionFaultCategory();
            JsonConvert.PopulateObject(values, sectionFaultCategory);
            sectionFaultCategory.UploadDate = DateTime.Now;
            var result = _sectionFaultCategoryService.Add(sectionFaultCategory);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateSectionFaultCategory(int key, string values)
        {
            var sectionFaultCategory = _sectionFaultCategoryService.GetById(c=> c.FaultCategoryId == key).Data;
            JsonConvert.PopulateObject(values, sectionFaultCategory);
            var result = _sectionFaultCategoryService.Update(sectionFaultCategory);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteSectionFaultCategory(int key)
        {
            var sectionFaultCategory = _sectionFaultCategoryService.GetAll(c => c.FaultCategoryId == key).Data.FirstOrDefault();
            sectionFaultCategory.Pasif=true;
            var result = _sectionFaultCategoryService.Update(sectionFaultCategory);
            return Ok(result);
        }

        

        public IActionResult SectionFault()
        {
            return View();
        }

        [HttpGet]
        public object GetAllSectionFault(DataSourceLoadOptions loadOptions)
        {
            var sectionFault = _sectionFaultService.GetAll().Data.OrderByDescending(c=>c.SectionFaultId);
            return DataSourceLoader.Load(sectionFault, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddSectionFault(string values)
        {
            var sectionFault = new SectionFault();
            JsonConvert.PopulateObject(values, sectionFault);
            var result = _sectionFaultService.Add(sectionFault);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateSectionFault(int key, string values)
        {
            var sectionFault = _sectionFaultService.GetById(c=> c.SectionFaultId == key).Data;
            JsonConvert.PopulateObject(values, sectionFault);
            var result = _sectionFaultService.Update(sectionFault);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteSectionFault(int key)
        {
            var sectionFault = _sectionFaultService.GetAll(c => c.SectionFaultId == key).Data.FirstOrDefault();
            var result = _sectionFaultService.Update(sectionFault);
            return Ok(result);
        }

         public IActionResult Section()
        {
            return View();
        }

        [HttpGet]
        public object GetAllSection(DataSourceLoadOptions loadOptions)
        {
            var section = _sectionService.GetAll().Data;
            return DataSourceLoader.Load(section, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddSection(string values)
        {
            var section = new Section();
            JsonConvert.PopulateObject(values, section);
            var result = _sectionService.Add(section);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateSection(int key, string values)
        {
            var section = _sectionService.GetById(c=> c.SectionId == key).Data;
            JsonConvert.PopulateObject(values, section);
            var result = _sectionService.Update(section);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteSection(int key)
        {
            var section = _sectionService.GetAll(c => c.SectionId == key).Data.FirstOrDefault();
            section.Pasif = true;
            var result = _sectionService.Update(section);
            return Ok(result);
        }


    }
}