using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using XamarinTest.Data;

namespace XamarinTest.Sounds
{
    class SoundListFragmentHolder : RecyclerView.ViewHolder
    {
        private readonly TextView soundNameTextView;
        private readonly CheckBox checkBox;

        public SoundListFragmentHolder(View itemView) : base(itemView)
        {
            soundNameTextView = itemView.FindViewById<TextView>(Resource.Id.sounds_frag_list_title);
            checkBox = itemView.FindViewById<CheckBox>(Resource.Id.sounds_frag_list_checkbox);
        }
        public void BindTo(Sound sound)
        {
            soundNameTextView.Text = sound.Name;
            checkBox.Checked = sound.Checked;
            checkBox.Click += (sender, e) => { sound.Checked = ((CheckBox) sender).Checked; };
        }
    }
}