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

namespace FScreator
{
    public partial class CREATE_ITEM : Form
    {
        public CREATE_ITEM()
        {
            InitializeComponent();
        }
        bool gg = false;public static String f;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(RGB.Visible)
            {
                RGB.Visible = false;
            }
            else
            {
                RGB.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            String file = "{\n" +
                "\"icon-type\":\"" + comboBox1.SelectedItem +
                "\",\n\"icon\":\"item:" + textBox2.Text +
                "\",\n\"stack-size\":\""+numericUpDown1.Value +
                "\"";
            if(RGB.Visible == true)
            {
                file += ",\n\"emission\":[" + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text+"]";
            }
            if(plack_block.Visible == true)
            {
                file += ",\n\"placing-block\":\"" + textBox3.Text + "\"";
            }
            file+= "\n}";
            String hlp = Directory.GetCurrentDirectory();
            String fd;
            if (f != "Null")
            {
                fd = hlp + "\\" + f + "\\items\\" + textBox1.Text +".json";
            }
            else
            {
                fd = hlp +"\\"+ textBox1.Text+ ".json";
            }
            File.WriteAllText(fd, file);
            Close();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (plack_block.Visible)
            {
                plack_block.Visible = false;
            }
            else
            {
                plack_block.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            INFORMATION_FOR_ITEM ifi = new INFORMATION_FOR_ITEM();
            ifi.Show();
        }

        private void CREATE_ITEM_Load(object sender, EventArgs e)
        {

        }
    }
}