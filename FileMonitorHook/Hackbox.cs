using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FileMonitorHook.DS4Input;
using System.IO;

namespace FileMonitorHook
{
    public partial class Hackbox : Form
    {

        public Dictionary<string, Keys[]> rfmods = new Dictionary<string, Keys[]>();
        public Dictionary<string, bool> rfenabled = new Dictionary<string, bool>();

        public Dictionary<string, MacroMod> macrosList = new Dictionary<string, MacroMod>();
        public KeyValuePair<string, MacroMod>? macrosSelected;

        public List<Panel> pages;



        
        public ServerInterface server;
        public Timer hairTriggerTimer;

        public Hackbox()
        {
            InitializeComponent();

            pages = new List<Panel>();
            pages.Add(this.pageRapidFire);
            pages.Add(this.pageHairTrigger);
            pages.Add(this.pageMacros);

            hairTriggerTimer = new Timer();

            hairTriggerTimer.Tick += new EventHandler((sender, e) => {

                if (server != null)
                {
                    bool cL2 = server.lastKeys.Contains(Key.L2());
                    bool cR2 = server.lastKeys.Contains(Key.R2());

                    if (!cL2) { this.hairTriggerReadingLeft.Text = "No Input"; }
                    if (!cR2) { this.hairTriggerReadingRight.Text = "No Input"; }
                    if (!cL2 && ! cR2) { return; }
                    foreach (Key key in server.lastKeys)
                    {
                        if (key.name == "L2")
                        {
                            this.hairTriggerReadingLeft.Text = (key.value * 100 / 255) + "%";
                        }
                        else if (key.name == "R2")
                        {
                            this.hairTriggerReadingRight.Text = (key.value * 100 / 255) + "%";
                        }
                    }
                }
                
            });

            hairTriggerTimer.Interval = 10;
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void psrpButton_Click(object sender, EventArgs e)
        {
            startProgram(0);
        }

        private void psnowButton_Click(object sender, EventArgs e)
        {
            startProgram(1);
        }

        private void psrnFind_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SaveFileLocation(0, ofd.FileName);
            }
        }

        private void psnowFind_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SaveFileLocation(1, ofd.FileName);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (server != null) { server.requestShutdown = true; }
            this.Close();
        }



        private void pageChange(object sender, EventArgs e) {
            Button pressed = (Button)sender;

            foreach(Panel page in pages)
            {
                page.Visible = pressed.Tag.Equals(page.Name);
                if (page.Name == "pageHairTrigger" && !page.Visible)
                {
                    hairTriggerTimer.Stop();
                }
            }
        }




        private void run(string targetExe)
        {
            Int32 targetPID = 0;
            string channelName = null;
            EasyHook.RemoteHooking.IpcCreateServer<FileMonitorHook.ServerInterface>(ref channelName, System.Runtime.Remoting.WellKnownObjectMode.Singleton);


            string injectionLibrary = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "FileMonitorHook.dll");

            try
            {
                EasyHook.RemoteHooking.CreateAndInject(
                       targetExe,          // executable to run
                       "",                 // command line arguments for target
                       0,                  // additional process creation flags to pass to CreateProcess
                       EasyHook.InjectionOptions.DoNotRequireStrongName, // allow injectionLibrary to be unsigned
                       injectionLibrary,   // 32-bit library to inject (if target is 32-bit)
                       injectionLibrary,   // 64-bit library to inject (if target is 64-bit)
                       out targetPID,      // retrieve the newly created process ID
                       channelName         // the parameters to pass into injected library
                );

            }catch (Exception e)
            {
                // Update visuals. Delete exe location.
            }

            server = EasyHook.RemoteHooking.IpcConnectClient<ServerInterface>(channelName);
            if (this.rapidFireEnable.Text == "Disable") { server.RapidFire.transfer(rfmods, rfenabled); }

            
        }


        private void startProgram(int code)
        {
            string path = "";
            path = getPathFromSave(code);
            if (path.Length > 0)
            {
                run(path);
                return;
            }

            // 2. Open dialog box to select ps remote play exe.
            ofd.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                SaveFileLocation(code, path);
                run(path);
            }
        }

        private void SaveFileLocation(int code, string path)
        {
            string filetype = "";
            switch (code)
            {
                case 0: filetype = @"C:\temp\hax-RPFL.txt"; break;
                case 1: filetype = @"C:\temp\hax-PNFL.txt"; break;
            }
            Directory.CreateDirectory(@"C:\temp");
            using (StreamWriter sw = new StreamWriter(filetype, false))
            {
                sw.WriteLine(path);
                sw.Close();
            }
        }

        private string getPathFromSave(int code)
        {
            string filetype = "";
            switch (code)
            {
                case 0: filetype = @"c:\temp\hax-RPFL.txt"; break;
                case 1: filetype = @"c:\temp\hax-PNFL.txt"; break;
            }

            if (File.Exists(filetype)) {
                using (StreamReader sr = File.OpenText(filetype))
                {
                    return sr.ReadLine();
                }
            }
            else
            {
                return "";
            }
            
        }

        // Rapid Fire Functions

        private void rapidFire_Click(object sender, EventArgs e)
        {
            this.pageRapidFire.BringToFront();
            
        }

        private void rapidFireEnable_Click(object sender, EventArgs e)
        {
            this.rapidFireEnable.Text = (this.rapidFireEnable.Text == "Enable") ? "Disable" : "Enable";
            this.rapidFireList.Visible = this.rapidFireEnable.Text == "Disable";
            this.rapidFireAdd.Visible = this.rapidFireEnable.Text == "Disable";

            this.rapidFireList.SelectedIndex = -1;

            
            if (this.rapidFireEnable.Text == "Disable") { server?.RapidFire.transfer(rfmods, rfenabled); }
            else { server?.RapidFire.transfer(new Dictionary<string, Keys[]>(), new Dictionary<string, bool>()); }
        }

        private void rapidFireAdd_Click(object sender, EventArgs e)
        {
            using (AddRapidFireDialog d = new AddRapidFireDialog(this))
            {
                if (d.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
 
        private void Hackbox_Load(object sender, EventArgs e)
        {
            Rapidfire_Load();
        }

        private Key getKeyFromString(string s)
        {
            switch (s)
            {
                case "Triangle": return Key.Triangle;
                case "X": return Key.X;
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

        private void rapidFireList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rapidFireList.SelectedIndex != -1)
            {
                // Add Toggle, Edit and Delete buttons

                this.rapidFireToggle.Visible = true;
                this.rapidFireEdit.Visible = true;
                this.rapidFireDelete.Visible = true;
                updateToggle(this.rapidFireList.SelectedItem.ToString());
            }
            else
            {
                this.rapidFireToggle.Visible = false;
                this.rapidFireEdit.Visible = false;
                this.rapidFireDelete.Visible = false;
            }
        }

        private void Rapidfire_Load()
        {
            if (File.Exists(@"C:\temp\hax-rapidfire.txt"))
            {
                using (StreamReader mods = File.OpenText(@"C:\temp\hax-rapidfire.txt"))
                {
                    while (!mods.EndOfStream)
                    {
                        string[] line = mods.ReadLine().Split(',');
                        Keys act = new Keys();
                        Keys rap = new Keys();

                        foreach (string s in line[1].Split(' '))
                        {
                            Key key = getKeyFromString(s);
                            if (key != null) { act.Add(key); }
                            
                        }
                        foreach (string s in line[2].Split(' '))
                        {
                            Key key = getKeyFromString(s);
                            if (key != null) { rap.Add(key); }

                        }

                        rfmods.Add(line[0], new Keys[] { act, rap });
                        rfenabled.Add(line[0], (line[3] == "t") ? true : false);
                    }
                }
            }
            Rapidfire_Display();
        }

        private void Rapidfire_Save()
        {
            string file = @"C:\temp\hax-rapidfire.txt";
            Directory.CreateDirectory(@"C:\temp\");
            using (StreamWriter sw = new StreamWriter(file, false))
            {       
                foreach (KeyValuePair<string, Keys[]> pair in rfmods)
                {
                    bool enabled = false;
                    rfenabled.TryGetValue(pair.Key, out enabled);

                    sw.WriteLine(pair.Key + ',' + pair.Value[0] + ',' + pair.Value[1] + ',' + ((enabled) ? 't' : 'f'));
                }
            }

            server?.RapidFire.transfer(rfmods, rfenabled);
        }

        public void Rapidfire_Add(string name, Keys activators, Keys rapidfires)
        {
            Console.WriteLine("{0} -> Added", name);
            if (!rfmods.ContainsKey(name)) { rfmods.Add(name, new Keys[] { activators, rapidfires }); }
            if (!rfenabled.ContainsKey(name)) { rfenabled.Add(name, true); }
            server?.RapidFire.transfer(rfmods, rfenabled);
            Rapidfire_Display();
            
        }

        public void Rapidfire_Delete(string name)
        {
            rfenabled.Remove(name);
            rfmods.Remove(name);
            Rapidfire_Display();

            this.rapidFireToggle.Visible = false;
            this.rapidFireEdit.Visible = false;
            this.rapidFireDelete.Visible = false;

            Rapidfire_Save();
        }

        public bool Rapidfire_HasMod(string name)
        {
            return rfmods.ContainsKey(name);
        }

        private void Rapidfire_Display()
        {
            this.rapidFireList.Items.Clear();
            foreach (string key in rfmods.Keys.ToArray())
            {
                this.rapidFireList.Items.Add(key);
            }
        }

        private void updateToggle(string name)
        {
            bool enabled = false;
            rfenabled.TryGetValue(name, out enabled);
        
            if (enabled)
            {
                this.rapidFireToggle.Text = "Active";
                this.rapidFireToggle.BackColor = Color.FromArgb(100,200,100);
            }
            else
            {
                this.rapidFireToggle.Text = "Inactive";
                this.rapidFireToggle.BackColor = Color.FromArgb(100, 100, 100);
            }
        }

        private void rapidFireToggle_Click(object sender, EventArgs e)
        {
            string name = this.rapidFireList.SelectedItem.ToString();

            bool enabled = false;
            rfenabled.TryGetValue(name, out enabled);

            rfenabled.Remove(name);
            rfenabled.Add(name, !enabled);
            updateToggle(name);

            Console.WriteLine("{0} {1}", name, (!enabled) ? "enabled" : "disabled");

            Rapidfire_Save();
        }

        private void rapidFireEdit_Click(object sender, EventArgs e)
        {
            string selection = this.rapidFireList.SelectedItem.ToString();
            bool enabled = false;
            Keys[] keyss = new Keys[] { Keys.get(), Keys.get() };

            rfmods.TryGetValue(selection, out keyss);
            rfenabled.TryGetValue(selection, out enabled);
            AddRapidFireDialog arfd = new AddRapidFireDialog(this, selection, keyss[0], keyss[1], enabled);

            arfd.ShowDialog();
        }

        private void rapidFireDelete_Click(object sender, EventArgs e)
        {
            string selection = this.rapidFireList.SelectedItem.ToString();
            Rapidfire_Delete(selection);
        }


        // Hair Trigger functions

        private void hairTriggerApply_Click(object sender, EventArgs e)
        {
            server?.HairTrigger.apply(
                    this.hairTriggerMinLeft.Value,
                    this.hairTriggerMaxLeft.Value,
                    this.hairTriggerMinRight.Value,
                    this.hairTriggerMaxRight.Value
            );
            this.hairTriggerApply.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void hairTrigger_Scroll(object sender, EventArgs e)
        {
            TrackBar scrolled = (TrackBar)sender;

            TrackBar min = (scrolled.Name.Contains("Left")) ? this.hairTriggerMinLeft : this.hairTriggerMinRight;
            TrackBar max = (scrolled.Name.Contains("Left")) ? this.hairTriggerMaxLeft : this.hairTriggerMaxRight;

            min.Value = (min.Value > max.Value) ? max.Value : min.Value;
            max.Value = (max.Value < min.Value) ? min.Value : max.Value;

            this.hairTriggerApply.BackColor = Color.FromArgb(64, 255, 124);
        }

        private void hairTriggerEnable_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Disable")
            {
                hairTriggerPanel.Visible = false;
                btn.Text = "Enable";
                hairTriggerTimer.Stop();
                server?.HairTrigger.apply(0, 255, 0, 255);
                this.hairTriggerApply.Visible = false;
            }
            else
            {
                hairTriggerPanel.Visible = true;
                btn.Text = "Disable";
                hairTriggerTimer.Start();
                hairTriggerApply_Click(this, null);
                this.hairTriggerApply.Visible = true;
            }
        }



        // Macros Functions

        private void macrosEnable_Click(object sender, EventArgs e)
        {
            macrosEnable.Text = (macrosEnable.Text == "Enable") ? "Disable" : "Enable";
            
            macroList.Visible = macrosEnable.Text == "Disable";
            macrosAdd.Visible = macroList.Visible;

            if (macrosAdd.Visible && macrosList.Count == 0)
            {
                
                // Get macros folder. Scan all files in macros folder and attempt to make a macro from it.
                string macrosFolder = @"C:\temp\macros\";
                if (Directory.Exists(macrosFolder))
                {
                    List<string> files = Directory.GetFiles(macrosFolder).ToList();
                    foreach(string file in files)
                    {
                        using (StreamReader sr = File.OpenText(file))
                        {
                            string name = file.Substring(macrosFolder.Length, file.Length - macrosFolder.Length - 4);
                            
                            Keys activators = Keys.From(sr.ReadLine());
                            bool toggle = sr.ReadLine().Contains("t");

                            MacroMod macro = new MacroMod(activators, toggle);
                            while (!sr.EndOfStream)
                            {
                                macro.addStep(Keys.From(sr.ReadLine()));
                            }

                            macrosList.Add(name, macro);
                            sr.Close();
                        }
                    }

                    macrosUpdateDisplay();
                }
            }
        }

        private void macrosAdd_Click(object sender, EventArgs e)
        {

            using (MacroRecorderDialog dialog = new MacroRecorderDialog(this, server))
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        public void addMacro(string name, MacroMod mod)
        {
            if (this.macrosList.ContainsKey(name)) { this.macrosList.Remove(name); }
            this.macrosList.Add(name, mod);

            macrosUpdateDisplay();
        }

        public void macrosUpdateDisplay()
        {
            macroList.Items.Clear();
            foreach(KeyValuePair<string, MacroMod> pair in macrosList)
            {
                macroList.Items.Add(pair.Key);
                if (server != null)
                {
                    server.macros = macrosList.Values.ToList();
                    
                }
            }
        }

        private void macroList_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = macroList.SelectedIndex;
            this.macrosActivatorsLabel.Visible = index != -1;
            this.macrosDelete.Visible = this.macrosActivatorsLabel.Visible;
            this.macrosActivators.Visible = this.macrosDelete.Visible;

            if (index != -1)
            {
                KeyValuePair<string, MacroMod> pair = macrosList.ElementAt(index);
                this.macrosActivators.Text = pair.Value.activators.ToString();
                this.macrosAdd.Text = "Edit";
                this.macrosSelected = pair;
                
            }
            else
            {
                this.macrosAdd.Text = "Add";
                this.macrosSelected = null;
            }
            
        }

        private void macrosDelete_Click(object sender, EventArgs e)
        {
            string filename = macrosList.ElementAt(macroList.SelectedIndex).Key;
            File.Delete(@"C:\temp\macros\" + filename + ".txt");
            macrosList.Remove(filename);
            macrosUpdateDisplay();
            macrosDeselectItem(sender, e);
            
        }

        private void macrosDeselectItem(object sender, EventArgs e)
        {
            if (macroList.Items.Count == 0) { return; }
            macroList.SetSelected(0, false);
        }
    }
   
}
