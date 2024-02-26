using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FScreator
{
    public partial class CreateProject : Form
    {
        private string selmode = "model";

        public CreateProject()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modelbutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Blue;
            texturebutton.FillColor = Color.Gray;
            Oblbutton.FillColor = Color.Gray;
            Itembutton.FillColor = Color.Gray;
            Blockbutton.FillColor = Color.Gray;
            uibutton.FillColor = Color.Gray;
            redbutton.FillColor = Color.Gray;
            selmode = "model";
        }

        private void texturebutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Gray;
            texturebutton.FillColor = Color.Blue;
            Oblbutton.FillColor = Color.Gray;
            Itembutton.FillColor = Color.Gray;
            Blockbutton.FillColor = Color.Gray;
            uibutton.FillColor = Color.Gray;
            redbutton.FillColor = Color.Gray;
            selmode = "texture";
        }

        private void Itembutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Gray;
            texturebutton.FillColor = Color.Gray;
            Oblbutton.FillColor = Color.Gray;
            Itembutton.FillColor = Color.Blue;
            Blockbutton.FillColor = Color.Gray;
            uibutton.FillColor = Color.Gray;
            redbutton.FillColor = Color.Gray;
            selmode = "item";
        }

        private void Blockbutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Gray;
            texturebutton.FillColor = Color.Gray;
            Oblbutton.FillColor = Color.Gray;
            Itembutton.FillColor = Color.Gray;
            Blockbutton.FillColor = Color.Blue;
            uibutton.FillColor = Color.Gray;
            redbutton.FillColor = Color.Gray;
            selmode = "block";
        }

        private void Oblbutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Gray;
            texturebutton.FillColor = Color.Gray;
            Oblbutton.FillColor = Color.Blue;
            Itembutton.FillColor = Color.Gray;
            Blockbutton.FillColor = Color.Gray;
            uibutton.FillColor = Color.Gray;
            redbutton.FillColor = Color.Gray;
            selmode = "obl";
        }

        private void redbutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Gray;
            texturebutton.FillColor = Color.Gray;
            Oblbutton.FillColor = Color.Gray;
            Itembutton.FillColor = Color.Gray;
            Blockbutton.FillColor = Color.Gray;
            uibutton.FillColor = Color.Gray;
            redbutton.FillColor = Color.Blue;
            selmode = "code";
        }

        private void uibutton_Click(object sender, EventArgs e)
        {
            modelbutton.FillColor = Color.Gray;
            texturebutton.FillColor = Color.Gray;
            Oblbutton.FillColor = Color.Gray;
            Itembutton.FillColor = Color.Gray;
            Blockbutton.FillColor = Color.Gray;
            uibutton.FillColor = Color.Blue;
            redbutton.FillColor = Color.Gray;
            selmode = "ui";
        }

        private void Createbutton_Click(object sender, EventArgs e)
        {
            if (selmode != "none")
            {
                if (selmode == "model")
                {
                    _3dmodel Dmodel = new _3dmodel();

                    this.Hide();

                    Dmodel.ShowDialog();

                    this.Show();
                }
                else if (selmode == "texture")
                {

                }
                else if (selmode == "code")
                {
                    КУВФСЕ r = new КУВФСЕ();

                    this.Hide();

                    r.ShowDialog();

                    this.Show();
                }
                else if (selmode == "ui")
                {
                    CREATE_UI UI = new CREATE_UI();

                    this.Hide();

                    UI.ShowDialog();

                    this.Show();
                }
                else if (selmode == "item")
                {
                    CREATE_ITEM.f = Pnamebox.Text;
                    CREATE_ITEM cr = new CREATE_ITEM();

                    this.Hide();

                    cr.ShowDialog();

                    this.Show();
                }
                else if (selmode == "block")
                {
                    CREATE_BLOCK.f = Pnamebox.Text;
                    CREATE_BLOCK cr = new CREATE_BLOCK();

                    this.Hide();

                    cr.ShowDialog();

                    this.Show();
                }
                else if (selmode == "obl")
                {
                    CREATE_OBL obl = new CREATE_OBL();

                    this.Hide();

                    obl.ShowDialog();

                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Выбери назначение!", "Выбери");
            }
        }
    }
}
