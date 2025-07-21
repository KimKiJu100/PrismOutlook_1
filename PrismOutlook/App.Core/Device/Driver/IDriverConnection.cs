using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Device.Driver
{
    public interface IDriverConnection
    {
        /// <summary>
        /// 연결상태
        /// </summary>
        public bool IsConnected { get; }
        /// <summary>
        /// 연결 로직
        /// </summary>
        /// <returns>성공 true 실패 false</returns>
        public bool Connecntion();
        /// <summary>
        /// 해제 로직 
        /// </summary>
        /// <returns>해제 성공 true 해제 실패 false</returns>
        public bool DisConnecntion();
    }
}
