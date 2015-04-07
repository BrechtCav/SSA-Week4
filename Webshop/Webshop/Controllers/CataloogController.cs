using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;
using Webshop_BusinessLayer.Repositories;

namespace Webshop.Controllers
{
    public class CataloogController : Controller
    {
        public IGenericRepository<ProgrammingFramework> frameworkRepository;
        public IGenericRepository<Webshop.Models.OperatingSystem> OSRepository;
        // GET: Cataloog
        public ActionResult Index()
        {
            DeviceRepository repo = new DeviceRepository();
            List<Device> Devices = new List<Device>();
            List<Webshop.Models.OperatingSystem> test = new List<Models.OperatingSystem>();
            Devices = repo.GetDevices();
            return View(Devices);
        }
        public ActionResult Detail(int Id)
        {
            DeviceRepository repo = new DeviceRepository();
            Device Device = new Device();
            Device = repo.GetDevice(Id);
            return View(Device);
        }
    }
}