using Android.App;
using Android.OS;
using Android.Views;

namespace XamarinTest.Folders
{
    public class FolderListFragmentItem : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return inflater.Inflate(Resource.Layout.folder_fragment_list_item, container, false);
        }
    }
}