using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class PECommunicationEventArgs : EventArgs
    {
        private string _response;

        public PECommunicationEventArgs(string response)
        {
            _response = response;
        }

        public string response
        {
            get { return _response; }
        }
    }
}
