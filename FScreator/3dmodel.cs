using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using System.IO;
using System.Windows.Controls;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml;
using Newtonsoft.Json;
using System.Linq;

namespace FScreator
{
    public partial class _3dmodel : Form
    {
        private HelixViewport3D helixViewport;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private BoxVisual3D cubeToAdjust; // Declare at the class level
        private BoxVisual3D startcube; // Declare at the class level
        private BoxVisual3D bancube; // Declare at the class level
        private System.Windows.Forms.Panel sliderPanel;
        private TrackBar slider1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button;
        int X1;
        int Y1;
        int Z1;
        int R;
        int R2;
        private List<BoxVisual3D> cubes = new List<BoxVisual3D>();
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private int currentCubeIndex = 0;
        private int totalCubes => cubes.Count;


        public _3dmodel()
        {
            InitializeComponent2();
            Initialize3DView();
            InitializeForm();
        }

        private void InitializeComponent2()
        {
            // ... other initialization code

            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            // Set properties for elementHost1 if needed
            this.Controls.Add(this.elementHost1);
            this.elementHost1.Dock = DockStyle.Fill;  // Dock to fill the entire form
            this.SuspendLayout();
            // ... other initialization code
            this.ResumeLayout(false);
        }

        private void Initialize3DView()
        {
            helixViewport = new HelixViewport3D();
            helixViewport.ZoomExtentsWhenLoaded = true;

            var cube = new BoxVisual3D()
            {
                Center = new Point3D(0, -2.7, 0), 
                Length = 6,
                Width = 0.5,
                Height = 6,
                Material = Materials.White,

            };

            var cube2 = new BoxVisual3D() //    Platform size is    2.7 x 2       
            {
                Center = new Point3D(0, 0, -3.14),
                Length = 6,
                Width = 6,
                Height = 0.3,
                Material = Materials.Black,
            };

            // Get the current directory
            string currentDirectory = Environment.CurrentDirectory;

            cubeToAdjust = cube;
            startcube = cube;
            bancube = cube2;

            // Add a directional light
            helixViewport.Children.Add(new DefaultLights());

            helixViewport.Children.Add(cube);
            helixViewport.Children.Add(cube2);
            elementHost1.Child = helixViewport;
        }

        private void InitializeForm()
        {
            // Set the size of the form
            this.Size = new System.Drawing.Size(800, 600); // Adjust the width and height as needed
            this.Text = "FScreator - 3D VoxelBlender"; //Form Text
            this.ShowIcon = false;
            this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);


            // Create a panel to hold the slider
            sliderPanel = new System.Windows.Forms.Panel();
            sliderPanel.Dock = DockStyle.Left;
            sliderPanel.Width = 100; // Set the width as needed

            // Create a TrackBar
            slider1 = new TrackBar();
            slider1.Minimum = -100;
            slider1.Maximum = 100;
            slider1.Value = 0;
            slider1.TickFrequency = 10;
            slider1.ValueChanged += slider1_ValueChanged;

            // Create Four textboxes
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox5 = new System.Windows.Forms.TextBox();

            // Set properties for the textboxes
            textBox1.Location = new System.Drawing.Point(10, 30);
            textBox2.Location = new System.Drawing.Point(10, 60);
            textBox3.Location = new System.Drawing.Point(10, 90);
            textBox4.Location = new System.Drawing.Point(10, 120);

            // Add event handlers for TextChanged
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox2_TextChanged;
            textBox3.TextChanged += TextBox3_TextChanged;
            textBox4.TextChanged += TextBox4_TextChanged;
            textBox5.TextChanged += TextBox5_TextChanged;

            //Add numbers to Text Boxes
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

            // Create a Reset button
            System.Windows.Forms.Button resetButton = new System.Windows.Forms.Button();
            resetButton.Text = "Reset";
            resetButton.Location = new Point(10, 150);  // Adjust the location as needed, possibly using textBox3.Bottom + some_margin
            resetButton.Click += ResetButton_Click;

            // Create a Create button
            System.Windows.Forms.Button createButton = new System.Windows.Forms.Button();
            createButton.Text = "Create";
            createButton.Location = new Point(10, resetButton.Bottom + 10);  // Adjust the location as needed
            createButton.Click += CreateButton_Click;

            // Create a Delete button
            System.Windows.Forms.Button deleteButton = new System.Windows.Forms.Button();
            deleteButton.Text = "Delete";
            deleteButton.Location = new Point(10, createButton.Bottom + 10);  // Adjust the location as needed
            deleteButton.Click += DeleteButton_Click;

            // Create three textboxes for setting Length, Width, and Height
            lengthTextBox = new System.Windows.Forms.TextBox();
            widthTextBox = new System.Windows.Forms.TextBox();
            heightTextBox = new System.Windows.Forms.TextBox();

            lengthTextBox.Location = new Point(10, deleteButton.Bottom + 10);  // Adjust the location as needed
            widthTextBox.Location = new Point(10, lengthTextBox.Bottom + 10);   // Adjust the location as needed
            heightTextBox.Location = new Point(10, widthTextBox.Bottom + 10);  // Adjust the location as needed

            lengthTextBox.TextChanged += LengthTextBox_TextChanged;
            widthTextBox.TextChanged += WidthTextBox_TextChanged;
            heightTextBox.TextChanged += HeightTextBox_TextChanged;

            //Add numbers to Text Boxes
            lengthTextBox.Text = "6";
            widthTextBox.Text = "0.5";
            heightTextBox.Text = "6";

            // Create two navigation buttons
            System.Windows.Forms.Button prevButton = new System.Windows.Forms.Button();
            prevButton.Text = "Previous";
            prevButton.Location = new Point(10, 430);
            prevButton.Click += PrevButton_Click;

            System.Windows.Forms.Button nextButton = new System.Windows.Forms.Button();
            nextButton.Text = "Next";
            nextButton.Location = new Point(10, 400);
            nextButton.Click += NextButton_Click;

            // Create a Build button
            System.Windows.Forms.Button BuildButton = new System.Windows.Forms.Button();
            BuildButton.Text = "Build";
            BuildButton.Location = new Point(10, nextButton.Bottom + 50);  // Adjust the location as needed
            BuildButton.Click += BuildButton_Click;

            textBox5.Location = new System.Drawing.Point(10, heightTextBox.Bottom + 10);

            // Add the TrackBar and textboxes to the panel
            sliderPanel.Controls.Add(textBox1);
            sliderPanel.Controls.Add(textBox2);
            sliderPanel.Controls.Add(textBox3);
            sliderPanel.Controls.Add(textBox4);
            sliderPanel.Controls.Add(textBox5);

            // Add the textboxes to the panel
            sliderPanel.Controls.Add(lengthTextBox);
            sliderPanel.Controls.Add(widthTextBox);
            sliderPanel.Controls.Add(heightTextBox);

            // Add the Reset button to the panel
            sliderPanel.Controls.Add(resetButton);

            // Add the Create button to the panel
            sliderPanel.Controls.Add(createButton);

            // Add the navigation buttons to the panel
            sliderPanel.Controls.Add(prevButton);
            sliderPanel.Controls.Add(nextButton);
            sliderPanel.Controls.Add(BuildButton);

            // Add the Delete button to the panel
            sliderPanel.Controls.Add(deleteButton);

            // Set properties for the slider if needed
            sliderPanel.Controls.Add(slider1);

            // Add the panel to the form
            this.Controls.Add(sliderPanel);

            // Set the layout for the ElementHost and the slider
            this.elementHost1.Dock = DockStyle.Fill;


            // Dock the slider to the left side of the form
            slider1.Dock = DockStyle.Left;

        }

        private void _3dmodel_Load(object sender, EventArgs e)
        {
            if (helixViewport != null)
            {
                helixViewport.ZoomExtents();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Text Box Reset
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            lengthTextBox.Text = "6";
            widthTextBox.Text = "0.5";
            heightTextBox.Text = "6";

            // Sliders Reset
            slider1.Value = 0;
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            GenerateJson();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            // Create a new cube with default properties
            var newCube = new BoxVisual3D()
            {
                Center = new Point3D(0, -2.7, 0),
                Length = 6,
                Width = 0.5,
                Height = 6,
                Material = Materials.White,
            };

            // Add the new cube to the viewport
            helixViewport.Children.Add(newCube);

            // Add the new cube to the list of cubes
            cubes.Add(newCube);

            // Set the new cube as the cubeToAdjust
            cubeToAdjust = newCube;

            // Set the currentCubeIndex to the index of the new cube
            currentCubeIndex = cubes.Count - 1;

            // Update textboxes based on the new cube
            UpdateTextBoxesFromCurrentCube();

            // Redraw the 3D scene
            helixViewport.InvalidateVisual();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Check if there are any cubes to delete
            if (cubes.Count > 0)
            {
                // Remove the current cube from the viewport
                helixViewport.Children.Remove(cubeToAdjust);

                // Remove the current cube from the list of cubes
                cubes.Remove(cubeToAdjust);

                // Set the previous cube as the cubeToAdjust
                if (cubes.Count > 0)
                {
                    cubeToAdjust = cubes[cubes.Count - 1];
                }
                else
                {
                    cubeToAdjust = startcube;
                }

                // Redraw the 3D scene
                helixViewport.InvalidateVisual();
            }
        }

        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            int sliderValue = ((TrackBar)sender).Value;

            // Update the position of the cubeToAdjust based on the slider value
            double newPosition = sliderValue / 10.0;
            cubeToAdjust.Center = new Point3D(0, newPosition, 0);
            Console.WriteLine(newPosition);

            // Redraw the 3D scene
            helixViewport.InvalidateVisual();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out X1))
            {
                if (int.TryParse(textBox3.Text, out Z1))
                {
                    if (int.TryParse(textBox2.Text, out Y1))
                    {
                        cubeToAdjust.Center = new Point3D(Z1, X1, Y1);
                        helixViewport.InvalidateVisual();
                    }
                }
            }
            else
            {

            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out R2))
            {
                if (int.TryParse(textBox4.Text, out R))
                {
                    // Create a rotation transformation
                    var rotation = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), R));

                    // Apply the rotation to the cube
                    cubeToAdjust.Transform = rotation;

                    // Redraw the 3D scene
                    helixViewport.InvalidateVisual();
                }
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out R))
            {
                if (int.TryParse(textBox5.Text, out R2))
                {
                    // Create a rotation transformation
                    var rotation = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), R2));

                    // Apply the rotation to the cube
                    cubeToAdjust.Transform = rotation;

                    // Redraw the 3D scene
                    helixViewport.InvalidateVisual();
                }
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out Y1))
            {
                if (int.TryParse(textBox1.Text, out X1))
                {
                    if (int.TryParse(textBox3.Text, out Z1))
                    {
                        cubeToAdjust.Center = new Point3D(Z1, X1, Y1);
                        helixViewport.InvalidateVisual();
                    }
                }
            }
            else
            {

            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out Z1))
            {
                if (int.TryParse(textBox1.Text, out X1))
                {
                    if (int.TryParse(textBox2.Text, out Y1))
                    {
                        cubeToAdjust.Center = new Point3D(Z1, X1, Y1);
                        helixViewport.InvalidateVisual();
                    }
                }
            }
            else
            {

            }
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(lengthTextBox.Text, out double length))
            {
                cubeToAdjust.Length = length;
                helixViewport.InvalidateVisual();
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(widthTextBox.Text, out double width))
            {
                cubeToAdjust.Width = width;
                helixViewport.InvalidateVisual();
            }
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(heightTextBox.Text, out double height))
            {
                cubeToAdjust.Height = height;
                helixViewport.InvalidateVisual();
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (totalCubes > 0)
            {
                currentCubeIndex = (currentCubeIndex - 1 + totalCubes) % totalCubes;
                cubeToAdjust = cubes[currentCubeIndex];
                UpdateTextBoxesFromCurrentCube();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (totalCubes > 0)
            {
                currentCubeIndex = (currentCubeIndex + 1) % totalCubes;
                cubeToAdjust = cubes[currentCubeIndex];
                UpdateTextBoxesFromCurrentCube();
            }
        }

        private void UpdateTextBoxesFromCurrentCube()
        {
            // Update the textboxes with the properties of the current cube
            textBox1.Text = cubeToAdjust.Center.Y.ToString();
            textBox2.Text = cubeToAdjust.Center.Z.ToString();
            textBox3.Text = cubeToAdjust.Center.X.ToString();

            // Check if the cubeToAdjust has a RotateTransform3D
            if (cubeToAdjust.Transform is RotateTransform3D rotateTransform)
            {
                // Update rotation-related textboxes
                textBox4.Text = ((AxisAngleRotation3D)rotateTransform.Rotation).Angle.ToString();
                textBox5.Text = ((AxisAngleRotation3D)rotateTransform.Rotation).Axis.Y.ToString();
            }
            else
            {
                // Handle the case when the transformation is not a RotateTransform3D
                textBox4.Text = "0";
                textBox5.Text = "0";
            }

            lengthTextBox.Text = cubeToAdjust.Length.ToString();
            widthTextBox.Text = cubeToAdjust.Width.ToString();
            heightTextBox.Text = cubeToAdjust.Height.ToString();
            slider1.Value = (int)(cubeToAdjust.Center.Y * 10); // Adjust the slider value if needed
        }

        private string GenerateJson()
        {
            // Create a list to store cube information
            List<List<object>> aabbsList = new List<List<object>>();

            // Iterate through each cube and add its information to the list
            foreach (var cube in cubes)
            {
                // Exclude cube2 from the JSON data
                if (cube != bancube)
                {
                    var aabb = new List<object>
            {
                cube.Center.X, cube.Center.Y, cube.Center.Z,
                cube.Width, cube.Height, cube.Length,
                "def", "def", "def", "def", "def", "def"
            };

                    aabbsList.Add(aabb);
                }
            }

            // Create the JSON structure
            var jsonData = new
            {
                texture = "def",
                model = "custom",
                modelPrimitives = new
                {
                    aabbs = aabbsList
                }
            };

            // Get the current directory
            string currentDirectory = Environment.CurrentDirectory;

            // Combine the current directory with the file name
            string filePath = Path.Combine(currentDirectory, "output.json");

            try
            {
                // Write the JSON data to the file
                File.WriteAllText(filePath, $"\"aabbs\": [{string.Join(", ", aabbsList.Select(aabb => $"[{string.Join(", ", aabb)}]"))}]");

                // Provide feedback to the user
                MessageBox.Show($"JSON file created successfully at {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file IO errors)
                MessageBox.Show($"Error creating JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the file path (optional)
            return filePath;
        }
    }
}