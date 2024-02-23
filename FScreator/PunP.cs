using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace FScreator
{
    public partial class PunP : Form
    {
        public PunP()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "txts", "user.txt");

                // Читаем текст из файла
                string fileContent = File.ReadAllText(filePath2);

                string filePath3 = Path.Combine(Directory.GetCurrentDirectory(), "txts", "userdata.txt");

                // Читаем текст из файла
                string fileContent2 = File.ReadAllText(filePath3);


                // Create a package and add some data
                MyPackage package = new MyPackage();
                package.Data.Add(fileContent);
                package.Data.Add(fileContent2);

                // Get the path from the user
                string filePath = GetFilePath("Save Package");

                // Serialize and save the package
                PackageSerializer.Serialize(package, filePath);

                MessageBox.Show("Package created and saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while packing: {ex.Message}");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the path from the user for opening the package
                string packageFilePath = GetOpenFilePath("Open Package");

                // Deserialize and load the package
                MyPackage package = PackageSerializer.Deserialize<MyPackage>(packageFilePath);

                // Get the path for saving the unpacked data
                string textFilePath = GetSaveFilePath("Save Unpacked Data");

                // Write the unpacked data to the text file
                File.WriteAllLines(textFilePath, package.Data);

                MessageBox.Show($"Unpacked data saved to {textFilePath}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while unpacking: {ex.Message}");
            }
        }

        private string GetFilePath(string title)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = title;
                dialog.Filter = "FScreator Safe Zip (*.FSCr)|*.FSCr";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else
                {
                    // User canceled the operation
                    return null;
                }
            }
        }

        private string GetOpenFilePath(string title)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = title;
                dialog.Filter = "FScreator Safe Zip (*.FSCr)|*.FSCr";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else
                {
                    // User canceled the operation
                    return null;
                }
            }
        }

        private string GetSaveFilePath(string title)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = title;
                dialog.Filter = "Text Files (*.txt)|*.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                else
                {
                    // User canceled the operation
                    return null;
                }
            }
        }
    }
}
