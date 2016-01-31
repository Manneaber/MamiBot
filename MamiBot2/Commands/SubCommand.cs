using MamiBot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands
{
    public interface SubCommand
    {

        string Name
        {
            get;
        }

        Message.Role AccessLevel
        {
            get;
        }

        bool Parse(Message Msg, string[] args);
    }
}
