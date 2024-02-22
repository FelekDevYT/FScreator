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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FScreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            ToolTip t = new ToolTip();
            t.SetToolTip(button1,"для создания блока в проекте напишите в именни проекта");
            t.SetToolTip(button2, "Создать скрипт для блока/предмета");
            t.SetToolTip(button8, "Создать папку с начальными файлами");
            t.SetToolTip(button5, "для создания предмета в проекте напишите в именни проекта");
        }
        public Color color = Color.FromArgb(255, 128, 0);

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = color;
        }
        public String DRD;
        private void button1_Click(object sender, EventArgs e)
        {
            CREATE_BLOCK.f = textBox1.Text;
            CREATE_BLOCK cr = new CREATE_BLOCK();
            cr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lua_CODER cr = new Lua_CODER();
            cr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JSON js = new JSON();
            js.ShowDialog();
        }
        String name;

        private void button8_Click(object sender, EventArgs e)
        {
            CREATE_OBL obl = new CREATE_OBL();
            obl.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CREATE_ITEM.f = textBox1.Text;
            CREATE_ITEM cr  = new CREATE_ITEM();
            cr.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Lua_CODER l = new Lua_CODER();
            l.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            JSON j = new JSON();
            j.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Спасибо Domaja за ВСЕ!!!", "Благодарности", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CREATE_UI UI = new CREATE_UI();
            UI.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            XML_coder xm = new XML_coder();
            xm.ShowDialog();
        }
    }
}