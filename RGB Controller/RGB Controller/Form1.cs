using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Controller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int level;
        int animation_index;
        string[] animation = {"Rainbow", "Color Wipe", "Theatre", "Kitt", "Cylon", "Running", "Meteor", "Twinkle", "Fade", "Random"};
        private void Form1_Load(object sender, EventArgs e)
        {
            level = 5;
            animation_index = 1;
            label_level.Text = level.ToString();
            command("level:" + (level * 25));
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            if (level < 10)
            {
                level += 1;
                command("level:" + level * 25);
                label_level.Text = level.ToString();
            }
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            if (level > 1)
            {
                level -= 1;
                command("level:" + level * 25);
                label_level.Text = level.ToString();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Color color = ((Bitmap)pictureBox1.Image).GetPixel(e.X, e.Y);
                label_red.Text = color.R.ToString();
                label_green.Text = color.G.ToString();
                label_blue.Text = color.B.ToString();
                string rgb = string.Format("r:{0}g:{1}b:{2}", color.R.ToString().PadLeft(3, '0'), color.G.ToString().PadLeft(3, '0'), color.B.ToString().PadLeft(3, '0'));
                Console.WriteLine(rgb);
                command(rgb);
            }
            catch
            {

            }
        }

        void command(string command)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    if (serialPort1.IsOpen)
                    {
                        Console.WriteLine(command);
                        serialPort1.Write(command);
                        serialPort1.Close();
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            if(animation_index < 10)
            {
                animation_index++;
                label_anim.Text = animation[animation_index - 1];
                command("mode:" + animation_index);
            }
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            if (animation_index > 1)
            {
                animation_index--;
                label_anim.Text = animation[animation_index - 1];
                command("mode:" + animation_index);
            }
        }

        private void label_anim_Click(object sender, EventArgs e)
        {
            command("mode:" + animation_index);
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
