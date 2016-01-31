using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Quobject.EngineIoClientDotNet.Modules;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Socket = Quobject.SocketIoClientDotNet.Client.Socket;
using System.Diagnostics;

namespace MamiBot2.WS
{
    public class MyliveWebsocket
    {
        public string user;
        public string token;
        public string room;

        public ManualResetEvent ManualResetEvent = null;
        public Socket socket;
        public string Message;

        public MyliveWebsocket(string roomid, string token, string userid)
        {
            this.user = userid;
            this.token = token;
            this.room = roomid;
            Mamichan.InfoLog("Start");
            ManualResetEvent = new ManualResetEvent(false);
            socket = IO.Socket("http://mylive.in.th:3000");
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Mamichan.InfoLog("Connecting");

                var obj = new Newtonsoft.Json.Linq.JObject();
                obj["user"] = user;
                obj["token"] = token;
                obj["room"] = room;
                socket.Emit("authen", obj);
                Mamichan.InfoLog("HandShake Success");
                ManualResetEvent.Set();
            });

            socket.On("connected",
                (res) =>
                {
                    dynamic json = Newtonsoft.Json.Linq.JObject.Parse(res.ToString());
                    Mamichan.InfoLog("Welcome: " + json.n);
                    ManualResetEvent.Set();
                });

            socket.On("msg",
                (msg) =>
                {
                    dynamic json = Newtonsoft.Json.Linq.JObject.Parse(msg.ToString());
                    Mamichan.ParseMessage(json);
                    ManualResetEvent.Set();
                });

            socket.On(Socket.EVENT_DISCONNECT,
                (data) =>
                {
                    Mamichan.InfoLog("Disconnected");
                    Message = (string)data;
                    ManualResetEvent.Set();
                });

            socket.On("cnt",
                (num) =>
                {
                    Mamichan.ViewLog(num.ToString());
                    ManualResetEvent.Set();
                });

            socket.On("fav",
                (data) =>
                {
                    Mamichan.FavLog(data.ToString());
                    ManualResetEvent.Set();
                });

            socket.On("mod", 
                (mod) => 
                {
                    Mamichan.Modlist = mod.ToString();
                    ManualResetEvent.Set();
                });

            ManualResetEvent.WaitOne();
        }

        public void SendMessage(string text)
        {
            var obj = new Newtonsoft.Json.Linq.JObject();
            obj["d"] = text;
            socket.Emit("msg", obj);
        }


    }
}
