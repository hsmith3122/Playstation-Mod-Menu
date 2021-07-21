using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileMonitorHook.DS4Input;

namespace FileMonitorHook
{
    [Serializable]
    public class KeyMonitor
    {
        public Keys lastKeys = Keys.get();
        public ServerInterface server;

        public enum OnKeys { Down, Held, Up };

        public KeyMonitor(ServerInterface server) { this.server = server; }

        

        // OnKeyEvent Data
        private SortedDictionary<Keys, OnKeyEvent> OnKeyDowns = new SortedDictionary<Keys, OnKeyEvent>(new Key.KeysCompare());
        private SortedDictionary<Keys, OnKeyEvent> OnKeyHelds = new SortedDictionary<Keys, OnKeyEvent>(new Key.KeysCompare());
        private SortedDictionary<Keys, OnKeyEvent> OnKeyUps = new SortedDictionary<Keys, OnKeyEvent>(new Key.KeysCompare());


        // Rapid Fire Data
        private Dictionary<Keys, ShootingMod> shootingMods = new Dictionary<Keys, ShootingMod>();
        
        // Hair Trigger Data
        private HairTriggerMod hairTriggerL2, hairTriggerR2;

        // Macro Data
        public List<MacroMod> macros = new List<MacroMod>();
        public List<int> macroCounters = new List<int>();

        // Data Management Helpers
        public void add(OnKeyEvent OnKeyEvent, Keys keys, params OnKeys[] onKeys)
        {
            if (onKeys.Contains(OnKeys.Down))
            {
                OnKeyDowns.Add(keys, OnKeyEvent);
            }

            if (onKeys.Contains(OnKeys.Held))
            {
                OnKeyHelds.Add(keys, OnKeyEvent);
            }

            if (onKeys.Contains(OnKeys.Up))
            {
                OnKeyUps.Add(keys, OnKeyEvent);
            }
        }

        public void add(OnKeyEvent OnKeyEvent, Key key, params OnKeys[] onKeys)
        {

            add(OnKeyEvent, Keys.get(key), onKeys);
        }

        public void remove(Keys keys, params OnKeys[] onKeys)
        {
            if (onKeys.Contains(OnKeys.Down))
            {
                OnKeyDowns.Remove(keys);
            }

            if (onKeys.Contains(OnKeys.Held))
            {
                OnKeyHelds.Remove(keys);
            }

            if (onKeys.Contains(OnKeys.Up))
            {
                OnKeyUps.Remove(keys);
            }
        }

        public void remove(Key key, params OnKeys[] onKeys) { remove(Keys.get(key), onKeys); }

        public void remove(OnKeyEvent OnKeyEvent, params OnKeys[] OnKeyss)
        {
            if (OnKeyss.Contains(OnKeys.Down))
            {
                Keys keys = null;
                foreach (KeyValuePair<Keys, OnKeyEvent> pair in OnKeyDowns)
                {
                    if (pair.Value.Equals(OnKeyEvent)) { keys = pair.Key; break; }
                }
                if (keys != null) { OnKeyDowns.Remove(keys); }
            }

            if (OnKeyss.Contains(OnKeys.Held))
            {
                Keys keys = null;
                foreach (KeyValuePair<Keys, OnKeyEvent> pair in OnKeyHelds)
                {
                    if (pair.Value.Equals(OnKeyEvent)) { keys = pair.Key; break; }
                }
                if (keys != null) { OnKeyHelds.Remove(keys); }
            }

            if (OnKeyss.Contains(OnKeys.Up))
            {
                Keys keys = null;
                foreach (KeyValuePair<Keys, OnKeyEvent> pair in OnKeyUps)
                {
                    if (pair.Value.Equals(OnKeyEvent)) { keys = pair.Key; break; }
                }
                if (keys != null) { OnKeyUps.Remove(keys); }
            }
        }

        public void clear()
        {
            OnKeyDowns.Clear();
            OnKeyHelds.Clear();
            OnKeyUps.Clear();
        }


        // Event Listeners
        private unsafe void checkKeyDowns(ref Keys lastKeys, ref byte* input)
        {
            foreach (Keys keys in OnKeyDowns.Keys)
            {
                if (Controller.isPressed(ref input, keys) && !Controller.isPressed(lastKeys, keys))
                {
                    OnKeyEvent onKeyEvent;
                    OnKeyDowns.TryGetValue(keys, out onKeyEvent);

                    bool updateLastKeys = true;
                    if (onKeyEvent != null) { updateLastKeys = onKeyEvent.Run(lastKeys, ref input, keys, OnKeys.Down); }
                    lastKeys = (updateLastKeys) ? Controller.getPressedKeys(ref input) : lastKeys;
                }
            }
        }

        private unsafe void checkKeyHolds(ref Keys lastKeys, ref byte* input)
        {
            foreach (Keys keys in OnKeyHelds.Keys)
            {
                if (Controller.isPressed(ref input, keys) && Controller.isPressed(lastKeys, keys))
                {
                    OnKeyEvent onKeyEvent;
                    OnKeyHelds.TryGetValue(keys, out onKeyEvent);

                    bool updateLastKeys = true;
                    if (onKeyEvent != null) { updateLastKeys = onKeyEvent.Run(lastKeys, ref input, keys, OnKeys.Held); }
                    lastKeys = (updateLastKeys) ? Controller.getPressedKeys(ref input) : lastKeys;
                }
            }
        }

        private unsafe void checkKeyUps(ref Keys lastKeys, ref byte* input)
        {
            foreach (Keys keys in OnKeyUps.Keys)
            {

                if (!Controller.isPressed(ref input, keys) && Controller.isPressed(lastKeys, keys))
                {
                    OnKeyEvent onKeyEvent;
                    OnKeyUps.TryGetValue(keys, out onKeyEvent);

                    bool updateLastKeys = true;
                    if (onKeyEvent != null) { updateLastKeys = onKeyEvent.Run(lastKeys, ref input, keys, OnKeys.Up); }
                    lastKeys = (updateLastKeys) ? Controller.getPressedKeys(ref input) : lastKeys;
                }
            }
        }


        // Decide what to do with raw controller input
        public unsafe void check(ref byte* input)
        {
            server.rawKeys = Controller.getPressedKeys(ref input);

            // If there's an active macro, let it work
            // server.ReportMessage("Has Active Macro: {0}", server.activeMacro != null);
            if (server.activeMacro == null)
            {
                foreach (MacroMod macro in server.macros)
                {
                    if (macro.shouldBeActivated(server.rawLastKeys, server.rawKeys))
                    {
                        server.setActiveMacro(macro);
                        server.ReportMessage("Setting Active Macro");
                        break;
                    }
                }
            }
            if (server.activeMacro != null)
            {
                if (server.macroCounter == 0 || server.activeMacro.shouldBeActivated(server.rawLastKeys, server.rawKeys))
                {
                    Controller.releaseAll(ref input);
                    Controller.pressKeys(ref input, server.macroStep);
                    server.ReportMessage("Activating Macro Step");
                }
                else
                {
                    server.setActiveMacro(null);
                    server.ReportMessage("Nullifying Macro");
                }
                
            }
            

            checkKeyDowns(ref lastKeys, ref input);
            checkKeyHolds(ref lastKeys, ref input);
            checkKeyUps(ref lastKeys, ref input);

            foreach (KeyValuePair<Keys, DS4Input.ShootingMod> pair in shootingMods)
            {
                if (Controller.isPressed(ref input, pair.Key))
                {

                    pair.Value.Run(lastKeys, ref input, pair.Key, OnKeys.Held);
                    
                }
            }
            lastKeys = Controller.getPressedKeys(ref input);

            server.rawLastKeys = server.rawKeys;
            server.lastKeys = lastKeys;
        }

        // Rapid Fire
        public void addRapidFire(Dictionary<string, Keys[]> mods, Dictionary<string, bool> enabled)
        {
            foreach(KeyValuePair<string, bool> pair in enabled)
            {

                if (pair.Value)
                {
                    Keys[] keyset = null;
                    mods.TryGetValue(pair.Key, out keyset);
                    
                    if (!shootingMods.ContainsKey(keyset[0]))
                    {
                        DS4Input.ShootingMod shootingMod = new DS4Input.ShootingMod(server, keyset[1]);
                        shootingMods.Add(keyset[0], shootingMod);
                    }
                }
            }

        }

        public void clearRapidFire()
        {
            shootingMods.Clear();
            Console.WriteLine("Shooting Mods After Clear:{0}", shootingMods.Count);
        }

        // Hair Triggers
        public void addHairTrigger(int L2min, int L2max, int R2min, int R2max)
        {
            if (hairTriggerL2 == null)
            {
                hairTriggerL2 = new DS4Input.HairTriggerMod(L2min, L2max);
                hairTriggerR2 = new DS4Input.HairTriggerMod(R2min, R2max);

                add(hairTriggerL2, Key.L2(), OnKeys.Down, OnKeys.Held);
                add(hairTriggerR2, Key.R2(), OnKeys.Down, OnKeys.Held);
                return;
            }
            hairTriggerL2.setFields(L2min, L2max);
            hairTriggerR2.setFields(R2min, R2max);
        }

        // Macros
        public void addMacro(List<Keys> steps, Keys activators, bool toggle)
        {
            
        }

        public void setMacros(List<MacroMod> mods)
        {
            
            foreach(MacroMod mod in mods) { mod.server = this.server; }
            macros = mods;
            macroCounters.Clear();
            macroCounters.AddRange(new int[mods.Count]);
        }

    }



    public interface OnKeyEvent
    {
        unsafe bool Run(Keys lastKeys, ref byte* input, Keys activatorKeys, KeyMonitor.OnKeys OnKey);
    }

}