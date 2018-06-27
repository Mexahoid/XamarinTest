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
        private bool _checked;
        public string Name { get; }

        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                CheckChanged?.Invoke(_checked);
            }
        }

        private event Action<bool> CheckChanged;

        public Sound(string name, Action<bool> checkHandler)
        {
            Name = name;
            CheckChanged += checkHandler;
        }
    }
}