using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace SB_Item_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form3 form3 = new Form3();
            form3.Show();
            colorname.Text = "R = 255" + Environment.NewLine + "G = 0" + Environment.NewLine + "B = 0";
        }

        public static string colorr="255",colorg="255",colorb="255",item;
        SolidBrush stringbrush = new SolidBrush(Color.Red);

        private void button1_Click(object sender, EventArgs e)
        {
            Value.itemname = weaponname.Text;
            string itemlevel = "\"tier1\" : [";
            string path = @"C:\Program Files (x86)\Steam\SteamApps\common\Starbound\mods\assets\player.config";
            string newitemlist = @"      { ""item"" : """ + Value.itemname + "\" },";
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace(itemlevel, itemlevel+Environment.NewLine+newitemlist);
            }

            File.WriteAllLines(path, lines);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Value.directory == @"C:\Program Files (x86)\Steam\SteamApps\common\Starbound")
            {
                Value.direcselected = true;
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }
        Color color;
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog1 = new ColorDialog();
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = ColorDialog1.Color;
                colorr = ColorDialog1.Color.R.ToString();
                colorg = ColorDialog1.Color.G.ToString();
                colorb = ColorDialog1.Color.B.ToString();
                colorname.Text = "R = "+colorr+Environment.NewLine+"G = "+colorg+Environment.NewLine+"B = "+colorb;
                //button2.ForeColor = Color.FromArgb(ColorDialog1.Color.G, ColorDialog1.Color.B, ColorDialog1.Color.R);
                color = Color.FromArgb(110,ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = comboBox1.SelectedItem.ToString();
            raritybox.Enabled = false;
            gunnamebox.Enabled = false;
            twohandbox.Enabled = false;
            ratesbox.Enabled = false;
            projbox.Enabled = false;
            colorbox.Enabled = false;
            levelnum.Enabled = false;

            checkedListBox1.Enabled = false;
            if (item == "Gun")
            {
                raritybox.Enabled = true;
                levelnum.Enabled = true;
                gunnamebox.Enabled = true;
                twohandbox.Enabled = true;
                ratesbox.Enabled = true;
                projbox.Enabled = true;
                colorbox.Enabled = true;
            }
            else if (item == "Armor")
            {
            }
            else if (item == "Melee")
            {
            }
            else if (item == "Building Block")
            {
            }
            else if (item == "Shield")
            {
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked)
            {
                return;
            }
            CheckedListBox.CheckedIndexCollection selectedItems = this.checkedListBox1.CheckedIndices;
            if (selectedItems.Count > 0)
            {
                this.checkedListBox1.SetItemChecked(selectedItems[0], false);
            }
        }

        private void raritybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value.itemrarity = raritybox.SelectedItem.ToString().ToLower();
            //label2.Text = Value.itemrarity;  //Shows results on label2
        }

        private void maxstack_TextChanged(object sender, EventArgs e)
        {
            Value.maxstack = maxstack.Text; 
        }

        private void recoiltime_TextChanged(object sender, EventArgs e)
        {
            Value.recoiltime = recoiltime.Text;     
        }

        private void firetime_TextChanged(object sender, EventArgs e)
        {
            Value.firetime = firetime.Text;
        }

        private void updatecode_Click(object sender, EventArgs e)
        {
            Value.itemfilename = Value.itemname.ToLower();
            Value.itemfilename = Value.itemfilename.Replace(" ", string.Empty);
            gun.updatestrings();
            rawcode.Text = gun.@base;
        }

        private void guntwohanded_CheckedChanged(object sender, EventArgs e)
        {
            if (Value.guntwohanded == false)
            {
                Value.guntwohanded = guntwohanded.Checked;
            }
            else if (Value.guntwohanded == true)
            {
                Value.guntwohanded = false;
            }
        }

        private void rawclear_Click(object sender, EventArgs e)
        {
            rawcode.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int j = 0; j < this.Butt.Images.Count; j++)
            {

                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                this.listView1.Items.Add(item);

            }
            for (int j = 0; j < this.Middle.Images.Count; j++)
            {

                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                this.listView2.Items.Add(item);

            }
            for (int j = 0; j < this.Barrel.Images.Count; j++)
            {

                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                this.listView3.Items.Add(item);

            }

        }
        //int key;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //key = listView1.SelectedIndices[0];
            //buttpicture.Image = ;
            //this.listView1.SelectedItems.Clear();
            //this.listView1.Update();
            //label7.Text = Convert.ToString(key);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reserved for middle
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reserved for barrel
        }

        private void levelnum_ValueChanged(object sender, EventArgs e)
        {
            Value.itemlevel = levelnum.Value.ToString();
        }

        private void weaponname_TextChanged(object sender, EventArgs e)
        {
            Value.itemname = weaponname.Text;
        }

        private void maindesc_TextChanged(object sender, EventArgs e)
        {
            Value.description = maindesc.Text;
        }

        private void bowcheck_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, Bow is not yet working.");
        }

        private void projtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value.projtype = projtype.Text.ToLower();
            Value.projtype = Value.projtype.Replace(" ", String.Empty);
            projpicture.Image = Bullets.Images[Value.projtype+".png"];
            //projpicture.Invalidate();
        }

        private void projpicture_Paint(object sender, PaintEventArgs e)
        {
            if (projpicture.Image == Bullets.Images[Value.projtype + ".png"])
            {
                
            }
        }
    }
}
