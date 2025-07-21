using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Device.Driver.Concrete
{
    public class SerialDriver : IDriver<byte[]>
    {
        private SerialPort _port;
        public bool IsConnected => IsConnected;

        public event ValueTriggerEventHandler ValueTrigger;
        public event TerminatedEventHandler Terminated;

        public SerialDriver()
        {
            _port = new SerialPort();
        }

        public virtual bool Connecntion()
        {
            _port.Open();
            if (_port.IsOpen)
            {
                _port.DataReceived += OnDataReceived;
                _port.ErrorReceived += OnErrorReceived;
                _port.PinChanged += OnPinChanged;
            }
            return _port.IsOpen;
        }

        public virtual bool DisConnecntion()
        {
            _port.DataReceived -= OnDataReceived;
            _port.ErrorReceived -= OnErrorReceived;
            _port.PinChanged -= OnPinChanged;
            _port.Close();
            return _port.IsOpen;
        }

        public byte[] Receive()
        {
            throw new NotImplementedException();
        }

        public void Send(byte[] data)
        {
            _port.Write(data,0, data.Length);
        }

        protected void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //처리방식을 패턴 사용하여 적용 해보자 일단 이렇게만 구현
            int bytesToRead = _port.BytesToRead;

            if (bytesToRead > 0)
            {
                byte[] buffer = new byte[bytesToRead];
                int read = _port.Read(buffer, 0, bytesToRead); // offset: 0부터 전체 읽기

                if (read > 0)
                {
                    if (ValueTrigger != null)
                        ValueTrigger(this, buffer);
                }
            }
        }

        protected void OnErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (e.EventType == SerialError.Frame ||
                 e.EventType == SerialError.RXParity ||
                 e.EventType == SerialError.RXOver)
            {
                DisConnecntion();
                Terminated(null);
            }
        }
        protected void OnPinChanged(object sender, SerialPinChangedEventArgs e)
        {
            if (e.EventType == SerialPinChange.CDChanged)
            {
                DisConnecntion();
                Terminated(null);
            }
        }
    }
}
