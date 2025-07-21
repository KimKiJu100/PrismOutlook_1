using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Device.Driver
{
    public interface IDriverTransceiver<T>
    {
        void Send(T data);
        T Receive();
    }
}
