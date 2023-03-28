using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.ViewModels;
using Bakim.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Bakim.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Bakim.Controllers
{
    [Authorize]
    public class VarlikController : Controller
    {

        private readonly IDetayGroupService _detayGroupService;
        private readonly ITedarikciFirmaService _tedarikciFirmaService;
        private readonly IStockService _stockService;
        private readonly IStokKategoriService _stokKategoriService;
        private readonly IFileService _fileService;
        private readonly IVarlikGroupService _varlikGroupService;
        private readonly IProductionSectionService _productionSectionService;
        private readonly IVarlikService _varlikService;
        private readonly IStockGroupService _stockGroupService;
        private readonly IStok_FirmaService _stok_FirmaService;




        public VarlikController(IDetayGroupService detayGroupService, ITedarikciFirmaService tedarikciFirmaService, IStockService stockService, IStokKategoriService stokKategoriService, IFileService fileService, IVarlikGroupService varlikGroupService, IProductionSectionService productionSectionService, IVarlikService varlikService, IStockGroupService stockGroupService, IStok_FirmaService stok_FirmaService)
        {
            _detayGroupService = detayGroupService;
            _tedarikciFirmaService = tedarikciFirmaService;
            _stockService = stockService;
            _stokKategoriService = stokKategoriService;
            _fileService = fileService;
            _varlikGroupService = varlikGroupService;
            _productionSectionService = productionSectionService;
            _varlikService = varlikService;
            _stockGroupService = stockGroupService;
            _stok_FirmaService = stok_FirmaService;
        }

        public IActionResult VarlikListe(int filter = 2)
        {
             if(filter == 2 || filter == null)
            {
                ViewData["Name"] = "Tümünü Görüntülüyorsunuz";  
            }

            else if(filter == 1)
            {
               ViewData["Name"] = "Aktifleri Görüntülüyorsunuz";
            }
            else if(filter == 0)
            {
               ViewData["Name"] = "Pasifleri Görüntülüyorsunuz";
            }

            return View("VarlikListe",filter);
        }

        public IActionResult StokListe(int filter = 2)
        {

            if(filter == 2 || filter == null || filter == 0)
            {
                ViewData["Name"] = "Tümünü Görüntülüyorsunuz";  
            }

            else if(filter == 1)
            {
               ViewData["Name"] = "Aktifleri Görüntülüyorsunuz";
            }
            else if(filter == 10)
            {
               ViewData["Name"] = "Pasifleri Görüntülüyorsunuz";
            }

            return View("StokListe", filter);
        }

        public IActionResult StokDetay(int id)
        {
            var stok = _stockService.GetById(c=> c.StockId == id).Data;
            var model = new StokDetayViewModel()
            {
                stok = stok,
                
                stokgrubu = _stockGroupService.GetAll(c=> c.StockGroupId == stok.StockGroupId).Data.FirstOrDefault(),
                stokKategori = _stokKategoriService.GetAll(c=> c.StokKategoriId == stok.StokKategoriId).Data.FirstOrDefault(),
                uretimbolumu = _productionSectionService.GetMachineGroups().Data.FirstOrDefault(),
                stokfirmalar = _stok_FirmaService.GetAll(c=> c.StockId == id).Data,
                firmalar = new()
                

            };

            foreach(var item in model.stokfirmalar)
            {
                model.firmalar.Add(_tedarikciFirmaService.GetAll(c=>c.FirmaId == item.FirmaId).Data.First());
            }
                
            return View(model);
        }

        public IActionResult VarlikDetay(int id)
        {
            var varlik = _varlikService.GetById(c => c.VarlikId == id).Data;
            var model = new VarlikDetayViewModel()
            {
                varlik = varlik,
                DetayGrubu = _detayGroupService.GetAll(c => c.DetayGroupId == varlik.DetayGroupId).Data.FirstOrDefault(),
                UretimBolumu = _productionSectionService.GetMachineGroups().Data.FirstOrDefault(),
                varlikGrubu = _varlikGroupService.GetAll(c=>c.VarlikGroupId == varlik.VarlikGroupId).Data.FirstOrDefault()
            };
            return View(model);
        }

        public IActionResult EditVarlik(int? id)
        {
            var vm = new EditVarlikViewModel()
            {
                varlik = _varlikService.GetAll(c => c.VarlikId == id).Data.FirstOrDefault(),
                varlikkategorisi = _detayGroupService.GetAll().Data.FirstOrDefault(),
                Uretimbolumu = _productionSectionService.GetMachineGroups().Data,
                VarlikGruplari = _varlikGroupService.GetAll().Data,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult EditVarlik(IFormFile file, Varlik varlik,int id)
        {
            var varliks = _varlikService.GetById(c => c.VarlikId == id);

            if(varlik == null)
            {
                return NotFound();
            }

            if(varlik != null)
            {

                varliks.Data.VarlikName = varlik.VarlikName;
                varliks.Data.VarlikCode =  varlik.VarlikCode;
                varliks.Data.ImagePath =  varlik.ImagePath;
                varliks.Data.VarlikGroupId =  varlik.VarlikGroupId;
                varliks.Data.DetayGroupId =  varlik.DetayGroupId;
                varliks.Data.CorporationId =  varlik.CorporationId;
                varliks.Data.ProductionSectionId =  varlik.ProductionSectionId;
                varliks.Data.InUse = varlik.InUse;
                varliks.Data.Pasif = varlik.Pasif;
            }


            if (varliks == null)
            {
                return NotFound();
            }
            _varlikService.Update(varliks.Data);
            _fileService.AddForVarlik(file, varliks.Data);

            return RedirectToAction("VarlikListe");
        }






        [HttpGet]
        public object VarlikListesi(DataSourceLoadOptions loadOptions,int? id = null)
        {
            List<Varlik> model = new List<Varlik>();
            if(id == 2 || id ==  null)
            {
            model = _varlikService.GetAll().Data.OrderByDescending(d=>d.UploadDate).ToList();
            }

            if(id == 1)
            {
            model = _varlikService.GetAll(c=> c.Pasif == false).Data.OrderByDescending(d=>d.UploadDate).ToList();
            }

            if(id == 0)
            {
            model = _varlikService.GetAll(c=> c.Pasif == true).Data.OrderByDescending(d=>d.UploadDate).ToList();
            }
            
            model.ForEach(c => c.DetayGroup = _detayGroupService.GetAll(k => k.DetayGroupId == c.DetayGroupId).Data.FirstOrDefault());
            model.ForEach(c => c.VarlikGroup = _varlikGroupService.GetAll(k => k.VarlikGroupId == c.VarlikGroupId).Data.FirstOrDefault());
            return DataSourceLoader.Load(model, loadOptions);
        }

        [HttpGet]
        public object DetayGruplari(DataSourceLoadOptions loadOptions)
        {
            var model = _detayGroupService.GetAll().Data;
            return DataSourceLoader.Load(model, loadOptions);

        }



        public IActionResult EditStock(int? id)
        {
            var model = new EditStockViewModel()
            {
               stok = _stockService.GetById(c=> c.StockId == id).Data,
               stokGruplari = _stockGroupService.GetAll().Data,
               stokKategori = _stokKategoriService.GetAll().Data.FirstOrDefault(),
               stokfirma = _stok_FirmaService.GetAll(c=> c.StockId == id).Data,
               firmalar = _tedarikciFirmaService.GetAll().Data
            };

            return View(model);

        }

        [HttpPost]
        public IActionResult EditStock(IFormFile file, Stock stock, int id,int[] FirmaIds)
        {

            var aratablo = _stok_FirmaService.GetAll(c=> c.StockId == id).Data;
            var stoklar = _stockService.GetById(c => c.StockId == id);

             foreach(var item in aratablo)
            {
                _stok_FirmaService.Delete(item);

            }

            foreach(var item in FirmaIds)
            {
                _stok_FirmaService.Add(new(){
                    FirmaId = item,
                    StockId = stoklar.Data.StockId
                    
                });
            }

            if(stock == null)
            {
                return NotFound();
            }
            else 
            {
                stoklar.Data.StockName = stock.StockName;
                stoklar.Data.StockCode = stock.StockCode;
                stoklar.Data.Price = stock.Price;
                stoklar.Data.ImagePath = stock.ImagePath;
                stoklar.Data.MinStock = stock.MinStock;
                stoklar.Data.MaxStock = stock.MaxStock;
                stoklar.Data.Barcode = stock.Barcode;
                stoklar.Data.StokKategoriId = stock.StokKategoriId;
                stoklar.Data.StockGroupId = stock.StockGroupId;
                stoklar.Data.StockAmount = stock.StockAmount;
                stoklar.Data.CorporationId = stock.CorporationId;
                stoklar.Data.Pasif = stock.Pasif;
            }

            _stockService.Update(stoklar.Data);
            _fileService.AddForStock(file, stoklar.Data);

            return RedirectToAction("StokListe");
        }


 
        [HttpGet]
        public object StokListesi(DataSourceLoadOptions loadOptions, int? id = 2)
        {
           
            var vm = new List<StokListe>();

            List<Stock> model = new List<Stock>();
            if(id == 2 || id == null || id == 0)
            {
                model = _stockService.StockList().Data.OrderByDescending(d=>d.UploadDate).ToList();
            }
            else if(id == 1)
            {
                model = _stockService.StockList(c=> c.Pasif == false).Data.OrderByDescending(d=>d.UploadDate).ToList();
            }
            else if(id == 10)
            {
                model = _stockService.StockList(c=> c.Pasif == true).Data.OrderByDescending(d=>d.UploadDate).ToList();
            }

            model.ForEach(c => c.stokKategori = _stokKategoriService.GetAll(k => k.StokKategoriId == c.StokKategoriId).Data.FirstOrDefault());
            model.ForEach(c => c.stokGrubu = _stockGroupService.GetAll(k => k.StockGroupId == c.stokKategori.StockGroupId).Data.FirstOrDefault());

            foreach (var item in model)
            {
                var stok = new StokListe();
                stok.tedarikciFirmalar = new();
                stok.stock = item;
                var stokfirma = _stok_FirmaService.GetAll(c => stok.stock.StockId == c.StockId).Data;

                if (stokfirma.Count() != 0)
                {

                    foreach (var item2 in stokfirma)
                    {
                        stok.tedarikciFirmalar.Add(_tedarikciFirmaService.GetAll(c => c.FirmaId == item2.FirmaId).Data.FirstOrDefault());
                    }
                    vm.Add(stok);
                }
                else
                {
                    stok.tedarikciFirmalar.Add(new());
                    vm.Add(stok);
                }

            }
            return DataSourceLoader.Load(vm, loadOptions);
        }

        [HttpGet]
        public object StokKategorileri(DataSourceLoadOptions loadOptions)
        {
            var model = _stokKategoriService.GetAll().Data;
            return DataSourceLoader.Load(model, loadOptions);
        }

        [HttpGet]
        public object FirmaGetir(DataSourceLoadOptions loadOptions)
        {
            var model = _tedarikciFirmaService.GetAll().Data;
            return DataSourceLoader.Load(model, loadOptions);
        }

    }
}