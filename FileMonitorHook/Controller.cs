using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitorHook
{
    public static class Controller
    {
        public unsafe static bool isPressed(ref byte* inputs, Key key)  // Works for R2
        {
            switch (key.type)
            {
                case "DPad": return (inputs[5] & 0b1111) == key.value;
                case "Trigger": return (inputs[6] & (1 << ((key.name.Equals("L2")) ? 2 : 3))) != 0;
            }
            return (inputs[key.byteIndex] & (1 << key.bitIndex)) != 0;
        }

        public unsafe static bool isPressed(ref byte* inputs, Keys keys) // Works for R2
        {
            foreach (Key key in keys)
            {
                if (!isPressed(ref inputs, key)) { return false; }
            }
            return true;
        }

        public static bool isPressed(Key keyA, Key keyB)                // Broken
        {
            return keyA.name.Equals(keyB.name);
        }

        public static bool isPressed(Keys keysA, Keys keysB)            // Broken
        {
            foreach (Key b in keysB) {
                bool found = false;
                foreach(Key a in keysA)
                {
                    if (isPressed(a, b)) { found = true; break; }
                }
                if (!found) { return false; }
            }
            return true;
        }


        public unsafe static void releaseKeys(ref byte* inputs, Keys keys)
        {
            foreach (Key key in keys)
            {
                releaseKeys(ref inputs, key);
            }
        }

        public static unsafe void releaseKeys(ref byte* inputs, Key key)
        {
            if (isPressed(ref inputs, key))
            {
                if (key.type.Equals("Trigger")) {
                    inputs[key.byteIndex] = 0;
                    inputs[6] -= Convert.ToByte(((key.name.Equals("L2")) ? 4 : 8));
                }
                else { inputs[key.byteIndex] -= key.value; }
            }
        }

        public unsafe static void releaseAll(ref byte* inputs)
        {
            inputs[5] = 8;
            inputs[6] = 0;
            inputs[8] = 0;
            inputs[9] = 0;
        }

        public unsafe static Keys getPressedKeys(ref byte* inputs)
        {
            List<Key> keys = new List<Key>();
            foreach (Key key in Key.Buttons)
            {
                if (isPressed(ref inputs, key))
                {
                    if (key.name == "L2"){ keys.Add(Key.L2(inputs[key.byteIndex])); }
                    else if (key.name == "R2") { keys.Add(Key.R2(inputs[key.byteIndex])); }
                    else { keys.Add(key); }
                }
            }
            return new Keys(keys.ToArray());
        }


        public unsafe static void pressKeys(ref byte* inputs, Keys keys)
        {
            foreach (Key key in keys)
            {
                pressKey(ref inputs, key);
            }
        }

        public unsafe static void pressKeys(ref byte* inputs, Key key)
        {
            pressKey(ref inputs, key);
        }

        static unsafe void pressKey(ref byte* inputs, Key key)
        {
            if (!isPressed(ref inputs, key))
            {
                inputs[key.byteIndex] += key.value;

                if (key.type.Equals("Trigger"))
                {
                    inputs[6] += Convert.ToByte(((key.name.Equals("L2")) ? 4 : 8)) ;
                }
            }
        }
    }
}
