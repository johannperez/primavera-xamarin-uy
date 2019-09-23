using System;
using System.Linq;

namespace MonkeysSDK
{
    public class MonkeyIterator
    {
        private readonly Monkey[] monkeys;
        private int current = 0;

        public MonkeyIterator()
        { }

        internal MonkeyIterator(Monkey[] monkeys)
        {
            this.monkeys = monkeys;
        }

        public Monkey Current
        {
            get
            {
                if (monkeys == null) return null;

                return monkeys[current];
            }
        }

        public Monkey Next()
        {
            if (monkeys != null && (current + 1) < monkeys.Count())
            {
                current++;
            }
            return Current;
        }

        public Monkey First()
        {
            current = 0;
            return Current;
        }
    }
}
