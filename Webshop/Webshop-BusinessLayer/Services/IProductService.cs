using System;
namespace Webshop_BusinessLayer.Services
{
    public interface IProductService
    {
        void AddDevice(Webshop.Models.Device nd);
        System.Collections.Generic.List<Webshop.Models.Device> GetAllDevices();
        System.Collections.Generic.List<Webshop.Models.ProgrammingFramework> GetAllFrameworks();
        System.Collections.Generic.List<Webshop.Models.OperatingSystem> GetAllOperatingSystems();
        Webshop.Models.Device GetDeviceById(int id);
        Webshop.Models.ProgrammingFramework GetFrameworkById(int id);
        Webshop.Models.OperatingSystem GetOSById(int Id);
        void UpdatePicture(int deviceId, System.Web.HttpPostedFileBase picture);
    }
}
