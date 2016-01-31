using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MamiBot2.WS
{
    public class WSThreadWrapper
    {
        public Thread thread
        {
            get;
            set;
        }

        public MyliveWebsocket websocket
        {
            get;
            set;
        }

        public WSThreadWrapper(string roomid, string token, string userid)
        {
            thread = new Thread(() => this.websocket = new MyliveWebsocket(roomid, token, userid));
            thread.Start();
        }
    }
}
