using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinTest.Data
{
    public class Sound
    {
        public string Name { get; }
        public bool Checked { get; set; }

        public Sound(string name)
        {
            Name = name;
        }
    }
}