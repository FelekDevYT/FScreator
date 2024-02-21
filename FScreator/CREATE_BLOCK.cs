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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FScreator
{
    public partial class CREATE_BLOCK : Form
    {
        public CREATE_BLOCK()
        {
            InitializeComponent();
            BackColor = color2;
            ToolTip t = new ToolTip();
            t.SetToolTip(label3, "с востока на запад");
            t.SetToolTip(label5, "с юга на север");
            t.SetToolTip(comboBox1, "при выборе модели aabb введите хитбокс");
        }
        String dir;
        public Color color2 = Color.FromArgb(255, 128, 0);
        String light_passing = "false";bool light_passing_BL = false;
        String sky_light_passing = "false";bool sky_light_passing_BL = false;
        String obstacle = "false";bool obstacle_BL = false;
        String selectable = "false";bool selectable_BL = false;
        String replaceable = "false";bool replaceable_BL = false;
        String breakable = "false";bool breakable_BL = false;
        String hidden = "false";bool hidden_BL = false;
        String draw_Droup = "1";

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(light_passing_BL)
            {
                light_passing = "false";
                light_passing_BL = false;
            }
            else
            {
                light_passing = "true";
                light_passing_BL = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (sky_light_passing_BL)
            {
                sky_light_passing = "false";
                sky_light_passing_BL = false;
            }
            else
            {
                sky_light_passing = "true";
                sky_light_passing_BL = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (obstacle_BL)
            {
                obstacle = "false";
                obstacle_BL = false;
            }
            else
            {
                obstacle = "true";
                obstacle_BL = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (selectable_BL)
            {
                selectable = "false";
                selectable_BL = false;
            }
            else
            {
                selectable = "true";
                selectable_BL = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (replaceable_BL)
            {
                replaceable = "false";
                replaceable_BL = false;
            }
            else
            {
                replaceable = "true";
                replaceable_BL = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (breakable_BL)
            {
                breakable = "false";
                breakable_BL = false;
            }
            else
            {
                breakable = "true";
                breakable_BL = true;
            }

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (hidden_BL)
            {
                hidden = "false";
                hidden_BL = false;
            }
            else
            {
                hidden = "true";
                hidden_BL = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            draw_Droup = numericUpDown1.Value.ToString();
        }
        bool gg = false;

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if(gg == false)
            {
                panel2.Visible = true;
                panel4.Visible = false;
                gg = true;
            }
            else
            {
                panel2.Visible = false;
                panel4.Visible = true;
                gg=false;
            }
        }
        String file;
        bool re = false;

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (re == false)
            {
                RGB.Visible = true;
                re = true;
            }
            else
            {
                RGB.Visible = false;
                re = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            file = "{\n" +
"\"light-passing\":" + light_passing + ",\n" +
"\"sky-light-passing\":" + sky_light_passing + ",\n" +
"\"obstacle\":" + obstacle + ",\n" +
"\"selectable\":" + selectable + ",\n" +
"\"replaceable\":" + replaceable + ",\n" +
"\"breakable\":" + breakable + ",\n" +
"\"hidden\":" + hidden + ",\n" +
"\"model\":\""+comboBox1.Text + "\",\n" +
"\"inventory-size\":"+numericUpDown2.Value +"\",\n"+
"\"draw-group\":" + draw_Droup + "";
            if (panel4.Visible == true)
            {
                file += ",\"texture\":\"" + textBox7.Text+"\"";
            }
            else if (panel2.Visible == true)
            {
                file += ",\n\"texture-faces\":[\"" + textBox1.Text + "\",\n\"" + textBox2.Text + "\",\n\"" + textBox3.Text +
                    "\",\n\"" + textBox4.Text + "\",\n\"" + textBox5.Text + "\",\n\"" + textBox6.Text + "\"]\n";
            }
            if (RGB.Visible == true)
            {
                file += ",\n\"emission\":[" + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + "]";
            }
            if(HITBOX.Visible == true)
            {
                file += ",\n\"hitbox\":[" + textBox12.Text + "," + textBox13.Text + "," + textBox14 + "," + textBox15.Text + "," + textBox16.Text + "," + textBox17.Text+"]";
            }
            if(SCRIPT.Visible == true)
            {
                file += ",\n\"script-name\":\"" + textBox18.Text + "\"";
            }
            if(UI_ELEMENT.Visible == true)
            {
                file += ",\n\"ui-layout\":\"" + textBox19.Text + "\"";
            }
            file += "\n}";
            String hlp = Directory.GetCurrentDirectory();
            
            String fd = hlp + "\\" + f + "\\blocks\\" + textBox8.Text + ".json";
            if (f != "Null")
            {
                File.WriteAllText(fd, file);
            }else
            {
                File.WriteAllText(textBox8.Text + ".json", file);
            }
           Close();
        }
        public static String f;
        private void CREATE_BLOCK_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox3.Checked = true;
            checkBox2.Checked = true;
            checkBox5.Checked = true;
            checkBox7.Checked = true;

        }
        bool le;
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (le == false)
            {
                HITBOX.Visible = true;
                le = true;
            }
            else
            {
                HITBOX.Visible = false;
                le = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            INFORMATION inf = new INFORMATION
                ();
            inf.Show();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (SCRIPT.Visible)
            {
                SCRIPT.Visible = false;
            }
            else
            {
                SCRIPT.Visible = true;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_ELEMENT.Visible)
            {
                UI_ELEMENT.Visible = false;
            }
            else
            {
               UI_ELEMENT.Visible = true;
            }    
        }
    }
}