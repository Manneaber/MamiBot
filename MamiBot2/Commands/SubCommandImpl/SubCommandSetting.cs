using MamiBot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.SubCommandImpl
{
    public class SubCommandSetting : SubCommand
    {

        public string Name
        {
            get
            {
                return "setting";
            }
        }

        public Message.Role AccessLevel
        {
            get
            {
                return Message.Role.OWNER;
            }
        }
        public bool Parse(Message msg, string[] args)
        {
            try
            {
                if (args[0] == "set")
                {
                    switch (args[1])
                    {
                        case "anspoint":
                            int num;
                            bool isNum = Int32.TryParse(args[2], out num);
                            if (isNum)
                            {
                                USettings.answerpoint = num;
                                Mamichan.SendMessage("Set Answer point to " + USettings.answerpoint);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Mamichan.InfoLog(e.ToString());
            }

            return true;
        }
    }
}
