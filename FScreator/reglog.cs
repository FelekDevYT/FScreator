using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FScreator
{
    public partial class reglog : Form
    {
        public reglog()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            logds logds = new logds();
            logds.ShowDialog();
            checkif();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = "Terms of Service.txt"; // Change this to your desired file name
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "txts", fileName);

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    Process.Start("notepad.exe", filePath);
                }
                else
                {
                    MessageBox.Show($"File '{fileName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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

                    }
                    else
                    {
                        this.Close();
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
    }
}
