using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinTest.Data;
using XamarinTest.Sounds;

namespace XamarinTest.Activities
{
    public class SoundActivityFragmentHolder : Android.Support.V4.App.Fragment
    {
        private Folder folder;

        public SoundActivityFragmentHolder(int index)
        {
            if(index != -1)
                folder = FolderStorage.GetInstance()[index];
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.activity_sounds_fragment, container, false);

            RecyclerView rw = v.FindViewById<RecyclerView>(Resource.Id.sound_recycler);
            rw.SetLayoutManager(new LinearLayoutManager(Activity));

            rw.SetAdapter(new SoundListFragmentAdapter(Context, folder));
            return v;
        }
    }
}