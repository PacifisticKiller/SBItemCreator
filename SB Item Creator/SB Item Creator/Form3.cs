using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SB_Item_Creator
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You must first select a directory.");
            }
            else
            {
                if (textBox1.Text.Contains("Starbound"))
                {
                    Value.directory = textBox1.Text;
                    if (Value.direcselected == true)
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        Value.direcselected = false;
                    }
                    this.Close();
                    System.IO.File.WriteAllText(Value.pathsave+"\\CurrentDirectory.TXT", Value.directory);
                }
                else
                {
                    MessageBox.Show("Please select your Starbound directory");
                }
                
            }
        }
    }
}
