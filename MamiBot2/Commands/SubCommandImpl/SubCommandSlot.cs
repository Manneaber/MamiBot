using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandSlot : SubCommand
    {
        public string Name
        {
            get
            {
                return "slot";
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
            int res = r.Next(0, 100);
            if (res == 5)
            {
                Mamichan.SendMessage(msg.disname + ": " + "ได้รับ 100P");
                USettings.addUserPoint(msg.Sender, 100);
            }
            else if (res == 54)
            {
                Mamichan.SendMessage(msg.disname + ": " + "ได้รับ 10P.");
                USettings.addUserPoint(msg.Sender, 10);
            }
            else if (res == 73)
            {
                Mamichan.SendMessage(msg.disname + ": " + "ได้รับ 50P.");
                USettings.addUserPoint(msg.Sender, 50);
            }
            else if (res == 80)
            {
                Mamichan.SendMessage(msg.disname + ": " + "ได้รับ 200P.");
                USettings.addUserPoint(msg.Sender, 200);
            }
            else if (res == 19)
            {
                Mamichan.SendMessage(msg.disname + ": " + "ได้รับ 350P.");
                USettings.addUserPoint(msg.Sender, 350);
            }
            else
            {
                Mamichan.SendMessage(msg.disname + ": " + "แย่จัง สุ่มไม่ได้อะไรเลย ลองใหม่วันหลังนะ");
            }
            return true;
        }
    }
}
