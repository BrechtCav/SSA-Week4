using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.ViewModel;
using Webshop.Models;
using Webshop_BusinessLayer.Repositories;

namespace Webshop.Controllers
{
    [Authorize(Roles="Administrator")]
    public class ToevoegenController : Controller
    {
        public IGenericRepository<ProgrammingFramework> frameworkRepository;
        public IGenericRepository<Webshop.Models.OperatingSystem> OSRepository;
        public DeviceRepository DeviceRepository;
        // GET: Toevoegen
        [HttpGet]
        public ActionResult Index()
        {
            frameworkRepository = new GenericRepository<ProgrammingFramework>();
            OSRepository = new GenericRepository<Webshop.Models.OperatingSystem>();
            AddDeviceVM advm = new AddDeviceVM();
            advm.OperatingSystems = new List<Webshop.Models.OperatingSystem>(OSRepository.All());
            advm.Frameworks = new List<ProgrammingFramework>(frameworkRepository.All());
            return View(advm);
        }
        [HttpPost]
        public ActionResult Index(AddDeviceVM advm)
        {
            try
            {
                
                if(ModelState.IsValid)
                {
                    DeviceRepository = new DeviceRepository();
                    advm.NewDevice.OperatingSystems = new List<Models.OperatingSystem>();
                    if(advm.SelectedOS != null)
                    {
                        foreach (int id in advm.SelectedOS)
                            advm.NewDevice.OperatingSystems.Add(OSRepository.GetByID(id));
                    }
                    advm.NewDevice.Frameworks = new List<ProgrammingFramework>();
                    if (advm.SelectedFrameworks != null)
                    {
                        foreach (int id in advm.SelectedFrameworks)
                            advm.NewDevice.Frameworks.Add(frameworkRepository.GetByID(id));
                    }
                    DeviceRepository.AddDevice(advm.NewDevice);
                }
                return RedirectToAction("Index", "Cataloog");
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}