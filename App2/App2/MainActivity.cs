using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace App2
{
    [Activity(Label = "ConFim", MainLauncher = true, Icon = "@drawable/fim_logo")]
    public class MainActivity : Activity
    {
        private TabWidget _tabs;
        private Button _agenda;
        private Button _persAgenda;
        private Button _anfahrt;
        private Button _info;
 
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            //tabs = FindViewById<TabWidget>(Resource.Id.tabHost1);
            _agenda = FindViewById<Button>(Resource.Id.button3);
            _persAgenda = FindViewById<Button>(Resource.Id.button4);
            _anfahrt = FindViewById<Button>(Resource.Id.button5);
            _info = FindViewById<Button>(Resource.Id.button6);
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            _agenda.Click += (sender, args) =>
            {
                var agendaIntent = new Intent(this, typeof(Agenda));
                StartActivity(agendaIntent);
            };

            _info.Click += (sender, args) =>
            {
                var infoIntent = new Intent(this, typeof(Information));
                StartActivity(infoIntent);
            };

            _anfahrt.Click += (sender, args) =>
            {
                var anfahrtIntent = new Intent(this, typeof(Anfahrt));
                StartActivity(anfahrtIntent);
            };
        }
    }
}

