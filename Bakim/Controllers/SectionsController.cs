using Bakim.Business.Abstracts;
using Bakim.Entity;
using Bakim.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakim.Controllers
{
    [Authorize]
    public class SectionsController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly ISectionFaultService _sectionFaultService;

        public SectionsController(ISectionService sectionService, ISectionFaultService sectionFaultService)
        {
            _sectionService = sectionService;
            _sectionFaultService = sectionFaultService;
        }


        public IActionResult Index(bool success = true)
        {
            var result = _sectionService.GetAll();
            var faults = _sectionFaultService.GetAll();
            SectionViewModel sectionViewModel = new SectionViewModel()
            {
                SectionFaults = faults.Data,
                Sections = result.Data
            };
            ViewData["Title"] = "Birimler";
            return View((sectionViewModel, success));
        }

        public IActionResult AddSection(Section section)
        {
            _sectionService.Add(section);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSection(int sectionId)
        {
            var item = _sectionService.GetById(sectionId);
            try
            {
                var result = _sectionService.Delete(item.Data);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { success = false });
            }




            return RedirectToAction("Index", new { success = true });
        }

        public IActionResult AddSectionFault(SectionFault sectionFault)
        {
            _sectionFaultService.Add(sectionFault);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteSectionFault(int sectionFaultId)
        {
            var item = _sectionFaultService.GetById(sectionFaultId);
            try
            {
                var result = _sectionFaultService.Delete(item.Data);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { success = false });
            }

            return RedirectToAction("Index", new { success = true });
        }
    }
}
