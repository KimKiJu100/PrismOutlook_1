using App.Core.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace App.Core.Devices.Driver.Parameter
{
    public class SerialParameter : IDriverParameter
    {
        public string PortName { get; set; }
        public int baudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
    }
}
