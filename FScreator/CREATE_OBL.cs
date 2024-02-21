using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Linq;

namespace FScreator
{
    public partial class CREATE_OBL : Form
    {
        public CREATE_OBL()
        {
            InitializeComponent();
        }
        String PackageFile;
        String name , dir;
        private void CREATE_OBL_Load(object sender, EventArgs e)
        {
        
        }
        String cur;

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG files(*.png)|*.png|All files(*.*)|*.*";
            String name = Directory.GetCurrentDirectory();
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            File.Move(@"" + openFileDialog1.FileName, @"" + name + "\\" + textBox1.Text+"\\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cur = "{\n" +
                "\"id\":\"" +ID.Text+"\",\n"+
                "\"title\":\""+TITLE.Text+"\",\n"+
                "\"creator\":\""+CREATOR.Text+ " using FScreator\",\n" +
                "\"version\":\""+VERSION.Text+"\",\n"+
                "\"description\":\""+CREATOR.Text+"\",\n}";
            //create main directory
            name = Directory.GetCurrentDirectory();
            dir = System.IO.Path.Combine(name, textBox1.Text);
            Directory.CreateDirectory(dir);
            String[] IN = dir.Split('\\');
            //create blocks directory
            dir = System.IO.Path.Combine (name+"\\"+textBox1.Text,"blocks");
            Directory.CreateDirectory (dir);
            //create textures folder
            dir = System.IO.Path.Combine(name + "\\" + textBox1.Text, "textures");
            Directory.CreateDirectory (dir);
            //create textures\blocks
            dir = System.IO.Path.Combine(name + "\\" + textBox1.Text + "\\textures", "blocks");
            Directory.CreateDirectory (dir);
            //create scripts folder
            if (checkBox1.Checked)
            {
                dir = System.IO.Path.Combine(name + "\\" + textBox1.Text, "scripts");
                Directory.CreateDirectory(dir);
            }
            //create items folder
            if(checkBox2.Checked)
            {
                dir = System.IO.Path.Combine(name + "\\" + textBox1.Text, "items");
                Directory.CreateDirectory(dir);
            }
            //create folder textures\items
            if (checkBox3.Checked)
            {
                dir = System.IO.Path.Combine(name+"\\" + textBox1.Text + "\\textures","items");
                Directory.CreateDirectory(dir);
            }
            //create folder textures\items
            if (checkBox4.Checked)
            {
                dir = System.IO.Path.Combine(name + "\\" + textBox1.Text + "\\layouts");
                Directory.CreateDirectory(dir);
            }
            //create package file
            File.WriteAllText(name + "\\" + textBox1.Text+"\\package.json", cur);
            //create content file
            File.WriteAllText(name + "\\" + textBox1.Text + "\\content.json", "{\n" +
                "\"blocks\":[],\n" +
                "\"items\":[]\n" + "}");
            Close();
        }
    }
}
