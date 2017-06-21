using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Xml;


namespace App2


{
    
    [Activity(Label = "Agenda")]
    public class Agenda : Activity
    {
        
        ListView list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Agenda);

              list = FindViewById<ListView>(Resource.Id.listView1);
            //new DownloadTest(list, this).Execute("https://google.de");
             DownloadHomepage();
        }
        public async Task<int> DownloadHomepage()
        {
            var httpClient = new HttpClient();
            Task<string> contentsTask = httpClient.GetStringAsync("http://kei-to.de/fim/xml/example_events.xml");
            string contents = await contentsTask;


            XmlDocument doc = new XmlDocument();
            doc.LoadXml(contents);

            XmlNode root = doc.ChildNodes[1];
		
			var eventList = new List<Tuple<string, string>>();
            if (root.HasChildNodes)
            {
                
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    string titel = "", dis = "", isActive= "", lectures="";
                    XmlNode event1 = root.ChildNodes[i];
                    for (int j = 0; j < event1.ChildNodes.Count;j++) {
                        XmlNode eventattribut = event1.ChildNodes[j];

                        if (eventattribut.Name.Equals("title"))
                            titel = eventattribut.InnerText;
                        
						else if (eventattribut.Name.Equals("description"))
                            dis = eventattribut.InnerText;
                        
						else if (eventattribut.Name.Equals("isActive"))
							isActive = eventattribut.InnerText;
                        
						else if (eventattribut.Name.Equals("lectures"))
							lectures = eventattribut.InnerText;

                    }
					eventList.Add(new Tuple<string, string>(titel, dis));
                    eventList.Add(new Tuple<string, string>(isActive, lectures));


				}

               


            }


			//var eventList  = new string[] {"Begrüßung" , "Veranstaltung1" , "Veranstaltung2" };
			
			//eventList.Add(new Tuple<string, string>("Veranstaltung1", "22.03.16 - 17.30Uhr"));
			//eventList.Add(new Tuple<string, string>("Veranstaltung2", "23.03.16 - 12.30Uhr"));

            var adapter = new TwoLineAdapter(this, eventList);

			list.Adapter = adapter;
			return 0; 
		}
		
    }
}