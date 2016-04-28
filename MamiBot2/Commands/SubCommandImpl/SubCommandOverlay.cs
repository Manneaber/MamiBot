using MamiBot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandOverlay : SubCommand
    {

        public string Name
        {
            get
            {
                return "overlay";
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
            Mamichan.SendMessage("Overlay cmd");
            return true;
        }
    }
}
