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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FScreator
{
    public partial class logds : Form
    {
        private List<string> bannedList = new List<string> { "MihailRis" };

        public logds()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                // Set the file path where you want to save the text
                string filePath = Path.Combine(Environment.CurrentDirectory, "txts", "user.txt");

                try
                {
                    // Clear the existing content of the file
                    File.WriteAllText(filePath, string.Empty);

                    // Use StreamWriter to write the text from textbox1 to the predefined file path
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        if (guna2TextBox1.Text == "")
                        {
                            MessageBox.Show("No Username in Text Box!");
                        }
                        else
                        {
                            if (bannedList.Contains(guna2TextBox1.Text))
                            {
                                MessageBox.Show("Sorry You Can't Login With Discord! Username is Banned!");
                            }
                            else
                            {
                                if (guna2TextBox1.Text != "domaja")
                                {
                                    writer.Write(guna2TextBox1.Text);
                                }
                                else
                                {
                                    MessageBox.Show("Administraation Account Has Ben Freezed!");
                                }
                            }
                        }

                    }
                    if (!bannedList.Contains(guna2TextBox1.Text))
                    {
                        if (guna2TextBox1.Text != "")
                        {
                            if (guna2TextBox1.Text != "domaja")
                            {
                                MessageBox.Show("Logined successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                checkif();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Logining with Discord: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Agree Terms Of Service !", "Обязательно!");
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
    }
}
