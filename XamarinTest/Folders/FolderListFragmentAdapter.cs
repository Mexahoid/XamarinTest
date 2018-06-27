using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using XamarinTest.Activities;
using XamarinTest.Data;

namespace XamarinTest.Folders
{
    public class FolderListFragmentAdapter : RecyclerView.Adapter
    {
        private LayoutInflater li;
        private readonly FolderStorage folders;
        private Context cont;


        public FolderListFragmentAdapter(Context context)
        {
            li = LayoutInflater.From(context);
            cont = context;
            folders = FolderStorage.GetInstance();
            folders.SetNotifier(NotifyItemChanged);
        }
        
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((FolderListFragmentHolder)holder).BindTo(folders[position], position);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new FolderListFragmentHolder(li.Inflate(Resource.Layout.folder_fragment_list_item, parent, false),
                index =>
                {
                    var inet = new Intent(cont, typeof(SoundActivity));
                    inet.PutExtra("folder", index);
                    cont.StartActivity(inet);
                });

        }

        public override int ItemCount => folders.GetFolderCount();
    }
}