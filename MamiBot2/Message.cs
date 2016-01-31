using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2
{
    public class Message
    {
        public Message(string sender, string DisName, Role role, string Msg, DateTime time)
        {
            this.Sender = sender;
            this.disname = DisName;
            this.UserRole = role;
            this.Msg = Msg;
            this.Time = time;
        }
        public string Sender;
        public string disname;
        public Role UserRole;
        public string Msg;
        public DateTime Time;

        [Flags]
        public enum Role
        {
            GUEST = 0,
            MEMBER = 1,
            ELITE = 3,
            SUBER = 4,
            MOD = 6,
            OWNER = 7,
            ADMIN = 8,
            BOT = 9

        }
    }
}
