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
using XamarinTest.Folders;

namespace XamarinTest.Activities
{
    public class MainActivityFragmentHolder : Android.Support.V4.App.Fragment
    {
        private Button btn_connect;//, btn_send;
        private EditText textbox_server;//, textbox_send, textbox_receive;
        private ClientSocket clsock;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.activity_fragment, container, false);
            clsock = ClientSocket.GetInstance("192.168.1.35", 1488);
            RecyclerView rw = v.FindViewById<RecyclerView>(Resource.Id.main_recycler);
            rw.SetLayoutManager(new LinearLayoutManager(Activity));
            btn_connect = v.FindViewById<Button>(Resource.Id.btn_connect);
            textbox_server = v.FindViewById<EditText>(Resource.Id.edittext_server_ip);
            btn_connect.Click += Connect;
            rw.SetAdapter(new FolderListFragmentAdapter(Context));
            return v;
        }

        private async void Connect(object sender, EventArgs eventArgs)
        {
            await clsock.Connect();
            textbox_server.Text = "IP сервера: 192.168.1.35";
            btn_connect.Enabled = false;
        }
    }
}