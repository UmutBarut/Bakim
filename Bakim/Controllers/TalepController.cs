using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakim.Business.Abstracts;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Bakim.Entity;
using Bakim.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bakim.Controllers
{
    [Authorize]

    public class TalepController : Controller
    {
        private readonly ITalepService _talepService;
        private readonly ITedarikciFirmaService _tedarikciFirmaService;
        private readonly IStockService _stockService;
        private readonly IBirimService _birimService;
        private readonly IVarlikService _varlikService;
        private readonly UserManager<ApplicationUser> _userManager;


        public TalepController(ITalepService talepService, ITedarikciFirmaService tedarikciFirmaService, IStockService stockService,IBirimService birimService,IVarlikService varlikService,UserManager<ApplicationUser> userManager)
        {
            _talepService = talepService;
            _tedarikciFirmaService = tedarikciFirmaService;
            _stockService = stockService; 
            _birimService = birimService;
            _varlikService = varlikService;
            _userManager = userManager;
        }


        public IActionResult SatinAlimTalepleri(int filter =2)
        {
            TalepViewModel vm = new TalepViewModel()
            {
                firmalar = _tedarikciFirmaService.GetAll().Data,
                stoklar = _stockService.StockList().Data,
                birimler = _birimService.GetAll().Data,
                varliklar = _varlikService.GetAll().Data,
                Filter = filter
            };

             if(filter == 2 || filter == null)
            {
                ViewData["Name"] = "Tüm Talepleri Görüntülüyorsunuz";
            }

            else if(filter == 1)
            {
                ViewData["Name"] = "Onaylanan Talepleri Görüntülüyorsunuz";
            }
            else if(filter == 10)
            {
                ViewData["Name"] = "Onaylanmayan Talepleri Görüntülüyorsunuz";
            }
            else if(filter == 5)
            {
                ViewData["Name"] = "Tamamlanan Talepleri Görüntülüyorsunuz";
            }

            return View(vm);
        }

        [HttpGet]
        public object Talepler(DataSourceLoadOptions loadOptions, int? id = null)
        {
            List<Talep> model = new List<Talep>();

            model = model.GroupBy(g=>g.TalepId).Select(s=> new Talep
            {
                TalepId = s.Key,
                TalepAdi = s.First().TalepAdi.Replace("ı", "i").Replace("İ", "I").Replace("Ğ", "G").Replace("ğ", "g").Replace("ş", "s").Replace("Ü", "U").Replace("Ş", "S").Replace("ç","c").Replace("Ç","C"),
                CreatorId = s.First().CreatorId?.Replace("ı", "i").Replace("İ", "I").Replace("Ğ", "G").Replace("ğ", "g").Replace("ş", "s").Replace("Ü", "U").Replace("Ş", "S").Replace("ç","c").Replace("Ç","C"),
                StockId = s.First().StockId,
                VarlikId = s.First().VarlikId,
                Miktar = s.First().Miktar, 
                Olcu = s.First().Olcu,
                BirimId = s.First().BirimId,
                Aciklama = s.First().Aciklama?.Replace("ı", "i").Replace("İ", "I").Replace("Ğ", "G").Replace("ğ", "g").Replace("ş", "s").Replace("Ü", "U").Replace("Ş", "S").Replace("ç","c").Replace("Ç","C"),
                FirmaId = s.First().FirmaId,
                CreatedDate = s.First().CreatedDate,
                IsApproved = s.First().IsApproved,
                ApproveDate = s.First().ApproveDate,
                IsFinished = s.First().IsFinished,
                FinishDate = s.First().FinishDate

            }).ToList();



            if(id == 2 || id == null || id == 0)
            {   
                model = _talepService.GetAll().Data.OrderByDescending(d=>d.CreatedDate).ToList();
            } 

            if(id == 1)
            {
                model = _talepService.GetAll(c=> c.IsApproved == true && c.IsFinished == false).Data.OrderByDescending(d=> d.CreatedDate).ToList();
            }

            if(id == 10)
            {
                model = _talepService.GetAll(c=> c.IsApproved == false).Data.OrderByDescending(d=>d.CreatedDate).ToList();;
            }
            if(id == 5)
            {
                model = _talepService.GetAll(c=> c.IsFinished == true).Data.OrderByDescending(d=>d.CreatedDate).ToList();
            }

            return DataSourceLoader.Load(model.OrderByDescending(d=>d.CreatedDate).ToList(), loadOptions);
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Confirmation( Talep talep,string descriminator, bool durum=false){
            var taleptoupdate = _talepService.GetById(c=>c.TalepId == talep.TalepId).Data;
            
            taleptoupdate.TalepAdi = talep.TalepAdi;
            taleptoupdate.StockId = talep.StockId;
            taleptoupdate.VarlikId = talep.VarlikId;
            taleptoupdate.Miktar = talep.Miktar;
            taleptoupdate.Olcu = talep.Olcu;
            taleptoupdate.BirimId = talep.BirimId;
            taleptoupdate.Aciklama = talep.Aciklama;
            taleptoupdate.FirmaId = talep.FirmaId;
            taleptoupdate.IsApproved = talep.IsApproved;
            taleptoupdate.ApproveDate = talep.ApproveDate;
            
            if(descriminator != "edit"){
                taleptoupdate.IsApproved = true;
                taleptoupdate.ApproveDate = DateTime.Now;
            }
            _talepService.Update(taleptoupdate);
            return RedirectToAction("SatinAlimTalepleri");
        }



        [HttpPost]
        public IActionResult TalebiSonlandir(int id)
        {
            var talep = _talepService.GetById(c=> c.TalepId == id).Data;

                if(talep != null)
                {


                talep.IsFinished = true;
                talep.FinishDate = DateTime.Now; 

                _talepService.Update(talep);
                }

            return RedirectToAction("SatinAlimTalepleri");
        }


        [HttpPost]
        public IActionResult TalebiSil(Talep talep)
        {
            var talepler =  _talepService.GetById(c=>c.TalepId == talep.TalepId);

            if(talepler != null)
            {
            _talepService.Delete(talep);
            }

            return RedirectToAction("SatinAlimTalepleri");
        }


        [HttpGet]
        public async Task<TalepInfoWithUser> TalepGetir(int id)
        {
            TalepInfoWithUser model = new(){
                talep = _talepService.GetById(c=>c.TalepId == id).Data,
                user = await _userManager.FindByIdAsync(_talepService.GetById(c=> c.TalepId == id).Data.CreatorId)
            };
            return model;
        }

        public IActionResult TalepOlustur()
        {
            TalepViewModel vm = new TalepViewModel()
            {
                firmalar = _tedarikciFirmaService.GetAll().Data,
                stoklar = _stockService.StockList().Data,
                birimler = _birimService.GetAll().Data,
                varliklar = _varlikService.GetAll().Data
                
            };

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> TalepOlustur(Talep talep)
        {
           var user = await _userManager.GetUserAsync(HttpContext.User);

           talep.CreatorId = user.Id; 
           talep.CreatedDate = DateTime.Now;

            _talepService.Add(talep);
            
            return RedirectToAction("SatinAlimTalepleri");
        }

        [HttpGet]
        public object GetAllTalepStok(DataSourceLoadOptions loadOptions)
        {
            var result = _stockService.StockList().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpGet]
        public object GetAllTalepBirim(DataSourceLoadOptions loadOptions)
        {
            var result = _birimService.GetAll().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }

        [HttpGet]
        public object GetAllTalepVarlik(DataSourceLoadOptions loadOptions)
        {
            var result = _varlikService.GetAll().Data;
            return DataSourceLoader.Load(result, loadOptions);
        }
        
        public async Task<TalepViewModel> GetConfirmModal()
        {
            var vm = new TalepViewModel()
            {
                stoklar = _stockService.StockList().Data,
                firmalar = _tedarikciFirmaService.GetAll().Data,
                birimler = _birimService.GetAll().Data,
                varliklar = _varlikService.GetAll().Data
            };

            return vm;
        }

    }
}