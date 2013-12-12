using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SB_Item_Creator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string path = System.IO.Path.Combine(Value.directory,"mods");
        string path2 = System.IO.Path.Combine(Value.directory, "assets");
        string file1;
        string file2;

        public void checkfordirectory()
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                path = System.IO.Path.Combine(path, Value.itemfilename);
                path = System.IO.Path.Combine(path, "assets");
                path = System.IO.Path.Combine(path, "items");
                path = System.IO.Path.Combine(path, "guns");
                path = System.IO.Path.Combine(path, Value.itemfilename);
                System.IO.Directory.CreateDirectory(path);
                path = System.IO.Path.Combine(Value.directory, "mods");
                path = System.IO.Path.Combine(path, Value.itemfilename);
                path = System.IO.Path.Combine(path, "assets");
                path = System.IO.Path.Combine(path, "recipes");
                path = System.IO.Path.Combine(path, "weapons");
                path = System.IO.Path.Combine(path, "other");
                System.IO.Directory.CreateDirectory(path);
                {
                    path = System.IO.Path.Combine(Value.directory, "mods");
                    path = System.IO.Path.Combine(path, Value.itemfilename);
                    path = System.IO.Path.Combine(path, "assets");
                    file1 = System.IO.Path.Combine(path2, "player.config");
                    file2 = System.IO.Path.Combine(path, "player.config");
                    System.IO.File.Copy(file1, file2);
                }
                MessageBox.Show("Successfully created mod folders at" + Environment.NewLine + Value.directory);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void recipesave_Click(object sender, EventArgs e)
        {
            checkfordirectory();

        }

        public void recipeaddpfile()
        {
            path = Value.directory;
            path = System.IO.Path.Combine(path, "mods");
            path = System.IO.Path.Combine(path, Value.itemfilename);
            path = System.IO.Path.Combine(path, "assets");
            if (System.IO.File.Exists(path + "\\player.config") == true)
            {
                addrecipe();
                MessageBox.Show("Successfully added the recipe for: " + Value.itemfilename + "." +
                    Environment.NewLine + Value.itemfilename + " was added under " + Value.blueprinttier + " section.");
            }
            path = System.IO.Path.Combine(Value.directory, "mods");
            path = System.IO.Path.Combine(path, Value.itemfilename);
            path = System.IO.Path.Combine(path, "assets");
            path = System.IO.Path.Combine(path, "recipes");
            path = System.IO.Path.Combine(path, "weapons");
            path = System.IO.Path.Combine(path, "other");
            //System.IO.File.WriteAllText(path, );

        }

        public void addrecipe()
        {
            string itemlevel = "\""+Value.blueprinttier+"\" : [";
            string path = Value.directory;
            path = System.IO.Path.Combine(path, "mods");
            path = System.IO.Path.Combine(path, Value.itemfilename);
            path = System.IO.Path.Combine(path, "assets");
            string newitemlist = @"      { ""item"" : """ + Value.itemfilename + "\" },";
            string[] lines = File.ReadAllLines(path+"\\player.config");
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace(itemlevel, itemlevel + Environment.NewLine + newitemlist);
            }

            File.WriteAllLines(path+"\\player.config", lines);
        }
    }
}
