﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FScreator
{
    public partial class JSON : Form
    {
        public JSON()
        {
            InitializeComponent();
        }
        String openfile;

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            String filename = openFileDialog1.FileName;
            fastColoredTextBox1.Text = File.ReadAllText(filename);
            openfile = openFileDialog1.FileName;
        }
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы хотите сохранить изменения в файле?", "FScreator - JSON", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                String filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, fastColoredTextBox1.Text);
            }
            else if (result == DialogResult.No)
            {
                Close();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            String file = saveFileDialog1.FileName;
            File.WriteAllText(file, fastColoredTextBox1.Text);
            openfile = saveFileDialog1.FileName;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(openfile, fastColoredTextBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка:файл сохранения не найден!", "Ошибка:файл сохранения не найден!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
