using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Webshop_BusinessLayer.Context;
using Webshop.Models;
namespace Webshop_BusinessLayer.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public List<Device> GetDevices()
        {
            var query = (from d in context.Devices.Include(d => d.Frameworks)
                                                 .Include(d => d.OperatingSystems)
                         select d);
            return query.ToList<Device>();

        }
        public Device GetDevice(int id)
        {
            var query = (from d in context.Devices.Include(d => d.Frameworks)
                                                 .Include(d => d.OperatingSystems)
                         where d.ID == id
                         select d);
            return query.Single<Device>();
        }
        public void AddDevice(Device device)
        {
            foreach (Webshop.Models.OperatingSystem os in device.OperatingSystems)
            {
                context.OperatingSystems.Add(os);
                context.Entry<Webshop.Models.OperatingSystem>(os).State = EntityState.Unchanged;
            }
            foreach (ProgrammingFramework fr in device.Frameworks)
            {
                context.Frameworks.Add(fr);
                context.Entry<ProgrammingFramework>(fr).State = EntityState.Unchanged;
            }
            context.Devices.Add(device);
            context.SaveChanges();
        }
        public void UpdatePicture(Device d)
        {
            Device od = context.Devices.Find(d.ID);
            od.Picture = d.Picture;
            context.SaveChanges();
        }
    }
}