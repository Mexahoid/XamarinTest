using System;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace XamarinTest.MainActivity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        private ClientSocket clsock;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            //clsock.Connect();
            SetContentView(Resource.Layout.activity_main);

            //Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);



            Android.Support.V4.App.FragmentManager fm = SupportFragmentManager;
            Android.Support.V4.App.Fragment fragment = fm.FindFragmentById(Resource.Id.main_act_fragment);

            if (fragment == null)
            {
                fragment = new MainActivityFragmentHolder();
                fm.BeginTransaction()
                    .Add(Resource.Id.main_act_fragment, fragment)
                    .Commit();
            }



            if (savedInstanceState == null ||
                !savedInstanceState.ContainsKey("message") || !savedInstanceState.ContainsKey("reply"))
                return;
            //textbox_send.Text = savedInstanceState.GetString("message");
            //textbox_server.Text = savedInstanceState.GetString("server");
            //textbox_receive.Text = savedInstanceState.GetString("reply");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            //outState.PutString("message", textbox_send.Text);
            //outState.PutString("server", textbox_server.Text);
            //outState.PutString("reply", textbox_receive.Text);

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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.menu_main, menu);
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
        

    }
}

