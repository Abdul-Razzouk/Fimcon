
using System;
using System.Collections.Generic;
using System.Net;
using Android.OS;
using Android.Widget;
using System.Xml;

namespace App2
{
    public class DownloadTest : AsyncTask<string, int, List<Tuple<string, string>>>
    {
        private readonly ListView _list;
        private readonly Agenda _agenda;

        public DownloadTest(ListView list, Agenda agenda) {
            _list = list;
            _agenda = agenda;
        }

        protected override List<Tuple<string, string>> RunInBackground(params string[] @params)
        {
            var webClient = new WebClient();
            var stream= webClient.OpenRead(@params[0]);
            var reader = XmlReader.Create(stream);

            var eventList = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Begrüßung", "22.03.16 - 12.30Uhr"),
                new Tuple<string, string>("Veranstaltung1", "22.03.16 - 17.30Uhr"),
                new Tuple<string, string>("Veranstaltung2", "23.03.16 - 12.30Uhr")
            };
            //var eventList  = new string[] {"Begrüßung" , "Veranstaltung1" , "Veranstaltung2" };
            Console.WriteLine("Onpost1");

			stream.Close();
            return eventList;
        }

        protected override void OnPostExecute(Java.Lang.Object result)
		{
            base.OnPostExecute(result);
		}

        protected override void OnPostExecute(List<Tuple<string, string>> result)
        {
            Console.WriteLine("Onpost2");
			var adapter = new TwoLineAdapter(_agenda, result);
			_list.Adapter = adapter;
		}
    }
}
       
