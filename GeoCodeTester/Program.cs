using GMap.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GeoCodeTester
{
    [Serializable]
    public class LandPoint
    {
        public string place_id { get; set; }
        public int id { get; set; }
        public static int count { get; set; } = 0;
        public string adress { get; set; }
        public PointLatLng coordinates { get; set; }
        public LandPoint() { }
        public LandPoint(int i, string place_code, string adr, double la, double ln)
        {
            id = i;
            place_id = place_code;
            adress = adr;
            coordinates = new PointLatLng(la, ln);
        }
        public LandPoint(int i, string place_code, string adr, PointLatLng point)
        {
            id = i;
            place_id = place_code;
            adress = adr;
            coordinates = point;
        }
        
        public static LandPoint Geocode(string adress)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            
            
                //string adress;
                //adress = reader.ReadLine();
                if (adress == null)
                {
                //reader.Close();
                return null;
                }
                string url = @"https://maps.googleapis.com/maps/api/geocode/xml?address=" + adress + "&key=AIzaSyCXpTullgkzPeHlXt3pye1M0NX749xW3Q0";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(dataStream);
                xmldoc.Save("GeocodeingResponse");
                XmlElement xRoot = xmldoc.DocumentElement;
                //XmlNodeList geometry = xmldoc.SelectNodes("geometry");
                if (xmldoc.SelectSingleNode("GeocodeResponse/result/geometry/location/lat") == null)
                {
                return null;
                }
                string lat = xmldoc.SelectSingleNode("GeocodeResponse/result/geometry/location/lat").InnerText;
                string lng = xmldoc.SelectSingleNode("GeocodeResponse/result/geometry/location/lng").InnerText;
                string place_id = xmldoc.SelectSingleNode("GeocodeResponse/result/place_id").InnerText;
            adress = xmldoc.SelectSingleNode("GeocodeResponse/result/formatted_address").InnerText;
                double latitude = double.Parse(lat);
                double longitude = double.Parse(lng);
                PointLatLng point = new PointLatLng(latitude, longitude);
                LandPoint temp = new LandPoint(count, place_id, adress, point);
                count++;
            
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            return temp;
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Application.EnableVisualStyles();
            Application.Run(map);
            List<LandPoint> points = new List<LandPoint>();
            string command;
            Console.WriteLine("Add = input coordinates & adress, than add point to the list");
            Console.WriteLine("Geocode = input adress, geocode, than wait for validation");
            Console.WriteLine("Exit = finish and save results");
            command = Console.ReadLine();
            while(command != "Exit"){
                if (command == "Add")
                {
                    Console.WriteLine("Input Latitude and Longitude in different lines");
                    double lat = System.Convert.ToDouble(Console.ReadLine());
                    double lng = System.Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Now input adress");
                    string adress = Console.ReadLine();
                    LandPoint temp = new LandPoint(1, "NO_PLACE_CODE", adress, lat, lng);
                    points.Add(temp);
                }
                else if (command == "Geocode")
                {
                    Console.WriteLine("Your request:");
                    string request = Console.ReadLine();
                    LandPoint temp = LandPoint.Geocode(command);
                    if (temp == null)
                    {
                        Console.WriteLine("Nothing found");
                    }
                    else
                    {
                        Console.WriteLine(temp.adress);
                    }
                    Console.WriteLine("Print ok to add or no to ignore results");
                    string valid = Console.ReadLine();
                    if (valid == "ok")
                    {
                        points.Add(temp);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Name of file for save is");
            XmlSerializer formatter = new XmlSerializer(typeof(List<LandPoint>));

            using (FileStream fs = new FileStream(Console.ReadLine() + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, points);
            }
        }
    }
}
