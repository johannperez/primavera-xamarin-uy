using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Runtime;
using Java.Interop;
using Newtonsoft.Json;
using Core = MonkeysSDK;

namespace MonkeysSDK.Droid
{
    [Register("monkeyssdk.droid.MonkeysSDK")]
    public class MonkeysSDK : Java.Lang.Object
    {
        public MonkeysSDK(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public MonkeysSDK() : base()
        { }

        [Export("getRandomMonkey")]
        public string GetRandomMonkey()
        {
            return new Core.MonkeysSDK().GetRandomMonkey();
        }

        [Export("getMonkeyDevs")]
        public Monkey[] GetMonkeyDevs()
        {
            return new Core.MonkeysSDK().GetMonkeyDevs().Select(m => new Monkey(m)).ToArray();
        }

        [Export("getMonkeyIterator")]
        public MonkeyIterator GetMonkeyIterator()
        {
            return new MonkeyIterator(new Core.MonkeysSDK().GetMonkeyDevs());

        }

        [Export("fireMonkeyBomb")]
        public void MonkeyBomb()
        {
            new Core.MonkeysSDK().MonkeyBomb();
        }
    }
}
