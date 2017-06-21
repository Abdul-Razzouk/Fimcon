﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Net.Http;
using System.Xml;

namespace App2
{
    
    [Activity(Label = "Agenda")]
    public class Agenda : Activity
    {
        private ListView _list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Agenda);

              _list = FindViewById<ListView>(Resource.Id.listView1);
            //new DownloadTest(list, this).Execute("https://google.de");

            //todo this is a async method without await
            DownloadHomepage();
        }

        private async Task<int> DownloadHomepage()
        {
            var httpClient = new HttpClient();
            var contentsTask = httpClient.GetStringAsync("http://kei-to.de/fim/xml/example_events.xml");
            var contents = await contentsTask;

            var doc = new XmlDocument();
            doc.LoadXml(contents);

            var root = doc.ChildNodes[1];
		
			var eventList = new List<Tuple<string, string>>();
            if (root.HasChildNodes)
            {             
                for (var i = 0; i < root.ChildNodes.Count; i++)
                {
                    string titel = "", dis = "", isActive= "", lectures="";
                    var event1 = root.ChildNodes[i];
                    for (var j = 0; j < event1.ChildNodes.Count;j++) {
                        var eventattribut = event1.ChildNodes[j];

                        if (eventattribut.Name.Equals("title"))
                            titel = eventattribut.InnerText;
                        
						else if (eventattribut.Name.Equals("description"))
                            dis = eventattribut.InnerText;
                        
						/*else if (eventattribut.Name.Equals("isActive"))
							isActive = eventattribut.InnerText;
                        
						else if (eventattribut.Name.Equals("lectures"))
							lectures = eventattribut.InnerText;*/

                    }
					eventList.Add(new Tuple<string, string>(titel, dis));
                    eventList.Add(new Tuple<string, string>(isActive, lectures));                
				}          
            }
			//var eventList  = new string[] {"Begrüßung" , "Veranstaltung1" , "Veranstaltung2" };
			
			//eventList.Add(new Tuple<string, string>("Veranstaltung1", "22.03.16 - 17.30Uhr"));
			//eventList.Add(new Tuple<string, string>("Veranstaltung2", "23.03.16 - 12.30Uhr"));

            var adapter = new TwoLineAdapter(this, eventList);

			_list.Adapter = adapter;
			return 0; 
		}		
    }
}