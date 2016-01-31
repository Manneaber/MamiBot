using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandGay : SubCommand
    {
        public string Name
        {
            get
            {
                return "gay";
            }
        }

        public Message.Role AccessLevel
        {
            get
            {
                return Message.Role.MEMBER;
            }
        }
        public bool Parse(Message msg, string[] args)
        {
            Random r = new Random();
            Mamichan.SendMessage(msg.disname + ": " + "Your gay level is " + r.Next(0, 101));
            return true;
        }
    }
}
