using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App2
{
    [Activity(Label = "ConFim", MainLauncher = true, Icon = "@drawable/fim_logo")]
    public class MainActivity : Activity
    {
        TabWidget tabs;
        Button agenda;
        Button pers_agenda;
        Button anfahrt;
        Button info;
 
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            //tabs = FindViewById<TabWidget>(Resource.Id.tabHost1);
            agenda = FindViewById<Button>(Resource.Id.button3);
            pers_agenda = FindViewById<Button>(Resource.Id.button4);
            anfahrt = FindViewById<Button>(Resource.Id.button5);
            info = FindViewById<Button>(Resource.Id.button6);
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            agenda.Click += (sender, args) =>
            {
                var agendaIntent = new Intent(this, typeof(Agenda));
                StartActivity(agendaIntent);
            };

            info.Click += (sender, args) =>
            {
                var infoIntent = new Intent(this, typeof(Information));
                StartActivity(infoIntent);
            };

            anfahrt.Click += (sender, args) =>
            {
                var anfahrtIntent = new Intent(this, typeof(Anfahrt));
                StartActivity(anfahrtIntent);
            };


        }
    }
}

