using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using XamarinTest.Data;

namespace XamarinTest.Folders
{
    public class FolderListFragmentHolder : RecyclerView.ViewHolder
    {
        private readonly TextView folderNameTextView;
        private readonly CheckBox checkBox;
        private int index;
        private event Action<int> Clicker;


        public FolderListFragmentHolder(View itemView, Action<int> clicker) : base(itemView)
        {
            Clicker += clicker;
            folderNameTextView = itemView.FindViewById<TextView>(Resource.Id.folder_frag_list_title);
            checkBox = itemView.FindViewById<CheckBox>(Resource.Id.folder_frag_list_checkbox);
        }

        public void BindTo(Folder folder, int iindex)
        {
            index = iindex;
            folderNameTextView.Text = folder.FolderName;
            checkBox.Checked = folder.Checked;
            ItemView.Click += (sender, e) => Clicker?.Invoke(index);
        }

    }
}