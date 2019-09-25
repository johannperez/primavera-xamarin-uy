using System;
using Android.Runtime;
using Java.Interop;
using Core = MonkeysSDK;

namespace MonkeysSDK.Droid
{
    [Register("monkeyssdk.droid.Monkey")]
    public class Monkey : Java.Lang.Object
    {
        public string Name { get; set; }

        public Monkey(Core.Monkey m) 
        {
            this.Name = m.Name;
        }

        [Export("getName")]
        public string GetName()
        {
            return this.Name;
        }

    }
}
