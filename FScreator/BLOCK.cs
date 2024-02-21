using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FScreator
{
    public partial class BLOCK : Form
    {
        public BLOCK()
        {
            InitializeComponent();
        }
        public String f;
        bool b;
        private void Экспорт_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            String path = Directory.GetCurrentDirectory();
            String cur = "{\n" + "\"id";
           // File.WriteAllText(path+"\\"+f+"\\package",);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            b = true;
        }

        private void BLOCK_Load(object sender, EventArgs e)
        {

        }
    }
}
