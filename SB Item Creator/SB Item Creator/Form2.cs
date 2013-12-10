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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string path = Value.directory + @"\mods\";
        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                MessageBox.Show("Successfully created folder \"mods\" at"+Environment.NewLine+Value.directory);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                MessageBox.Show("Successfully created folder \"mods\" at" + Environment.NewLine + Value.directory);
            }
        }
    }
}
