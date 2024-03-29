using Guna.UI2.WinForms;
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
        private bool isDragging = false;
        private Point offset;
        private List<Button> createdButtons = new List<Button>();

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
                //textBox1.Text = "1";
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
                        if (enteredNumber >= 61 && enteredNumber <= 69)
                        {
                            textBox1.Text = "60";
                            enteredNumber = 60;
                        }

                        ClearDuplicatedPanels();


                        // Replace "guna2Panel1" with the actual name of your Guna2Panel
                        Guna2Panel panelToDuplicate = guna2Panel1;

                        int panelsInFirstRow = Math.Min(10, enteredNumber);
                        int remainingPanels = enteredNumber - panelsInFirstRow;

                        int initialX = 21;
                        int initialY = 56;

                        for (int i = 0; i < panelsInFirstRow; i++)
                        {
                            Guna2Panel duplicatedPanel = CreateDuplicatedGuna2Panel(panelToDuplicate);
                            duplicatedPanel.Location = new Point(initialX + (i * 45), initialY);
                            this.Controls.Add(duplicatedPanel);
                            duplicatedPanel.BringToFront();
                            duplicatedPanels.Add(duplicatedPanel);
                        }

                        int rows = (int)Math.Ceiling((double)remainingPanels / 10);
                        int panelsInLastRow = remainingPanels % 10;

                        for (int row = 1; row <= rows; row++)
                        {
                            int panelsInCurrentRow = (row == rows) ? panelsInLastRow : 10;
                            for (int i = 0; i < panelsInCurrentRow; i++)
                            {
                                Guna2Panel duplicatedPanel = CreateDuplicatedGuna2Panel(panelToDuplicate);
                                duplicatedPanel.Location = new Point(initialX + (i * 45), initialY + (row * 45));
                                this.Controls.Add(duplicatedPanel);
                                duplicatedPanel.BringToFront();
                                duplicatedPanels.Add(duplicatedPanel);
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
        private Guna2Panel CreateDuplicatedGuna2Panel(Guna2Panel originalPanel)
        {
            Guna2Panel duplicatedPanel = new Guna2Panel();
            duplicatedPanel.Size = originalPanel.Size;
            duplicatedPanel.BackColor = originalPanel.BackColor;
            duplicatedPanel.BorderColor = originalPanel.BorderColor; // Copy the border color
            duplicatedPanel.BorderThickness = originalPanel.BorderThickness; // Copy the border thickness
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
            idtb.Text = "";
            creatortb.Text = "";
            titletb.Text = "";
            vertb.Text = "";
            desctb.Text = "";
            blocksrtb.Text = "{\r\n  \"blocks\": [\r\n    \"block1\",\r\n    \"block2\"\r\n  ],\r\n  \"items\": []\r\n}";
            settingscb.SetItemChecked(settingscb.Items.IndexOf("padding"), false);
            settingscb.SetItemChecked(settingscb.Items.IndexOf("scrollable"), false);

            RemoveAllButtons();
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

        private void CREATE_UI_Load(object sender, EventArgs e)
        {
            // Set the initial transparency level (alpha value)
            int transparency = 255; // You can adjust this value (0 to 255)

            // Set the background color of the panel with transparency
            panel2.BackColor = Color.FromArgb(transparency, panel2.BackColor);
        }

        private void пакFScToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PunP PunP = new PunP();
            PunP.ShowDialog();
        }

        private void кнопкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем новую кнопку
            Button newButton = new Button();
            newButton.Text = "Новая кнопка";
            newButton.AutoSize = true;
            newButton.AutoSizeMode = AutoSizeMode.GrowOnly;

            // Добавляем контекстное меню к кнопке
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem changeTextMenuItem = new ToolStripMenuItem("Изменить текст");
            changeTextMenuItem.Click += (s, args) => ChangeTextMenuItem_Click(newButton, args);
            contextMenu.Items.Add(changeTextMenuItem);

            newButton.ContextMenuStrip = contextMenu;

            // Добавляем обработчик MouseClick
            newButton.MouseClick += (s, args) => DynamicButton_MouseClick(newButton, args);

            // Добавляем обработчики для перемещения кнопки
            newButton.MouseDown += (s, args) => { isDragging = true; offset = args.Location; };
            newButton.MouseMove += DynamicButton_MouseMove;
            newButton.MouseUp += (s, args) => { isDragging = false; };

            // Добавляем новую кнопку на форму
            this.Controls.Add(newButton);

            // Перемещаем новую кнопку вперед
            newButton.BringToFront();

            // Добавляем созданную кнопку в список
            createdButtons.Add(newButton);
        }

        private void DynamicButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Показываем контекстное меню только при нажатии правой кнопкой мыши
                Button clickedButton = sender as Button;

                if (clickedButton != null)
                {
                    // Позиция относительно экрана
                    Point screenPosition = clickedButton.PointToScreen(e.Location);

                    // Позиция относительно формы
                    Point formPosition = this.PointToClient(screenPosition);

                    clickedButton.ContextMenuStrip.Show(this, formPosition);
                }
            }
        }

        private void DynamicButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Button draggedButton = sender as Button;
                if (draggedButton != null)
                {
                    // Получаем новую позицию кнопки относительно формы
                    Point newLocation = this.PointToClient(Control.MousePosition);

                    // Вычисляем смещение
                    newLocation.Offset(-offset.X, -offset.Y);

                    // Устанавливаем новую позицию для кнопки
                    draggedButton.Location = newLocation;
                }
            }
        }

        private void ChangeTextMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                // Отображаем форму с TextBox для изменения текста кнопки
                using (Form inputForm = new Form())
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = clickedButton.Text;

                    Button okButton = new Button();
                    okButton.Text = "ОК";
                    okButton.Click += (s, args) => { inputForm.Close(); };

                    // Устанавливаем расположение элементов
                    textBox.Location = new Point(10, 10);
                    okButton.Location = new Point(10, 40);

                    inputForm.Controls.Add(textBox);
                    inputForm.Controls.Add(okButton);
                    inputForm.BackColor = Color.FromArgb(255,128,0) ;

                    inputForm.ShowDialog();

                    // Присваиваем новый текст кнопке
                    clickedButton.Text = textBox.Text;

                    // Устанавливаем AutoSize и AutoSizeMode для кнопки
                    clickedButton.AutoSize = true;
                    clickedButton.AutoSizeMode = AutoSizeMode.GrowOnly;

                    // Перемещаем кнопку вперед после изменения текста
                    clickedButton.BringToFront();
                }
            }
        }

        private void RemoveAllButtons()
        {
            // Remove all buttons from the form's Controls collection
            foreach (Button button in createdButtons)
            {
                this.Controls.Remove(button);
            }

            // Clear the list of created buttons
            createdButtons.Clear();
        }
    }
}
