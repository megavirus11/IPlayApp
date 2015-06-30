using System;
using System.Diagnostics;
using System.Linq;
using IPlayApp.Webservices;
using Xamarin.Forms;

namespace IPlayApp.Class
{
    internal class CommunicationManager
    {
        private static CommunicationManager _mInstance;
        private string _data;
        private Stopwatch _stopwatch;

        public static CommunicationManager GetInstance()
        {
            return _mInstance ?? (_mInstance = new CommunicationManager());
        }

        public void SendData()
        {
            Debug.WriteLine(_data);
            SendDataToApi();
            _data = null;
        }

        private async void SendDataToApi()
        {
            await ServiceBusApi.Send();
        }

        public void AddData(string data)
        {
            _data += string.Format(" {0}", data);
        }

        public void DeleteData()
        {
            if (!string.IsNullOrEmpty(_data))
            {
                string[] items = _data.Split(' ');
                if (items.Length > 0)
                    _data = String.Join(" ", items.Take(items.Length - 1));
            }
        }

        public void StartTimer()
        {
            if(!_stopwatch.IsRunning)
            _stopwatch.Start();

        }

        public void ResetTimer()
        {
            if (_stopwatch.IsRunning)
                _stopwatch.Reset();
        }

        public void StopTimer()
        {
            if (_stopwatch.IsRunning)
                _stopwatch.Stop();
        }

    }
}