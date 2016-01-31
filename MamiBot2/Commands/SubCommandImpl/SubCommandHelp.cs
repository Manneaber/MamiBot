using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandHelp : SubCommand
    {
        public string Name
        {
            get
            {
                return "help";
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
            Mamichan.SendMessage("!slot, !point, !overlay, !john, !help, !gay, !about");
            return true;
        }
    }
}
