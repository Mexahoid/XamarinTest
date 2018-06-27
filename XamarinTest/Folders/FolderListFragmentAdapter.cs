using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using XamarinTest.Data;

namespace XamarinTest.Folders
{
    public class FolderListFragmentAdapter : RecyclerView.Adapter
    {
        private LayoutInflater li;
        private readonly FolderStorage folders = FolderStorage.GetInstance();
        private Context cont;
        

        public FolderListFragmentAdapter(Context context)
        {
            li = LayoutInflater.From(context);
            cont = context;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((FolderListFragmentHolder)holder).BindTo(folders[position], position);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new FolderListFragmentHolder(li.Inflate(Resource.Layout.folder_fragment_list_item, parent, false),
                (index, state) =>
                {
                    folders[index].Checked = state;
                    NotifyItemChanged(index);
                });
        }

        public override int ItemCount => folders.GetFolderCount();
    }
}