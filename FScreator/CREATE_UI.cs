using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FScreator
{
    public partial class CREATE_UI : Form
    {
        private int slots = 0;
        private int maxSlotsprog = 70;
        private int maxSlots = 10;
        private List<Panel> duplicatedPanels = new List<Panel>();
        public CREATE_UI()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            { 
            
            }
            else
            {
                if (int.TryParse(textBox1.Text, out int enteredNumber))
                {
                    if (enteredNumber > maxSlotsprog)
                    {
                        MessageBox.Show("Ошибка! Введите число, не превышающее 70 слотов.", "Слишком большое число!");

                        // Текст в максимальное количество Слотов
                        textBox1.Text = "70";

                    }
                    else
                    {
                        ClearDuplicatedPanels();


                        // Replace "panel3" with the actual name of your panel
                        Panel panelToDuplicate = panel3;

                        int panelsInFirstRow = Math.Min(10, enteredNumber); // Maximum of 10 panels in the first row
                        int remainingPanels = enteredNumber - panelsInFirstRow; // Calculate remaining panels

                        // Set initial X and Y positions
                        int initialX = 21; // Adjust the initial X position as needed
                        int initialY = 56; // Adjust the initial Y position as needed

                        // Create and position panels in the first row
                        for (int i = 0; i < panelsInFirstRow; i++)
                        {
                            Panel duplicatedPanel = CreateDuplicatedPanel(panelToDuplicate);
                            duplicatedPanel.Location = new Point(initialX + (i * 45), initialY);
                            this.Controls.Add(duplicatedPanel);
                            duplicatedPanel.BringToFront(); // Bring the panel to the front
                            duplicatedPanels.Add(duplicatedPanel); // Add to the list
                        }

                        // Create and position remaining panels in subsequent rows
                        int rows = (int)Math.Ceiling((double)remainingPanels / 10); // Calculate the number of rows needed
                        int panelsInLastRow = remainingPanels % 10; // Calculate panels in the last row

                        for (int row = 1; row <= rows; row++)
                        {
                            int panelsInCurrentRow = (row == rows) ? panelsInLastRow : 10;
                            for (int i = 0; i < panelsInCurrentRow; i++)
                            {
                                Panel duplicatedPanel = CreateDuplicatedPanel(panelToDuplicate);
                                duplicatedPanel.Location = new Point(initialX + (i * 45), initialY + (row * 45));
                                this.Controls.Add(duplicatedPanel);
                                duplicatedPanel.BringToFront(); // Bring the panel to the front
                                duplicatedPanels.Add(duplicatedPanel); // Add to the list
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введи число не буквы!!", "НЕКАКИХ БУКВ!");

                    // Отключает изменения чтоб не лагало при отчистке
                    textBox1.TextChanged -= textBox1_TextChanged;

                    // отчистка
                    textBox1.Clear();

                    // Поддключает изменения обратно
                    textBox1.TextChanged += textBox1_TextChanged;
                }
            }
        }

        private void saveAndExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        static double RoundToTens(double number)
        {
            return Math.Round(number / 10.0) * 10.0;
        }



        // Method to create a duplicated panel with the same properties as the original panel
        private Panel CreateDuplicatedPanel(Panel originalPanel)
        {
            Panel duplicatedPanel = new Panel();
            duplicatedPanel.Size = originalPanel.Size;
            duplicatedPanel.BackColor = originalPanel.BackColor;
            // Copy other properties as needed
            return duplicatedPanel;
        }

        // Method to clear only the duplicated panels created during the current session
        private void ClearDuplicatedPanels()
        {
            foreach (Panel duplicatedPanel in duplicatedPanels)
            {
                this.Controls.Remove(duplicatedPanel);
                duplicatedPanel.Dispose();
            }
            duplicatedPanels.Clear(); // Clear the list
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Package.Show();
            UI.Hide();
        }

        private void packageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Package.Hide();
            UI.Show();
        }

        private void xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XML_coder XML_coder = new XML_coder();
            XML_coder.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DomaJa сделал редактор!", "Важно!");
            MessageBox.Show("FScreator New Update UI!", "Нужно?!");
            MessageBox.Show("Может бета может нет", "А может просто");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
