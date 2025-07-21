namespace App.Core.Device.Driver
{
    public interface IDriver<TRawDataFormat> : IDriverConnection, IDriverTransceiver<TRawDataFormat>
    {
        /// <summary>
        /// 값이 발생되면  이벤트
        /// </summary>
        public event ValueTriggerEventHandler ValueTrigger;

        /// <summary>
        /// 통신 연결이 끊어졌을 때 발생되는 이벤트
        /// </summary>
        event TerminatedEventHandler Terminated;
    }
}
