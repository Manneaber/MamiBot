using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2.Commands.Impl
{
    public class AsteriskCommand : CommandImpl
    {
        public override string Trigger
        {
            get
            {
                return "!";
            }
        }
    }
}
