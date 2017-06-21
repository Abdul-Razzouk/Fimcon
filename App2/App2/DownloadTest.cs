
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml;


namespace App2
{

    public class DownloadTest : AsyncTask<String, int, List<Tuple<string, string>>>
    {

        private ListView list;
        private Agenda agenda;

        public DownloadTest(ListView list, Agenda agenda) {
            this.list = list;
            this.agenda = agenda;
        }

        protected override List<Tuple<string, string>> RunInBackground(params String[] @params)
        {
            WebClient webClient = new WebClient();
            Stream stream= webClient.OpenRead(@params[0]);
            XmlReader reader = XmlReader.Create(stream);




			var eventList = new List<Tuple<string, string>>();
			//var eventList  = new string[] {"Begrüßung" , "Veranstaltung1" , "Veranstaltung2" };
			eventList.Add(new Tuple<string, string>("Begrüßung", "22.03.16 - 12.30Uhr"));
			eventList.Add(new Tuple<string, string>("Veranstaltung1", "22.03.16 - 17.30Uhr"));
			eventList.Add(new Tuple<string, string>("Veranstaltung2", "23.03.16 - 12.30Uhr"));
            System.Console.WriteLine("Onpost1");

			stream.Close();
            return eventList;
        }

        protected override void OnPostExecute(Java.Lang.Object result)
		{
            base.OnPostExecute(result);
		}

        protected override void OnPostExecute(List<Tuple<string, string>> result)
        {
            System.Console.WriteLine("Onpost2");
			var adapter = new TwoLineAdapter(agenda, result);
			list.Adapter = adapter;
		}
    }

}
       
