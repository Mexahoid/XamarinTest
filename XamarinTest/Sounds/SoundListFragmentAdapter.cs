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
    class SoundListFragmentAdapter : RecyclerView.Adapter
    {
        private LayoutInflater li;
        private Context context;
        private Folder folder;

        public SoundListFragmentAdapter(Context context, Folder folder)
        {
            this.folder = folder;
            this.context = context;
            li = LayoutInflater.From(context);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((SoundListFragmentHolder)holder).BindTo(folder[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new SoundListFragmentHolder(li.Inflate(Resource.Layout.sounds_fragment_list_item, parent, false));
        }

        public override int ItemCount => folder.GetSoundsCount();
    }
}