using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.ViewModel
{
    public class AddDeviceVM
    {
        public AddDeviceVM()
        {

        }
        public AddDeviceVM(Device device)
        {
            this.NewDevice = device;
        }
        public Device NewDevice { get; set; }
        public List<Webshop.Models.OperatingSystem> OperatingSystems { get; set; }
        public List<int> SelectedOS { get; set; }
        public List<ProgrammingFramework> Frameworks { get; set; }
        public List<int> SelectedFrameworks { get; set; }
        
    }
}