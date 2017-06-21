using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Views;

namespace App2
{
    internal class TwoLineAdapter : BaseAdapter<Tuple<string, string>>
    {
        private Agenda agenda;
        private List<Tuple<string, string>> eventList;

        public TwoLineAdapter(Agenda agenda, List<Tuple<string, string>> eventList)
        {
            this.agenda = agenda;
            this.eventList = eventList;
        }

        public override Tuple<string, string> this[int position]
        {
            get
            {
                return eventList[position];
            }
        }

        public override int Count
        {
            get
            {
                return eventList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = agenda.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null); 
            }

            TextView text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            TextView text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            text1.Text = eventList[position].Item1;
            text2.Text = eventList[position].Item2;

            return view;

        }
    }
}