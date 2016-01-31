using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandPoint : SubCommand
    {
        public string Name
        {
            get
            {
                return "point";
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
            Mamichan.SendMessage(msg.disname + ": " + "คุณมี point ทั้งหมด " + USettings.getUserPoint(msg.Sender));
            return true;
        }
    }
}
