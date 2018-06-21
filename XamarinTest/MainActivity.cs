using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace XamarinTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btn_connect, btn_send;
        private EditText textbox_server, textbox_send, textbox_receive;
        private ClientSocket clsock;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //clsock.Connect();
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            btn_connect = FindViewById<Button>(Resource.Id.btn_connect);
            btn_send = FindViewById<Button>(Resource.Id.btn_send);

            textbox_server = FindViewById<EditText>(Resource.Id.edittext_server_ip);
            textbox_send = FindViewById<EditText>(Resource.Id.edittext_message);
            textbox_receive = FindViewById<EditText>(Resource.Id.edittext_response);
            btn_connect.Click += Connect;
            btn_send.Click += Send;


            if (savedInstanceState == null ||
                !savedInstanceState.ContainsKey("message") || !savedInstanceState.ContainsKey("reply"))
                return;
            textbox_send.Text = savedInstanceState.GetString("message");
            //textbox_server.Text = savedInstanceState.GetString("server");
            textbox_receive.Text = savedInstanceState.GetString("reply");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString("message", textbox_send.Text);
            //outState.PutString("server", textbox_server.Text);
            outState.PutString("reply", textbox_receive.Text);

            base.OnSaveInstanceState(outState);
        }

        protected override void OnPause()
        {
            base.OnPause();
            Disconnect();
        }

        private async void Disconnect()
        {
            await clsock.ClientWork("Disconnect");
            clsock.Disconnect();
        }

        protected override void OnResume()
        {
            base.OnResume();
            clsock = ClientSocket.GetInstance("192.168.1.35", 1488);
        }
        

        protected override void OnDestroy()
        {
            textbox_server.Text = "IP сервера:";
            base.OnDestroy();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void Connect(object sender, EventArgs eventArgs)
        {
            await clsock.Connect();
            textbox_server.Text = "IP сервера: 192.168.1.35";
            btn_send.Enabled = true;
        }

        private async void Send(object sender, EventArgs e)
        {
            textbox_receive.Text = await clsock.ClientWork(textbox_send.Text);
            textbox_send.Text = "";
        }

    }
}

