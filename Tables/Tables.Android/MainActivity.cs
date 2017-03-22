using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Tables.Droid
{
	[Activity (Label = "Clients!", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        private AzureClient _client;
        public List<string> Items;
        private ListView listView;
        public EditText mName;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

            listView = FindViewById<ListView>(Resource.Id.listView);
            Items = new List<string>();

            _client = new AzureClient();
            load();

            mName = FindViewById<EditText>(Resource.Id.create_client_name);
            Button mButton = FindViewById < Button >(Resource.Id.create_client_btn);
            mButton.Click += delegate
            {
                save();
            };

		}

        public async void load()
        {
            Items.Clear();
            var result = await _client.GetClients();
            foreach (Client c in result)
            {
                Items.Add(c.Name);
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Items);
            listView.Adapter = adapter;
            mName.Text = "";
        }

        public async void save()
        {
            Client c = new Client();
            c.Name = mName.Text;
            _client.SaveClient(c);
            load();
        }

	}
}


