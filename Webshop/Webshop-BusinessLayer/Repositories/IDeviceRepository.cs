using System;
using Webshop.Models;
namespace Webshop_BusinessLayer.Repositories
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        void AddDevice(Webshop.Models.Device device);
        void UpdatePicture(Webshop.Models.Device d);
    }
}
