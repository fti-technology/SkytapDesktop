using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkytapApi
{
    public class Configuration
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Error { get; set; }
        public string RunState { get; set; }
    }
}
