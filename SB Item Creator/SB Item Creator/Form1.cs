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
            recipe.creation();
        }

        public static string colorr="255",colorg="255",colorb="255",item;
        SolidBrush stringbrush = new SolidBrush(Color.Red);

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Value.pathsave + "\\CurrentDirectory.TXT") == true)
            {
                Value.dirready = true;
                Value.directory = File.ReadAllText(Value.pathsave + "\\CurrentDirectory.TXT");
            }
            if (Value.dirready == false)
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

            checkedListBox1.Enabled = false;
            if (item == "Gun")
            {
                raritybox.Enabled = true;
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

        private void updatecode_Click(object sender, EventArgs e)
        {
            Value.itemfilename = Value.itemname.ToLower();
            Value.itemfilename = Value.itemfilename.Replace(" ", string.Empty);
            gun.updatestrings();
            gun.creation(Value.recoil, Value.level);
            rawcode.Text = gun.@base+gun.sl24;
            recipe.updatevalus();
            recipe.creation();
            recipe.create3 = "";
            for (int x = 0; x < itemlist.Items.Count; x++)
            {
                if (itemlist.Items.Count - 1 > x)
                {
                    recipe.create3 += itemlist.Items[x].ToString() + "," + Environment.NewLine;
                }
                else if (itemlist.Items.Count - 1 == x)
                {
                    recipe.create3 += itemlist.Items[x].ToString() + Environment.NewLine;
                    x = itemlist.Items.Count;
                }
            }
            rawrecipe.Text = recipe.create + recipe.create3 + recipe.create2;
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

        private void speednum_ValueChanged(object sender, EventArgs e)
        {
            Value.speed = Convert.ToString(speednum.Value);
        }

        private void Firetime_ValueChanged(object sender, EventArgs e)
        {
            Value.firetime = Convert.ToString(Firetime.Value);
        }

        private void recoiltime_ValueChanged(object sender, EventArgs e)
        {
            Value.recoiltime = Convert.ToString(recoiltime.Value);  
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Value.level == false)
            {
                levelnum.Enabled = true;
                Value.level = true;
            }
            else if (Value.level == true)
            {
                levelnum.Enabled = false;
                Value.level = false;
                if (checkBox3.Checked == true)
                {
                    checkBox3.Checked = false;
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (Value.recoil == false)
            {
                recoiltime.Enabled = true;
                Value.recoil = true;
            }
            else if (Value.recoil == true)
            {
                recoiltime.Enabled = false;
                Value.recoil = false;
                if (checkBox4.Checked == true)
                {
                    checkBox4.Checked = false;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value.blueprinttier = comboBox3.Text.ToLower();
            Value.blueprinttier = Value.blueprinttier.Replace(" ", String.Empty);

        }

        private void diToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void craftingstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (craftingstation.Text.ToString() == "Other (Custom)")
            {
                othername.Enabled = true;
            }
            else if (craftingstation.Text.ToString() != "Other (Custom)")
            {
                othername.Enabled = false;
                Value.craftingstation = craftingstation.Text.ToString();
                Value.craftingstation = Value.craftingstation.ToLower();
                Value.craftingstation = Value.craftingstation.Replace(" ", String.Empty);
            }

        }

        private void othername_TextChanged(object sender, EventArgs e)
        {
            Value.craftingstation = othername.Text;
        }

        private void amountmade_ValueChanged(object sender, EventArgs e)
        {
            Value.im = amountmade.Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value.item1 = comboBox2.Text.ToString();
        }

        private void itemnum_ValueChanged(object sender, EventArgs e)
        {
            Value.ita1 = Convert.ToString(itemnum.Value.ToString());
        }

        private void additem_Click(object sender, EventArgs e)
        {
            if (itemlist.Items.Count <= 5)
            {
                if (comboBox2.Text.ToString() != string.Empty)
                {
                    recipe.updateitem();
                    itemlist.BeginUpdate();
                    itemlist.Items.Add(recipe.rp3);
                    itemlist.EndUpdate();
                }
                else
                {
                    MessageBox.Show("Please select an item from the list" + Environment.NewLine + "before trying to add it.");
                }
            }
            else
            {
                MessageBox.Show("You have reached the max amount of items." + Environment.NewLine + "Remove some if you want to add more.");
            }
        }

        private void removeitem_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemlist.Items.Count > 0)
                {
                    if (itemlist.SelectedIndex != -1)
                    {
                        itemlist.BeginUpdate();
                        itemlist.Items.RemoveAt(itemlist.SelectedIndex);
                        itemlist.EndUpdate();
                    }
                    else
                    {
                        MessageBox.Show("You need to select an item to remove first.");
                    }
                }
                else
                {
                    MessageBox.Show("Please add an item first before" + Environment.NewLine + "trying to remove an item.");
                }
            }
            catch
            {
                MessageBox.Show("There has been an error with trying to remove an item." + Environment.NewLine + "Please try again.");
            }
        }

    }
}
