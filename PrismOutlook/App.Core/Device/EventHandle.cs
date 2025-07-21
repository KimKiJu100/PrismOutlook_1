using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Device
{
    public delegate void ValueTriggerEventHandler(object sender, object data);
    public delegate void TerminatedEventHandler(object sender);
}
