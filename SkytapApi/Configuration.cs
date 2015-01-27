using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkytapApi
{
    public class Configuration
    {
        public Configuration()
        {
            VMs = new BindingList<VirtualMachine>();
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Error { get; set; }
        public string RunState { get; set; }
        public BindingList<VirtualMachine> VMs { get; set; }
    }
}
