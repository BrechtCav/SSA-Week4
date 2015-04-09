using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Models;
using Webshop_BusinessLayer.Repositories;

namespace Webshop_BusinessLayer.Services
{
    public class ProductService : Webshop_BusinessLayer.Services.IProductService
    {
        private IGenericRepository<Webshop.Models.OperatingSystem> repoOS = null;
        private IGenericRepository<ProgrammingFramework> repoFramework = null;
        private IDeviceRepository repoDevice = null;

        public ProductService(
            IGenericRepository<Webshop.Models.OperatingSystem> repoOS,
            IGenericRepository<ProgrammingFramework>repoFramework,
            IDeviceRepository repoDevice)
        {
            this.repoOS = repoOS;
            this.repoFramework = repoFramework;
            this.repoDevice = repoDevice;
        }
        public List<Device> GetAllDevices()
        {
            return repoDevice.All().ToList<Device>();
        }
        public Device GetDeviceById(int id)
        {
            return repoDevice.GetByID(id);
        }
        public void AddDevice(Device nd)
        {
           repoDevice.AddDevice(nd);
        }
        public void UpdatePicture(int deviceId, HttpPostedFileBase picture)
        {
            Device device = GetDeviceById(deviceId);
            repoDevice.UpdatePicture(device);
        }
        public List<Webshop.Models.OperatingSystem> GetAllOperatingSystems()
        {
            return repoOS.All().ToList<Webshop.Models.OperatingSystem>();
        }
        public Webshop.Models.OperatingSystem GetOSById(int Id)
        {
            return repoOS.GetByID(Id);
        }
        public List<ProgrammingFramework> GetAllFrameworks()
        {
            return repoFramework.All().ToList<ProgrammingFramework>();
        }
        public ProgrammingFramework GetFrameworkById(int id)
        {
            return repoFramework.GetByID(id);
        }
    }
}