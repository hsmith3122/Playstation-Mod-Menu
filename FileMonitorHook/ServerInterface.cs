// RemoteFileMonitor (File: FileMonitorHook\ServerInterface.cs)
//
// Copyright (c) 2017 Justin Stenning
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// Please visit https://easyhook.github.io for more information
// about the project, latest updates and other tutorials.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileMonitorHook.DS4Input;

namespace FileMonitorHook
{
    /// <summary>
    /// Provides an interface for communicating from the client (target) to the server (injector)
    /// </summary>
    public class ServerInterface : MarshalByRefObject
    {

        public bool requestShutdown = false;


        public RapidFireHelper RapidFire;
        public KeyMonitor KeyMonitor;
        public DS4Input DS4Input;
        public MacroManager MacroManager;
        public HairTrigger HairTrigger;

        public Keys lastKeys = new Keys();
        public Keys rawLastKeys = new Keys();

        public Keys rawKeys = new Keys();

        public List<MacroMod> macros = new List<MacroMod>();
        public MacroMod activeMacro = null;
        public Keys macroStep = null;
        public int macroCounter = 0;

        public void IsInstalled(int clientPID)
        {
            
        }

        public ServerInterface()
        {
            RapidFire = new RapidFireHelper(this);
            KeyMonitor = new KeyMonitor(this);
            DS4Input = new DS4Input(this);
            MacroManager = new MacroManager(this);
            HairTrigger = new HairTrigger(this);
        }

        /// <summary>
        /// Output the message to the console.
        /// </summary>
        /// <param name="fileNames"></param>
        public void ReportMessages(string[] messages)
        {
        }

        public void ReportMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ReportMessage(string message, params object[] objects)
        {
            Console.WriteLine(message, objects);
        }

        /// <summary>
        /// Report exception
        /// </summary>
        /// <param name="e"></param>
        public void ReportException(Exception e)
        {
            Console.WriteLine("The target process has reported an error:\r\n" + e.ToString());
        }

        public int count;
        /// <summary>
        /// Called to confirm that the IPC channel is still open / host application has not closed
        /// </summary>
        public unsafe void Ping()
        {
            count++;

            // Check if there's an active macro so we can increment the steps
            if (activeMacro != null)
            {

                // Check if there's room to increment steps
                if (macroCounter < activeMacro.numSteps())
                {
                    Console.WriteLine("Active Macro Step: {0}", macroCounter);
                    // Increment the counter and store this step
                    macroStep = activeMacro.steps.ElementAt(macroCounter);
                    macroCounter++;
                }
                else
                {
                    Console.WriteLine("Nullifying Active Macro");
                    // Reset and nulliy all
                    macroStep = null;
                    macroCounter = 0;
                    activeMacro = null;
                }
                
            }
            //Console.WriteLine("Has Active Macro: {0}", activeMacro != null);
        }
        public void setActiveMacro(MacroMod mod) {
            activeMacro = mod;
            macroCounter = 0;
            macroStep = (mod == null) ? null : mod.steps.First();
        }


        public bool checkMacro(int index)
        {
            return macros.ElementAt(index).shouldBeActivated(rawLastKeys, rawKeys);
        }

        public unsafe void runMacro(int index, ref byte* input)
        {
            macros.ElementAt(index).runMacro(ref input);
        }

        public List<MacroMod> getMacros() { return macros; }


    }

    [Serializable]
    public class RapidFireHelper
    {
        public static ServerInterface server;

        public Dictionary<string, Keys[]> mods;
        public Dictionary<string, bool> enabled;

        public RapidFireHelper(ServerInterface server) {
            RapidFireHelper.server = server;
            mods = new Dictionary<string, Keys[]>();
            enabled = new Dictionary<string, bool>(); ;
        }


        public void clear() {
            mods.Clear();
            enabled.Clear();
            load();
        }

        public void load() {
            server.KeyMonitor.clearRapidFire();
            server.KeyMonitor.addRapidFire(mods, enabled);
        }

        public void add(string name, Keys activators, Keys rapidfires)
        {
            if (mods.ContainsKey(name)) { mods.Remove(name); }
            mods.Add(name, new Keys[] { activators, rapidfires });

            if (enabled.ContainsKey(name)) { enabled.Remove(name); }
            enabled.Add(name, true);
        }

        public void transfer(Dictionary<string, Keys[]> mods, Dictionary<string, bool> enabled)
        {
            this.mods.Clear();
            this.enabled.Clear();

            for(int i = 0; i < mods.Count; i++)
            {
                KeyValuePair<string, Keys[]> mod = mods.ElementAt(i);
                KeyValuePair<string, bool> enable = enabled.ElementAt(i);

                this.mods.Add(mod.Key, mod.Value);
                this.enabled.Add(enable.Key, enable.Value);
            }
            server.KeyMonitor.clearRapidFire();
            server.KeyMonitor.addRapidFire(mods, enabled);
        }

        
    }

    [Serializable]
    public class MacroManager
    {
        public ServerInterface server;
        public List<MacroMod> mods = new List<MacroMod>(); 

        public MacroManager(ServerInterface server) { this.server = server; }

        public void transfer(List<MacroMod> mods) { this.mods = mods;  server?.KeyMonitor?.setMacros(mods); }
    }

    [Serializable]
    public class HairTrigger
    {
        public ServerInterface server;
        public HairTrigger(ServerInterface server) { this.server = server; }

        public void apply(int L2min, int L2max, int R2min, int R2max)
        {
            Console.WriteLine("Applying Hair Trigger");
            server?.KeyMonitor?.addHairTrigger(L2min, L2max, R2min, R2max);
        }
    }
}
