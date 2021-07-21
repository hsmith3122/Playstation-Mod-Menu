using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMonitorHook
{
    public partial class AddRapidFireDialog : Form
    {
        Key aDPad, rDPad;
        Hackbox hackbox;

        bool isEditing = false;
        string originalName = "";
        char enabled = 't';

        public AddRapidFireDialog(Hackbox hackbox)
        {
            this.hackbox = hackbox;
            InitializeComponent();
        }

        public AddRapidFireDialog(Hackbox hackbox, string name, Keys act, Keys rap, bool enable)
        {
            this.hackbox = hackbox;
            InitializeComponent();

            originalName = name;
            isEditing = true;
            this.modName.Text = name;

            for (int i = 0; i < act.Length; i++)
            {
                Console.WriteLine("Key {0}: {1}", i + 1, act.ElementAt(i));
            }
            
            foreach(Key key in act) {
                switch (key.name)
                {
                    case "Triangle": this.clbaShapes.SetItemChecked(0, true); break;
                    case "X": this.clbaShapes.SetItemChecked(3, true); break;
                    case "Square": this.clbaShapes.SetItemChecked(2, true); break;
                    case "Circle": this.clbaShapes.SetItemChecked(1, true); break;
                    case "L1": this.clbaBumpers.SetItemChecked(0, true); break;
                    case "L2": this.clbaBumpers.SetItemChecked(1, true); break;
                    case "L3": this.clbaBumpers.SetItemChecked(2, true); break;
                    case "R1": this.clbaBumpers.SetItemChecked(3, true); break;
                    case "R2": this.clbaBumpers.SetItemChecked(4, true); break;
                    case "R3": this.clbaBumpers.SetItemChecked(5, true); break;
                    case "Options": this.clbaShapes.SetItemChecked(4, true); break;
                    case "Touchpad": this.clbaShapes.SetItemChecked(4, true); break;
                    case "N": dpadNone_Click(this.dpadaGroup, null); this.dpadaN.Checked = true; break;
                    case "E": dpadNone_Click(this.dpadaGroup, null); this.dpadaE.Checked = true; break;
                    case "W": dpadNone_Click(this.dpadaGroup, null); this.dpadaW.Checked = true; break;
                    case "S": dpadNone_Click(this.dpadaGroup, null); this.dpadaS.Checked = true; break;
                    case "NW": dpadNone_Click(this.dpadaGroup, null); this.dpadaNW.Checked = true; break;
                    case "NE": dpadNone_Click(this.dpadaGroup, null); this.dpadaNE.Checked = true; break;
                    case "SW": dpadNone_Click(this.dpadaGroup, null); this.dpadaSW.Checked = true; break;
                    case "SE": dpadNone_Click(this.dpadaGroup, null); this.dpadaSE.Checked = true; break;
                }
            }

            foreach (Key key in rap)
            {
                switch (key.name)
                {
                    case "Triangle": this.clbrShapes.SetItemChecked(0, true); break;
                    case "X": this.clbrShapes.SetItemChecked(3, true); break;
                    case "Square": this.clbrShapes.SetItemChecked(2, true); break;
                    case "Circle": this.clbrShapes.SetItemChecked(1, true); break;
                    case "L1": this.clbrBumpers.SetItemChecked(0, true); break;
                    case "L2": this.clbrBumpers.SetItemChecked(1, true); break;
                    case "L3": this.clbrBumpers.SetItemChecked(2, true); break;
                    case "R1": this.clbrBumpers.SetItemChecked(3, true); break;
                    case "R2": this.clbrBumpers.SetItemChecked(4, true); break;
                    case "R3": this.clbrBumpers.SetItemChecked(5, true); break;
                    case "Options": this.clbrShapes.SetItemChecked(4, true); break;
                    case "Touchpad": this.clbrShapes.SetItemChecked(4, true); break;
                    case "N": dpadNone_Click(this.dpadrGroup, null); this.dpadrN.Checked = true; break;
                    case "E": dpadNone_Click(this.dpadrGroup, null); this.dpadrE.Checked = true; break;
                    case "W": dpadNone_Click(this.dpadrGroup, null); this.dpadrW.Checked = true; break;
                    case "S": dpadNone_Click(this.dpadrGroup, null); this.dpadrS.Checked = true; break;
                    case "NW": dpadNone_Click(this.dpadrGroup, null); this.dpadrNW.Checked = true; break;
                    case "NE": dpadNone_Click(this.dpadrGroup, null); this.dpadrNE.Checked = true; break;
                    case "SW": dpadNone_Click(this.dpadrGroup, null); this.dpadrSW.Checked = true; break;
                    case "SE": dpadNone_Click(this.dpadrGroup, null); this.dpadrSE.Checked = true; break;
                }
            }

            this.delete.Visible = true;

            enabled = (enable) ? 't' : 'f';
        }

        private void dpad_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "dpadaN": aDPad = Key.DPad(Direction.N); break;
                    case "dpadaS": aDPad = Key.DPad(Direction.S); break;
                    case "dpadaE": aDPad = Key.DPad(Direction.E); break;
                    case "dpadaW": aDPad = Key.DPad(Direction.W); break;
                    case "dpadaNE": aDPad = Key.DPad(Direction.NE); break;
                    case "dpadaNW": aDPad = Key.DPad(Direction.NW); break;
                    case "dpadaSE": aDPad = Key.DPad(Direction.SE); break;
                    case "dpadaSW": aDPad = Key.DPad(Direction.SW); break;



                    case "dpadrN": rDPad = Key.DPad(Direction.N); break;
                    case "dpadrS": rDPad = Key.DPad(Direction.S); break;
                    case "dpadrE": rDPad = Key.DPad(Direction.E); break;
                    case "dpadrW": rDPad = Key.DPad(Direction.W); break;
                    case "dpadrNE": rDPad = Key.DPad(Direction.NE); break;
                    case "dpadrNW": rDPad = Key.DPad(Direction.NW); break;
                    case "dpadrSE": rDPad = Key.DPad(Direction.SE); break;
                    case "dpadrSW": rDPad = Key.DPad(Direction.SW); break;
                }
            }
            else if (rb.Name.Contains("r"))
            {
                rDPad = null;
            }
            else
            {
                aDPad = null;
            }

        }

        private void dpadNone_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (box.Name.Equals("dpadaNone"))
            {
                this.dpadaE.Checked = false;
                this.dpadaS.Checked = false;
                this.dpadaW.Checked = false;
                this.dpadaN.Checked = false;
                this.dpadaNE.Checked = false;
                this.dpadaSE.Checked = false;
                this.dpadaSW.Checked = false;
                this.dpadaNW.Checked = false;
                aDPad = null;
            }
            else
            {
                this.dpadrE.Checked = false;
                this.dpadrS.Checked = false;
                this.dpadrW.Checked = false;
                this.dpadrN.Checked = false;
                this.dpadrNE.Checked = false;
                this.dpadrSE.Checked = false;
                this.dpadrSW.Checked = false;
                this.dpadrNW.Checked = false;
                rDPad = null;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (hackbox.Rapidfire_HasMod(this.modName.Text))
            {
                this.modName.BackColor = Color.FromArgb(225, 25, 25);
                return;
            }

            if (isEditing)
            {
                hackbox.Rapidfire_Delete(originalName);
            }

            Keys act = new Keys();
            Keys rap = new Keys();

            foreach (object o in this.clbaShapes.CheckedItems)
            {
                act.Add(getKeyFromString(o.ToString()));
            }

            foreach (object o in this.clbaBumpers.CheckedItems)
            {
                act.Add(getKeyFromString(o.ToString()));
            }

            foreach (object o in this.clbrShapes.CheckedItems)
            {
                rap.Add(getKeyFromString(o.ToString()));
            }

            foreach (object o in this.clbrBumpers.CheckedItems)
            {
                rap.Add(getKeyFromString(o.ToString()));
            }

            if (aDPad != null) { act.Add(aDPad); }
            if (rDPad != null) { rap.Add(rDPad); }


            string modname = this.modName.Text;
            if (modname.Length == 0) { modname = "" + DateTime.Now.ToFileTime(); }


            string filetype = @"C:\temp\hax-rapidfire.txt";

            Directory.CreateDirectory(@"C:\temp");
            using (StreamWriter sw = File.AppendText(filetype))
            {
                sw.WriteLine(modname + "," + act + "," + rap + ',' + 't') ;
                sw.Close();
            }


            hackbox.Rapidfire_Add(modname, act, rap);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            hackbox.Rapidfire_Delete(this.originalName);
            this.Close();
        }

        private void modName_TextChanged(object sender, EventArgs e)
        {
            this.modName.Text = this.modName.Text.Replace(',', '.');
        }

        private Key getKeyFromString(string s)
        {
            switch (s)
            {
                case "Triangle": return Key.Triangle;
                case "Cross": return Key.X;
                case "Square": return Key.Square;
                case "Circle": return Key.Circle;
                case "L1": return Key.L1;
                case "L2": return Key.L2();
                case "L3": return Key.L3;
                case "R1": return Key.R1;
                case "R2": return Key.R2();
                case "R3": return Key.R3;
                case "Options": return Key.Options;
                case "Touchpad": return Key.TPad;
                case "N": return Key.DPad(Direction.N);
                case "E": return Key.DPad(Direction.E);
                case "W": return Key.DPad(Direction.W);
                case "S": return Key.DPad(Direction.S);
                case "NW": return Key.DPad(Direction.NW);
                case "NE": return Key.DPad(Direction.NE);
                case "SW": return Key.DPad(Direction.SW);
                case "SE": return Key.DPad(Direction.SE);
            }
            return null;
        }


    }
}
