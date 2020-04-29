using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoCodeTester
{
    public partial class Map : Form
    {
        GMapOverlay display = new GMapOverlay("Routes");
        PointLatLng start = new PointLatLng(System.Convert.ToDouble(49.9445219), System.Convert.ToDouble(35.9085398));
        public Map()
        {
            GoogleMapProvider.Instance.ApiKey = "AIzaSyCXpTullgkzPeHlXt3pye1M0NX749xW3Q0";
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            // Настройки для компонента GMap
            gmap.Bearing = 0;
            // Перетаскивание правой кнопки мыши
            gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButtons.Left;
            gmap.GrayScaleMode = true;
            // Все маркеры будут показаны
            gmap.MarkersEnabled = true;
            // Максимальное приближение
            gmap.MaxZoom = 18;
            // Минимальное приближение
            gmap.MinZoom = 2;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gmap.NegativeMode = false;
            // Разрешение полигонов
            gmap.PolygonsEnabled = true;
            // Разрешение маршрутов
            gmap.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 15;
            gmap.ShowCenter = false;
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gmap.Position = new GMap.NET.PointLatLng(49.948022, 35.931451);
            gmap.Overlays.Add(display);
        }

        private void build_Click(object sender, EventArgs e)
        {
            try
            {
                double lat = System.Convert.ToDouble(latitude.Text);
                double lng = System.Convert.ToDouble(longitude.Text);
                PointLatLng destination = new PointLatLng(lat, lng);
                List<PointLatLng> list = new List<PointLatLng>();
                var route = GoogleMapProvider.Instance.GetRoute(start, destination, false, true, 10);
                GMapRoute gMapRoute = new GMapRoute(route.Points, "")
                {
                    Stroke = new Pen(Color.Red, 3)
                };
                list.Add(start);
                list.Add(destination);
                //GMapRoute mapRoute = new GMapRoute(list, "");
                display.Routes.Add(gMapRoute);
            }
            catch (Exception a)
            {
                Console.WriteLine("An exception happened in adding a route:");
                Console.WriteLine(a.Message);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            display.Clear();
        }
    }
}
