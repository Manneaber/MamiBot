using MamiBot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandJohn : SubCommand
    {
        public string Name
        {
            get
            {
                return "john";
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
            Mamichan.SendMessage(msg.disname + ": " + "http://on.fb.me/1HfQE5f");
            return true;
        }
    }
}
