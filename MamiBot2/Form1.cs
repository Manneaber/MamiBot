using MamiBot2.WS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MamiBot2
{
    public partial class Form1 : Form
    {
        internal static Form1 main;
        internal string UpdateInfo
        {
            set
            {
                if (InfoLogBox.InvokeRequired)
                {
                    InfoLogBox.Invoke(new MethodInvoker(delegate { InfoLogBox.AppendText(value); }));
                    InfoLogBox.Invoke(new MethodInvoker(delegate { InfoLogBox.ScrollToCaret(); }));
                } 
            }
        }
        internal string UpdateChat
        {
            set
            {
                if (Chatlogbox.InvokeRequired)
                {
                    Chatlogbox.Invoke(new MethodInvoker(delegate { Chatlogbox.AppendText(value); }));
                    Chatlogbox.Invoke(new MethodInvoker(delegate { Chatlogbox.ScrollToCaret(); }));
                } 
            }
        }
        internal string UpdateView
        {
            get { return View.Text.ToString(); }
            set
            {
                if (View.InvokeRequired)
                {
                    View.Invoke(new MethodInvoker(delegate { View.Text = value; }));
                } 
            }
        }
        internal string UpdateFav
        {
            get { return Fav.Text.ToString(); }
            set
            {
                if (Fav.InvokeRequired)
                {
                    Fav.Invoke(new MethodInvoker(delegate { Fav.Text = value; }));
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            main = this;
            Tokenbox.Text = USettings.Token();
            UserIDBox.Text = USettings.Userid();
            Roomidbox.Text = USettings.Roomid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(Roomidbox.Text) 
                && String.IsNullOrWhiteSpace(Tokenbox.Text) 
                && String.IsNullOrWhiteSpace(UserIDBox.Text)))
            {
                Mamichan mami = new Mamichan();
                Roomidbox.Enabled = false;
                Tokenbox.Enabled = false;
                button1.Enabled = false;
                UserIDBox.Enabled = false;
                mami.RunMamiBot(Roomidbox.Text, Tokenbox.Text, UserIDBox.Text);
                USettings.saveSetting(Tokenbox.Text, Roomidbox.Text, UserIDBox.Text);
            }
            else
            {
                MessageBox.Show("Roomid & TokenBox & UserID can't be whitespace");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mamichan.SendMessage(textBox1.Text);
            textBox1.Text = "";
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.Y <= 30)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
