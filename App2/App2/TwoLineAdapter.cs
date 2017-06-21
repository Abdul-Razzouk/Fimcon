using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Views;

namespace App2
{
    internal class TwoLineAdapter : BaseAdapter<Tuple<string, string>>
    {
        private readonly Agenda _agenda;
        private readonly List<Tuple<string, string>> _eventList;

        public TwoLineAdapter(Agenda agenda, List<Tuple<string, string>> eventList)
        {
            _agenda = agenda;
            _eventList = eventList;
        }

        public override Tuple<string, string> this[int position]
        {
            get
            {
                return _eventList[position];
            }
        }

        public override int Count
        {
            get
            {
                return _eventList.Count;
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
                view = _agenda.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null); 
            }

            var text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            text1.Text = _eventList[position].Item1;
            text2.Text = _eventList[position].Item2;

            return view;
        }
    }
}