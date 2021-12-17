using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace renderpictureengine
{
    public partial class Form1 : Form
    {
        public static string path = Assembly.GetEntryAssembly().Location.Replace(System.AppDomain.CurrentDomain.FriendlyName, "");
        public static int playerspeed; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var start = new Point(0, 0);
            //
            foreach (string line in System.IO.File.ReadLines(path + "EngineData\\Playercontroller\\settings.txt")) {

                if (line.StartsWith("size")) {
                    var s = line.Replace("size=", "").Split(',');
                    player.Size = new Size(int.Parse(s[0]), int.Parse(s[1]));

                }
                else if (line.StartsWith("start"))
                {
                    var s = line.Replace("start=", "").Split(',');
                    player.Location = new Point(int.Parse(s[0]), int.Parse(s[1]));

                }
                else if (line.StartsWith("image"))
                {
                    var s = line.Replace("image=", "");
                    player.BackgroundImage = Image.FromFile(path + s);
                   player.BackgroundImageLayout = ImageLayout.Stretch;


                }
                else if (line.StartsWith("speed"))
                {
                    var s = line.Replace("speed=", "");
                    playerspeed = int.Parse(s);


                }
            }

            foreach (string line in System.IO.File.ReadLines(path + "GameData\\renderingobjects\\renderitems.txt"))
            {

                if (!line.StartsWith("//")) {
                    var dat = line.Split(',');



                    var picture = new PictureBox();

                    picture.Name = dat[0].ToString();
                    picture.Size = new Size(Int32.Parse(dat[3]), Int32.Parse(dat[4]));
                    picture.Location = new Point(Int32.Parse(dat[1]), Int32.Parse(dat[2]));
                    if (File.Exists(path + dat[5])) {
                        picture.BackgroundImage = Image.FromFile(path + dat[5]);
                    }
                    picture.BackColor = Color.FromName(dat[6].ToString());
                    picture.BackgroundImageLayout = ImageLayout.Stretch;

                    switch (int.Parse(dat[7])) {
                        case 0:
                            picture.Anchor = AnchorStyles.None;
                            break;
                        case 1:
                            picture.Anchor = AnchorStyles.Top;

                            break;


                        case 4:
                            picture.Anchor = AnchorStyles.Left;

                            break;
                        case 8:
                            picture.Anchor = AnchorStyles.Right;

                            break;
                        case 2:
                            picture.Anchor = AnchorStyles.Bottom;

                            break;
                    }
                    this.Controls.Add(picture);


                }
            
            }  
  
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (!player.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    player.Top -= playerspeed;

                }

            }
            else if (e.KeyCode == Keys.S)
            {
                if (!player.Bounds.IntersectsWith(pictureBox2.Bounds))
                {
                    player.Top += playerspeed;

                }

            }
            else if (e.KeyCode == Keys.A)
            {
                if (!player.Bounds.IntersectsWith(pictureBox3.Bounds))
                {

                    player.Left -= playerspeed;


                }


            }
            else if (e.KeyCode == Keys.D)
            {
                if (!player.Bounds.IntersectsWith(pictureBox4.Bounds))
                {

                    player.Left += playerspeed;

                }
            }
        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
