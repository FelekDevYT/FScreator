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
        private string version = "1.5.2";
        public Form1()
        {
            InitializeComponent();
            checkif();
            if (Accountbutton.Text != "Anonym")
            {
                Saccountbutton.Show();
            }

            this.Text = "FScreator " + version + " - Главная";
            guna2HtmlLabel1.Text = "V" + version;


            ToolTip t = new ToolTip();
            t.SetToolTip(Packerbutton, "Для запаковки файлов в .FSCr формат");
            t.SetToolTip(Createproject, "Создать проект");
            t.SetToolTip(Openbutton, "Открыть проект .FSCr");
            t.SetToolTip(Exitbutton, "Выйти :(");
            t.SetToolTip(Bbutton, "Можно но можно!");
        }
        public Color color = Color.FromArgb(255, 128, 0);

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = color;
        }
        public String DRD;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(Accountbutton.Text == "Anonym")
            {
                reglog reglog = new reglog();
                reglog.ShowDialog();
                checkif();
            }
        }

        private void checkif()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "txts", "user.txt");

                // Проверяем существование файла
                if (File.Exists(filePath))
                {
                    // Читаем текст из файла
                    string fileContent = File.ReadAllText(filePath);

                    if (fileContent == "")
                    {
                        Saccountbutton.Hide();
                    }
                    else
                    {
                        Accountbutton.Text = fileContent;
                        Saccountbutton.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            reglog reglog = new reglog();
            reglog.ShowDialog();
            checkif();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Createproject_Click(object sender, EventArgs e)
        {
            CreateProject createproject = new CreateProject();

            this.Hide();

            createproject.ShowDialog();

            this.Show();
        }

        private void Packerbutton_Click(object sender, EventArgs e)
        {
            PunP punp = new PunP();

            this.Hide();
            
            punp.ShowDialog();

            this.Show();
        }

        private void Bbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Спасибо Domaja за ВСЕ!!!", "Благодарности", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}