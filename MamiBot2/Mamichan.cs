using MamiBot2.Commands;
using MamiBot2.Commands.Impl;
using MamiBot2.Commands.SubCommandImpl;
using MamiBot2.WS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MamiBot2
{
    public class Mamichan
    {
        static List<Command> Commands = new List<Command>();
        static WSThreadWrapper WebsocketThread;
        public static Message.Role SelfRole = Message.Role.GUEST;
        private static string _mod;

        public static string Modlist
        {
            get { return _mod; }
            set { _mod = value; }
        }

        public void RunMamiBot(string a, string b, string c)
        {
            AddCommand();
            WebsocketThread = new WSThreadWrapper(a,b,c);
        }

        public static void ChatLog(string l)
        {
            Form1.main.UpdateChat = Environment.NewLine + DateTime.Now + " " + l;
        }

        public static void ViewLog(string l)
        {
            Form1.main.UpdateView = "Viewer: " + l;
        }

        public static void FavLog(string l)
        {
            Form1.main.UpdateFav = "Fav: " + l;
        }

        public static void InfoLog(string l)
        {
            Form1.main.UpdateInfo = Environment.NewLine + DateTime.Now + " [Log] " + l;
        }

        public static void ParseMessage(dynamic data)
        {
            Message msg = GetMessage(data);

            foreach (Command cmd in Commands)
            {
                if (msg.Msg.StartsWith(cmd.Trigger))
                {
                    cmd.Parse(msg);
                }
            }
            ChatLog((msg.Sender == msg.disname ? msg.Sender : msg.disname) + ": " + msg.Msg);
        }

        public static Message GetMessage(dynamic data)
        {
            string Sender = data.u;
            string DisName = data.n;
            string Msg = data.d;
            string StrRole = data.c;
            string time = data.t;
            Message.Role Role = ParseRole(StrRole);
            return new Message(Sender, DisName, Role, Msg, DateTime.Now);
        }

        public void AddCommand()
        {
            var Asterisk = new AsteriskCommand();
            Asterisk.RegisterSubCommand(new SubCommandAbout());
            Asterisk.RegisterSubCommand(new SubCommandJohn());
            Asterisk.RegisterSubCommand(new SubCommandGay());
            Asterisk.RegisterSubCommand(new SubCommandPoint());
            Asterisk.RegisterSubCommand(new SubCommandHelp());
            Commands.Add(Asterisk);
            Commands.Add(new ChatFilter());
        }

        public static Message.Role ParseRole(string Role)
        {
            Message.Role EnumRole = Message.Role.GUEST;
            switch (Role)
            {
                case "9":
                    EnumRole = Message.Role.BOT;
                    break;
                case "8":
                    EnumRole = Message.Role.ADMIN;
                    break;
                case "7":
                    EnumRole = Message.Role.OWNER;
                    break;
                case "6":
                    EnumRole = Message.Role.MOD;
                    break;
                case "4":
                    EnumRole = Message.Role.SUBER;
                    break;
                case "3":
                    EnumRole = Message.Role.ELITE;
                    break;
                case "1":
                    EnumRole = Message.Role.MEMBER;
                    break;
                case "0":
                    EnumRole = Message.Role.GUEST;
                    break;
                default:
                    break;
            }
            return EnumRole;
        }

        public static void SendMessage(string MSG)
        {
            try
            {
                WebsocketThread.websocket.SendMessage(MSG);
            }
            catch (NullReferenceException ex)
            {
                InfoLog(ex.Message);
            }
        }
    }
}
