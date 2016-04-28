using MamiBot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.Impl
{
    public class ChatFilter : CommandImpl
    {
        public override string Trigger
        {
            get
            {
                return String.Empty;
            }
        }
        
        public override bool Parse(Message msg)
        {
            switch(msg.Msg)
            {
                case "เกมอะไรครับ":
                    Mamichan.SendMessage("ให้ทาย");
                    break;
                case "ให้ทาย":
                    Mamichan.SendMessage("ยอมแล้วเฉลยที");
                    break;
                case "สวัสดีครับ":
                    Mamichan.SendMessage("สวัสดีครับ");
                    break;
                case "สวัสดีค่ะ":
                    Mamichan.SendMessage("สวัสดีค่ะ");
                    break;
                case "ใคร":
                    Mamichan.SendMessage("แน่นอนว่าไม่ใช่มามิบอท");
                    break;
                case "ปลาอะไรใช้แล้ว":
                    Mamichan.SendMessage("KappaPride");
                    break;
                case "ขอ ip หน่อยครับ":
                    Mamichan.SendMessage("อ่านคำอธิบายกลุ่มด้วยครับ");
                    break;
                case "ใครเป็นเกย์":
                    Mamichan.SendMessage("ต๊วงเกย์");
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
