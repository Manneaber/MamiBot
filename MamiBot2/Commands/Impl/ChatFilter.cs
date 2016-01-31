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
                case "Test":
                    Mamichan.SendMessage(":D");
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
