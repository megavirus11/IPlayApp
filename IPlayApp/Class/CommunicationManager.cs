using System;
using System.Diagnostics;
using System.Linq;

namespace IPlayApp.Class
{
    internal class CommunicationManager
    {
        private static CommunicationManager _mInstance;
        private string _data;

        public static CommunicationManager GetInstance()
        {
            return _mInstance ?? (_mInstance = new CommunicationManager());
        }

        public void SendData()
        {
            Debug.WriteLine(_data);
            _data = null;
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
    }
}