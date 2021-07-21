using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitorHook
{
    [Serializable]
    public class Key : IComparable<Key>
    {
        Key() { }
        public readonly static Key Triangle = new Key(5, 7, "Triangle", "Shape");
        public readonly static Key Square = new Key(5, 4, "Square", "Shape");
        public readonly static Key Circle = new Key(5, 6, "Circle", "Shape");
        public readonly static Key X = new Key(5, 5, "X", "Shape");

        public readonly static Key L1 = new Key(6, 0, "L1", "Bumper");
        public readonly static Key R1 = new Key(6, 1, "R1", "Bumper");

        public readonly static Key L3 = new Key(6, 6, "L3", "Stick");
        public readonly static Key R3 = new Key(6, 7, "R3", "Stick");

        public readonly static Key Options = new Key(6, 5, "Options", "Pill");
        public readonly static Key Share = new Key(6, 4, "Share", "Pill");
        public readonly static Key Home = new Key(7, 0, "Home", "Home");
        public readonly static Key TPad = new Key(7, 1, "Touchpad", "TPad");

        public static Key L2(int sens) { return new Key(8, 7, Convert.ToByte(sens), "L2", "Trigger"); }
        public static Key R2(int sens) { return new Key(9, 7, Convert.ToByte(sens), "R2", "Trigger"); }
        public static Key L2() { return new Key(8, 7, Convert.ToByte(0xFF), "L2", "Trigger"); }
        public static Key R2() { return new Key(9, 7, Convert.ToByte(0xFF), "R2", "Trigger"); }

        public static Key DPad(Direction d) { return new Key(5, 4, Convert.ToByte(d), d.ToString(), "DPad"); }

        public readonly static Keys Buttons = new Keys(
            Triangle, Square, Circle, X,
            L1, L2(), L3,
            R1, R2(), R3,
            Options, Share,
            Home, TPad,
            DPad(Direction.NW), DPad(Direction.N), DPad(Direction.NE),
            DPad(Direction.SW), DPad(Direction.S), DPad(Direction.SE),
            DPad(Direction.W), DPad(Direction.E)
        );


        public int byteIndex { get; set; }
        public int bitIndex { get; set; }
        public byte value { get; set; }
        public string name { get; set; }
        public string type { get; }

        private Key(int by, int bit, string str, string type)
        {
            byteIndex = by;
            bitIndex = bit;
            name = str;
            this.type = type;

            string binary = "1";
            for (int place = bitIndex; place > 0; place--)
            {
                binary += "0";
            }

            value = Convert.ToByte(binary, 2);
        }

        private Key(int by, int bit, byte value, string str, string type)
        {
            byteIndex = by;
            bitIndex = bit;
            name = str;
            this.value = value;
            this.type = type;
        }

        public bool Equals(Key other)
        {
            return this.name.Equals(other.name) && this.type.Equals(other.type);
        }


        public int CompareTo(Key other)
        {
            int t1 = this.byteIndex.CompareTo(other.byteIndex);
            int t2 = this.bitIndex.CompareTo(other.bitIndex);
            return (t1 == 0) ? t2 : t1;
        }

        public override string ToString()
        {
            return this.name;
        }



        [Serializable]
        public class KeyCompare : IComparer<Key>
        {
            public int Compare(Key a, Key b)
            {
                return a.CompareTo(b);
            }
        }

        [Serializable]
        public class KeysCompare : IComparer<Keys>
        {
            public int Compare(Keys a, Keys b)
            {
                for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
                {
                    int compare = a.ElementAt(i).CompareTo(b.ElementAt(i));
                    if (compare == 0) { continue; }
                    return compare;
                }
                return a.Length - b.Length;

            }
        }


    }


    public enum Direction
    {
        N, NE, E, SE, S, SW, W, NW, None
    }

    [Serializable]
    public class Keys : List<Key>
    {

        public static Keys From(string str)
        {
            Keys keys = Keys.get();

            foreach(string s in str.Split(' '))
            {
                foreach(Key key in Key.Buttons)
                {
                    if (key.name.ToUpper().Equals(s.ToUpper())){
                        keys.Add(key);
                        break;
                    }
                }
            }
            return keys;
        }

        public int Length { get => this.Count; }


        public Keys() : base()                      { }
        public Keys(params Key[] keys) : base(keys) { }
        public Keys(int capacity) : base(capacity)  { }


        public bool Equals(Keys other)
        {
            if (other.Count != this.Count) { return false; }

            foreach(Key key in this)
            {
                if (!other.Contains(key)) { return false; }
            }

            return true;
        }

        public bool Equals(Key key)
        {
            return this.Count == 1 && this.First().Equals(key);
        }

        public override string ToString()
        {
            string str = "";
            foreach(Key key in this) { if (key != null) { str += key.ToString() + " "; } }
            return (str.Length == 0) ? "No Keys Pressed" : str.Trim();
        }

        public new bool Contains(Key key)
        {
            foreach (Key a in this) { if (a.Equals(key)) { return true; } }
            return false;

        }

        public bool Contains(Keys keys)
        {
            foreach (Key key in keys) { if (!Contains(key)) { return false; } }
            return true;
        }

        public static Keys get(params Key[] keys)
        {
            return new Keys(keys);
        }
    }

}