using System;
using System.Linq;
using Android.Runtime;
using Java.Interop;
using Core = MonkeysSDK;

namespace MonkeysSDK.Droid
{
    [Register("monkeyssdk.droid.MonkeyIterator")]
    public class MonkeyIterator : Java.Lang.Object
    {
        private readonly Monkey[] monkeys;
        private int current = 0;

        public MonkeyIterator()
        { }

        internal MonkeyIterator(Core.Monkey[] monkeys)
        {
            this.monkeys = monkeys.Select(m => new Monkey(m)).ToArray(); 
        }

        public Monkey Current
        {
            get
            {
                if (monkeys == null) return null;

                return monkeys[current];
            }
        }

        [Export("getCurrent")]
        public Monkey GetCurrent()
        {
            return Current;
        }

        [Export("getNext")]
        public Monkey Next()
        {
            if (monkeys != null && (current + 1) < monkeys.Count())
            {
                current++;
                return Current;
            }
            else
            {
                return null;
            }
        }

        [Export("getFirst")]
        public Monkey First()
        {
            current = 0;
            return Current;
        }
    }
}
