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
using static FileMonitorHook.DS4Input;

namespace FileMonitorHook
{
    public partial class MacroRecorderDialog : Form
    {
        public Hackbox hackbox;

        public MacroMod macro;
        public string name;
        public ServerInterface server;
        public Timer serverChecker, aktimer;

        public Keys activators;
        private int counter;

        public bool isRecording = false;
        public int lastCount = -1;
        public MacroRecorderDialog(Hackbox hackbox, ServerInterface server)
        {
            InitializeComponent();
            this.hackbox = hackbox;
            this.server = server;

            macro = new MacroMod(Keys.get(), true);

            initialize();
        }

        private void initialize()
        {
            if (this.server == null)
            {
                this.macrosRecord.Visible = false;
            }
            else
            {
                this.macrosHint.Visible = false;
                this.macrosNameLabel.Visible = true;
                this.macrosName.Visible = true;
                this.setActivators.Visible = true;
                this.keysLabel.Visible = true;
                this.mode.Visible = true;
                this.setMode.Visible = true;
                this.macrosNameLabel.Visible = true;
                this.macrosName.Visible = true;
                this.macrosList.Visible = true;

                serverChecker = new Timer();
                serverChecker.Tick += new EventHandler((sender, e) =>
                {
                    if (server != null && isRecording)
                    {
                        if (server.count > lastCount)
                        {
                            macro.addStep(server.lastKeys);
                        }
                    }
                });
                serverChecker.Interval = 1;


                aktimer = new Timer();
                aktimer.Tick += new EventHandler((obj, eventArgs) =>
                {
                    if (lastCount == server.count) { return; }
                    if (!activators.Equals(server.rawLastKeys))
                    {
                        activators = server.rawLastKeys;
                        activatorKeys.Text = activators.ToString().Replace('\t', ' ');
                        counter = 0;
                        return;
                    }
                    if (counter++ >= 50)
                    {
                        macro.activators = activators;
                        activatorKeys.ForeColor = Color.FromArgb(64, 200, 100);
                        macrosRecord.Enabled = true;
                        aktimer.Stop();
                        return;
                    }

                });
                aktimer.Interval = 1;



                if (this.hackbox.macrosSelected != null)
                {
                    this.macrosName.Text = this.hackbox.macrosSelected.Value.Key;
                    this.macro = this.hackbox.macrosSelected.Value.Value;
                    displayMacro();
                    this.macrosSave.Visible = true;
                    this.activators = this.macro.activators;
                    this.activatorKeys.Text = this.activators.ToString();
                    this.mode.Text = (this.macro.toggle) ? "Toggle" : "Hold";
                    this.activatorKeys.ForeColor = Color.FromArgb(64, 200, 100);
                    this.macrosTrim.Visible = true;
                }
            }
        }

        private void macrosRecord_Click(object sender, EventArgs e)
        {
            if (isRecording) // Stop was clicked
            {
                isRecording = false;
                macrosRecord.Text = "Record";
                displayMacro();
                serverChecker.Stop();
                setActivators.Enabled = true;
            }
            else
            {
                isRecording = true;
                macrosRecord.Text = "Stop";
                macro.resetSteps();
                setActivators.Enabled = false;
                serverChecker.Start();
            }
            
            this.macrosTrim.Visible = !isRecording && macro.numSteps() > 0;
            this.macrosSave.Visible = !isRecording && macro.numSteps() > 0;
        }

        private void macrosTrim_Click(object sender, EventArgs e)
        {
            macro.trim();
            displayMacro();
        }

        private void displayMacro()
        {
            macrosList.Items.Clear();
            foreach (Keys keys in macro.steps)
            {
                macrosList.Items.Add(keys.ToString());
            }
        }

        private void macrosSave_Click(object sender, EventArgs e)
        {
            if (this.hackbox.macrosSelected != null)
            {
                if (!this.hackbox.macrosSelected.Value.Key.Equals(this.macrosName.Text))
                {
                    File.Move(@"C:\temp\macros\"+ this.hackbox.macrosSelected.Value.Key + ".txt", @"C:\temp\macros\" + this.macrosName.Text + ".txt");
                    this.hackbox.macrosList.Remove(this.hackbox.macrosSelected.Value.Key);
                    this.hackbox.macrosUpdateDisplay();
                }
            }


            if (macrosName.Text.Trim().Length == 0)
            {
                macrosName.Text = "" + DateTime.Now.ToFileTime();
            }
            string filetype = @"C:\temp\macros\" + macrosName.Text + ".txt";
            Directory.CreateDirectory(@"C:\temp");
            Directory.CreateDirectory(@"C:\temp\macros");
            using (StreamWriter sw = new StreamWriter(filetype, false))
            {
                sw.WriteLine(activators.ToString()); // Append Activator Keys
                sw.WriteLine((macro.toggle) ? "t" : "f");
                foreach (Keys step in macro.steps)
                {
                    sw.WriteLine(step.ToString());
                }
                sw.Close();
            }

            hackbox.addMacro(macrosName.Text, macro);

        }

        private void macrosCancel_Click(object sender, EventArgs e)
        {
            // Close the shit
        }

        private void setActivators_Click(object sender, EventArgs e)
        {

            macrosRecord.Enabled = false;
            activatorKeys.ForeColor = Color.LightSlateGray;

            activators = server.rawLastKeys;
            activatorKeys.Text = activators.ToString().Replace('\t', ' ');

            counter = 0;
            int lastCount = server.count;

            aktimer.Start();
            
        }

        private void setMode_Click(object sender, EventArgs e)
        {
            macro.setToggle(!macro.toggle);
            if  (macro.toggle)  { mode.Text = "Toggle"; }
            else                { mode.Text = "Hold"; }
        }
    }
}
