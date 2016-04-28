using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamiBot2
{
    public class USettings
    {
        public static string Token ()
        {
            return Properties.Settings.Default.Token;
        }

        public static string Roomid ()
        {
            return Properties.Settings.Default.RoomID;
        }

        public static string Userid()
        {
            return Properties.Settings.Default.UserID;
        }

        public static int answerpoint
        {
            get
            {
                return Properties.Settings.Default.AnswerPoint;
            }
            set
            {
                Properties.Settings.Default.AnswerPoint = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void saveSetting(string token, string roomid, string userid)
        {
            Properties.Settings.Default.Token = token;
            Properties.Settings.Default.RoomID = roomid;
            Properties.Settings.Default.UserID = userid;
            Properties.Settings.Default.Save();
        }

        public static int getUserPoint(string username)
        {
            if (File.Exists(@"Setting.io"))
            {
                var dictionary = Read(@"Setting.io");
                int value;
                if (dictionary.TryGetValue(username, out value))
                {
                    return value;
                }
                else
                {
                    CreateUser(username);
                    return 0;
                }
            }
            else
            {
                CreateUser("MamiBot");
                return 0;
            }
        }

        public static void addUserPoint(string username,int val)
        {
            if (File.Exists(@"Setting.io"))
            {
                var dictionary = Read(@"Setting.io");
                int value;

                if (dictionary.TryGetValue(username, out value))
                {
                    dictionary[username] += val;
                    Write(dictionary, @"Setting.io");
                }
                else
                {
                    CreateUser(username);
                    addUserPoint(username, val);
                }
            }
            else
            {
                CreateUser("MamiBot");
            }
        }

        public static void delUserPoint(string username, int val)
        {
            if (File.Exists(@"Setting.io"))
            {
                var dictionary = Read(@"Setting.io");
                dictionary[username] -= val;
                Write(dictionary, @"Setting.io");
            }
            else
            {
                CreateUser("MamiBot");
            }
        }

        public static void CreateUser(string username)
        {
            var dictionary = new Dictionary<string, int>();
            dictionary[username] = 0;
            Write(dictionary, @"Setting.io");
        }

        private static void Write(Dictionary<string, int> dictionary, string file)
        {
            using (FileStream fs = File.OpenWrite(file))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(dictionary.Count);
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }

        private static Dictionary<string,int> Read(string file)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            using (FileStream fs = File.OpenRead(file))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string keys = reader.ReadString();
                    int values = reader.ReadInt32();
                    result[keys] = values;
                }
            }
            return result;
        }
    }
}
