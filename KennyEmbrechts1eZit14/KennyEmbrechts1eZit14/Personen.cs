using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace KennyEmbrechts1eZit14
{
    public class BaseClass : INotifyPropertyChanged
    {
        public void Notify(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class Rootobject
    {
        public Personen[] Personen { get; set; }
    }

    public class Personen
    {
        public string _id { get; set; }
        public int index { get; set; }
        public bool isActive { get; set; }
        public string balance { get; set; }
        public string picture { get; set; }
        public int age { get; set; }
        public string eyeColor { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string geslacht
        {
            get { if (gender == "female") return "female.png"; else return "male.png"; }
        }

        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string registered { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string[] tags { get; set; }
        public Friend[] friends { get; set; }
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }
    }

    public class Friend
    {
    public int id { get; set; }
    public string name { get; set; }
    }

    class Mensen : BaseClass
    {
        private static List<Personen> AllePersonen = new List<Personen>();
        public static List<Personen> readJsonData()
        {
            using (StreamReader sr = new StreamReader("personen.json"))
            {
                string jsondata = sr.ReadToEnd();
                Rootobject data = JsonConvert.DeserializeObject<Rootobject>(jsondata);
                int getal = 0;
                foreach (var zwembad in data.Personen)
                {
                    if (getal != 0)
                    {
                        AllePersonen.Add(zwembad);
                    }
                    getal++;
                }
            }


            return AllePersonen;
        }
    }
}
