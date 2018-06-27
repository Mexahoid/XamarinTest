using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinTest.Activities
{
    [Activity(Label = "SoundActivity", MainLauncher = true)]
    public class SoundActivity : FragmentActivity
    {
        private int folderIndex;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_sounds);
            folderIndex = Intent.GetIntExtra("folder", -1);
            Android.Support.V4.App.FragmentManager fm = SupportFragmentManager;
            Android.Support.V4.App.Fragment fragment = fm.FindFragmentById(Resource.Id.sound_act_fragments);

            if (fragment == null)
            {
                fragment = new SoundActivityFragmentHolder(folderIndex);
                fm.BeginTransaction()
                    .Add(Resource.Id.sound_act_fragments, fragment)
                    .Commit();
            }

        }
    }
}