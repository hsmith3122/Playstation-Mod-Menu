using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitorHook
{
    [Serializable]
    public class DS4Input
    {

        public static ServerInterface server { get; set; }

        public bool rapidFireMode = true;
        public bool hairTriggerMode = true;

        public DS4Input(ServerInterface server) {
            DS4Input.server = server;
        }


        public List<OnKeyEvent> shootingMods = new List<OnKeyEvent>();


        private Keys lastKeys = Keys.get();

        public Key keyRapidFire = Key.DPad(Direction.E);


        [Serializable]
        public class ToggleRapidFire : OnKeyEvent 
        {
            ServerInterface server;

            public ToggleRapidFire(ServerInterface server)
            {
                this.server = server;
            }

            public unsafe bool Run(Keys lastKeys, ref byte* input, Keys activatorKeys, KeyMonitor.OnKeys onKey)
            {
                server.DS4Input.rapidFireMode = !server.DS4Input.rapidFireMode;
                return true;
            }
        }

        [Serializable]
        public class ShootingMod : OnKeyEvent 
        {

            Keys rKeys;

            public ServerInterface server;

            public ShootingMod(ServerInterface server, Keys rapidFires)
            {
                rKeys = rapidFires;
                this.server = server;
            }

            public unsafe bool Run(Keys lastKeys, ref byte* input, Keys activatorKeys, KeyMonitor.OnKeys onKey)
            {
                if (server.count % 8 < 4)  { Controller.pressKeys(ref input, rKeys); }
                else                        { Controller.releaseKeys(ref input, rKeys); }
                return true;
            }
        }

        [Serializable]
        public class HairTriggerMod : OnKeyEvent
        {
            public int min, max;

            public HairTriggerMod(int min, int max) {
                setFields(min, max);
            }

            public void setFields(int min, int max) {
                this.min = min;
                this.max = max;
            }

            public unsafe bool Run(Keys lastKeys, ref byte* input, Keys activatorKeys, KeyMonitor.OnKeys onKey)
            {
                Key trigger = (activatorKeys.First().name.Equals("L2")) ? Key.L2() : Key.R2();
                int inputValue = input[trigger.byteIndex];

                Controller.releaseKeys(ref input, trigger);

                if (inputValue < min) { return true ; }

                if (inputValue >= max || (max - min) < 1) {
                    trigger.value = 255;
                    Controller.pressKeys(ref input, trigger);
                }

                else {
                    int val = Convert.ToInt32((inputValue - min) / Convert.ToDouble(max - min) * 256) ;
                    if (val > 255) { val = 255; }
                    if (val < 0) { val = 0; }
                    trigger.value = Convert.ToByte(val);
                    Controller.pressKeys(ref input, trigger);
                }


                return true;
            }
        }

        [Serializable]
        public class MacroMod : OnKeyEvent
        {
            public ServerInterface server;
            public int counter = 0;
            public List<Keys> steps;
            public Keys activators;
            public bool toggle;

            public bool isRunning;
           
            public MacroMod(List<Keys> steps, Keys activators, bool toggle)
            {
                this.steps = steps;
                this.toggle = toggle;
                this.isRunning = false;
                this.activators = activators;
            }
            public MacroMod(Keys activators, bool toggle) { resetSteps(); this.activators = activators; this.toggle = toggle; isRunning = false; }

            public unsafe bool Run(Keys lastKeys, ref byte* input, Keys activatorKeys, KeyMonitor.OnKeys OnKey)
            {
                int counter = 0;
                if (server != null)
                {
                    int index = server.KeyMonitor.macros.IndexOf(this);
                    counter = (index != -1) ? server.KeyMonitor.macroCounters.ElementAt(index) : 0;
                    runMacro(ref input, ref counter);
                }
                
                return true;
            }

            public void setActivators(Keys keys)        { this.activators = keys; }
            public void setToggle(bool toggle)          { this.toggle = toggle; this.isRunning = false; }
            public void resetCounter(ref int counter)   { counter = 0; this.isRunning = false;}
            public unsafe int runMacro(ref byte* input, ref int counter)
            {
                if (counter > steps.Count) { resetCounter(ref counter); }
                Controller.releaseAll(ref input);
                Controller.pressKeys(ref input, steps.ElementAt(counter++));
                return counter;
            }

            public unsafe int runMacro(ref byte* input)
            {
                if (counter > steps.Count) { resetCounter(ref counter); }
                Controller.releaseAll(ref input);
                Controller.pressKeys(ref input, steps.ElementAt(counter++));
                return counter;
            }

            public bool shouldBeActivated(Keys lastKeys, Keys rawKeys)
            {
                if (toggle)
                {
                    if (Controller.isPressed(rawKeys, activators) && !Controller.isPressed(lastKeys, activators))
                    {
                        isRunning = !isRunning;
                    }
                }
                else
                {
                    isRunning = Controller.isPressed(rawKeys, activators);
                }
                return isRunning;
            }

            public void resetSteps() { this.steps = new List<Keys>(); }
            public void addStep(Keys keys) { this.steps.Add(keys); }
            public void removeStep(int index) { this.steps.RemoveAt(index); }
            public void trim()
            {
                while (steps.Count > 0)
                {
                    if (steps.First().Count == 0) { steps.RemoveAt(0); }
                    else { break; }
                }

                while (steps.Count > 0)
                {
                    if (steps.Last().Count == 0) { steps.RemoveAt(steps.Count - 1); }
                    else { break; }
                }
            }
            public int numSteps() { return steps.Count; }
            public void addServer(ServerInterface server) { this.server = server; }

            public void setCounter(int counter) { this.counter = counter; }
             
        }
    }

}
