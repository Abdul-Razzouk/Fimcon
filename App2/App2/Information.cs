using Android.App;
using Android.OS;
using Android.Widget;

namespace App2
{
    [Activity(Label = "Information")]
    public class Information : Activity
    {
        private TextView _text;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _text = FindViewById<TextView>(Resource.Id.textViewInfo);

            // Create your application here
        }
    }
}