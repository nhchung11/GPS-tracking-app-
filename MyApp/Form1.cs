﻿using GMap.NET;
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
using System.IO.Ports;
using MyApp;
using GMap.NET.Internals;
using GMap.NET.WindowsForms.Markers;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace MyApp
{

    public partial class Form1 : Form
    {
        GMap.NET.WindowsForms.GMapControl gmap;
        GMapOverlay markersOverlay;
        GMarkerGoogle movingMarker;
        GMapRoute movingRoute;
        List<PointLatLng> pathPoints = new List<PointLatLng>();

        System.Windows.Forms.Timer moveTimer;
        DateTime lastMoveTime;

        int currentPathIndex = 0;
        string waypoint_latitude;
        string waypoint_longitude;

        double compass_angle = 180;
        double cur_lat = 0;
        double cur_lon = 0;

        bool loc1_check = false;
        bool loc2_check = false;
        bool loc3_check = false;
        bool loc4_check = false;
        bool loc5_check = false;

        double[] headings = new double[5];

        public Form1()
        {
            InitializeComponent();

        }
        private void Gmap_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            gmap = new GMap.NET.WindowsForms.GMapControl();
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gmap.Dock = DockStyle.Fill;
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            markersOverlay = new GMapOverlay("markers");
            gmap.Overlays.Add(markersOverlay);
            string[] ports = SerialPort.GetPortNames();
            comboBox_port.Items.AddRange(ports);
            gmap.ShowCenter = false;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 20;
            gmap.Position = new PointLatLng(21.0038676, 105.8405393);
            gmap.Zoom = 10;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButtons.Left;
            panel1.Controls.Add(gmap);
            gmap.MouseClick += MyApp_Mouseclick;
            gmap.Position = new PointLatLng(21, 105);
            compass_picturebox.Image = Compass.DrawCompass(compass_angle, 0, 80, 0, 80, compass_picturebox.Size);
            if (current_lat.Text != "" || current_lon.Text != "")
            {
                movingMarker = new GMarkerGoogle(new PointLatLng(double.Parse(current_lat.Text), double.Parse(current_lon.Text)), GMarkerGoogleType.arrow);
            }
            else
            {
                movingMarker = new GMarkerGoogle(new PointLatLng(21.004489, 105.8458816), GMarkerGoogleType.arrow);
            }
            markersOverlay.Markers.Add(movingMarker);
            movingRoute = new GMapRoute(new List<PointLatLng>(), "MovingRoute");
            movingRoute.Stroke = new Pen(System.Drawing.Color.Blue, 2); // Màu và độ rộng của route
            markersOverlay.Routes.Add(movingRoute);

            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 100; // 0.1 giây
            moveTimer.Tick += MoveMarkerStep;

            serialPort.DataReceived += serialPort_DataReceived_1;
        }
        private void MoveMarkerStep(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan elapsedTime = now - lastMoveTime;

            double totalSeconds = 5.0; // Thời gian di chuyển từ một điểm đến điểm khác (ví dụ: 2 giây)
            double progress = elapsedTime.TotalSeconds / totalSeconds;

            if (progress <= 1.0)
            {
                // Tính toán vị trí mới dựa trên tiến trình (progress)
                double lat = pathPoints[currentPathIndex].Lat + (pathPoints[currentPathIndex + 1].Lat - pathPoints[currentPathIndex].Lat) * progress;
                double lng = pathPoints[currentPathIndex].Lng + (pathPoints[currentPathIndex + 1].Lng - pathPoints[currentPathIndex].Lng) * progress;

                // Cập nhật vị trí của marker
                movingMarker.Position = new PointLatLng(lat, lng);
            }
            else
            {
                // Chuyển đến điểm tiếp theo
                currentPathIndex++;
                lastMoveTime = now;

                // Kiểm tra xem đã đến cuối đường đi chưa
                if (currentPathIndex < pathPoints.Count - 1)
                {
                    // Nếu chưa đến cuối, reset lại progress và tiếp tục di chuyển
                    progress = 0.0;
                }
                else
                {
                    // Đã đến cuối đường đi, dừng Timer
                    moveTimer.Stop();
                    MessageBox.Show("Di chuyển hoàn thành!");
                }
            }
        }

        
        private void goto_btn_Click(object sender, EventArgs e)
        {
            currentPathIndex = 0;
            lastMoveTime = DateTime.Now;
            moveTimer.Start();
            int i = 0;
            foreach (var point in pathPoints)
            {
                Debug.WriteLine($"Latitude: {point.Lat}, Longitude: {point.Lng}");
                double deltaLng = point.Lng - cur_lon;
                double y = Math.Sin(deltaLng) * Math.Sin(point.Lat);
                double x = Math.Cos(cur_lat) * Math.Sin(point.Lat) - Math.Sin(cur_lat) * Math.Cos(point.Lat) * Math.Cos(deltaLng);
                headings[i] = Math.Atan2(y, x) * (180.0 / Math.PI);
                headings[i] = (headings[i] + 360) % 360;
                Debug.Write("heading: ");
                Debug.WriteLine(headings[i]);
                Debug.WriteLine(compass_angle);
                i++;
            }
        }

        private void serialPort_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Read the entire line of data from the serial port
                string receivedData = serialPort.ReadLine();
                string[] splitData = receivedData.Split(' ');

                // Ensure that we have at least two strings
                if (splitData.Length >= 2)
                {
                    // Update the TextBoxes on the UI thread
                    this.Invoke((MethodInvoker)delegate {
                        current_lat.Text = splitData[0];
                        cur_lat = double.Parse(splitData[0]);
                        current_lon.Text = splitData[1];
                        cur_lon = double.Parse(splitData[1]);
                        compass_angle = double.Parse(splitData[2]);
                        heading.Text = splitData[2];
                        compass_picturebox.Image = Compass.DrawCompass(compass_angle, 0, 80, 0, 80, compass_picturebox.Size);
                    });
                }
                // Console.WriteLine(receivedData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading data: {ex.Message}");
            }
        }


        private void MyApp_Mouseclick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                string lat = Convert.ToString(gmap.FromLocalToLatLng(e.X, e.Y).Lat);
                string lon = Convert.ToString(gmap.FromLocalToLatLng(e.X, e.Y).Lng);
                if (loc1_check == false)
                {
                    waypoint1_text.Text = lat + ";" + lon;
                }
                else
                {
                    waypoint1_text.Enabled = false;
                    if (loc2_check == false)
                    {
                        waypoint2_text.Text = lat + ";" + lon;
                    }
                    else
                    {
                        waypoint2_text.Enabled = false;
                        if (loc3_check == false)
                        {
                            waypoint3_text.Text = lat + ";" + lon;
                        }
                        else
                        {
                            waypoint3_text.Enabled = false;
                            if (loc4_check == false)
                            {
                                waypoint4_text.Text = lat + ";" + lon;
                            }
                            else
                            {
                                waypoint4_text.Enabled = false;
                                waypoint5_text.Text = lat + ";" + lon;
                                if (loc5_check == true)
                                {
                                    waypoint5_text.Enabled = false;
                                    gmap.Refresh();
                                }
                            }
                        }
                    }    
                }
            }
        }
        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                connect_to_device_btn.Enabled = true;
                disconnect_btn.Enabled = false;
            }
        }
        
        private void connect_to_device_btn_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.PortName = comboBox_port.Text;
                    serialPort.Open();
                    serialPort.BaudRate = 9600;
                    connect_to_device_btn.Enabled = false;
                    disconnect_btn.Enabled = true;
                    MessageBox.Show("Success");
                    serialPort.Write("a");
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add1_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint1_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            PointLatLng p1 = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(p1, GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc1_check = true;
            pathPoints.Add(p1);
        }
        
        private void add2_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint2_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            PointLatLng p2 = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(p2, GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc2_check = true;
            pathPoints.Add(p2);
            if (!string.IsNullOrWhiteSpace(waypoint1_text.Text))
            {
                string[] loc2 = waypoint1_text.Text.Split(';');
                double lat2 = Convert.ToDouble(loc2[0]);
                double lon2 = Convert.ToDouble(loc2[1]);
                GMapRoute route = new GMapRoute(new PointLatLng[] { new PointLatLng(lat, lon), new PointLatLng(lat2, lon2) }, "MyRoute");
                route.Stroke = new Pen(System.Drawing.Color.Red, 2); // Màu và độ rộng của đường thẳng

                // Thêm đường thẳng vào overlay
                markersOverlay.Routes.Add(route);   
            }
            add2.Enabled = false;
        }

        private void add3_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint3_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            PointLatLng p3 = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(p3, GMarkerGoogleType.red); ;
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc3_check = true;
            pathPoints.Add(p3);
            if (!string.IsNullOrWhiteSpace(waypoint2_text.Text))
            {
                string[] loc2 = waypoint2_text.Text.Split(';');
                double lat2 = Convert.ToDouble(loc2[0]);
                double lon2 = Convert.ToDouble(loc2[1]);
                GMapRoute route = new GMapRoute(new PointLatLng[] { new PointLatLng(lat, lon), new PointLatLng(lat2, lon2) }, "MyRoute");
                route.Stroke = new Pen(System.Drawing.Color.Red, 2); // Màu và độ rộng của đường thẳng

                // Thêm đường thẳng vào overlay
                markersOverlay.Routes.Add(route);
            }
            add3.Enabled = false;
        }

        private void add4_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint4_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            PointLatLng p4 = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(p4, GMarkerGoogleType.red); ;
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc4_check = true;
            pathPoints.Add(p4);
            if (!string.IsNullOrWhiteSpace(waypoint3_text.Text))
            {
                string[] loc2 = waypoint3_text.Text.Split(';');
                double lat2 = Convert.ToDouble(loc2[0]);
                double lon2 = Convert.ToDouble(loc2[1]);
                GMapRoute route = new GMapRoute(new PointLatLng[] { new PointLatLng(lat, lon), new PointLatLng(lat2, lon2) }, "MyRoute");
                route.Stroke = new Pen(System.Drawing.Color.Red, 2); // Màu và độ rộng của đường thẳng

                // Thêm đường thẳng vào overlay
                markersOverlay.Routes.Add(route);
            }
            add4.Enabled = false;
        }

        private void add5_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint5_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            PointLatLng p5 = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(p5, GMarkerGoogleType.red); ;
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc5_check = true;
            pathPoints.Add(p5);
            if (!string.IsNullOrWhiteSpace(waypoint4_text.Text))
            {
                string[] loc2 = waypoint4_text.Text.Split(';');
                double lat2 = Convert.ToDouble(loc2[0]);
                double lon2 = Convert.ToDouble(loc2[1]);
                GMapRoute route = new GMapRoute(new PointLatLng[] { new PointLatLng(lat, lon), new PointLatLng(lat2, lon2) }, "MyRoute");
                route.Stroke = new Pen(System.Drawing.Color.Red, 2); // Màu và độ rộng của đường thẳng

                // Thêm đường thẳng vào overlay
                markersOverlay.Routes.Add(route);
            }
            add5.Enabled = false;
            gmap.Refresh();
        }

        private void del1_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                int index = markersOverlay.Markers.Count - 1;
                markersOverlay.Markers.RemoveAt(index);
                waypoint1.Text = null;
                waypoint1_text.Enabled = true;
                loc1_check = false;
                pathPoints.RemoveAt(index);
            }
            add1.Enabled = true;
        }

        private void del2_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                int index = markersOverlay.Markers.Count - 1;
                markersOverlay.Markers.RemoveAt(index);
                waypoint2_text.Text = null;
                waypoint2_text.Enabled = true;
                loc2_check = false;
                markersOverlay.Routes.RemoveAt(markersOverlay.Routes.Count - 1);
                pathPoints.RemoveAt(index);
            }
            add2.Enabled = true;
        }

        private void del3_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                int index = markersOverlay.Markers.Count - 1;
                markersOverlay.Markers.RemoveAt(index);
                waypoint3_text.Text = null;
                waypoint3_text.Enabled = true;
                loc3_check = false;
                markersOverlay.Routes.RemoveAt(markersOverlay.Routes.Count - 1);
                pathPoints.RemoveAt(index);
            }
            add3.Enabled = true;
        }

        private void del4_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                int index = markersOverlay.Markers.Count - 1;
                markersOverlay.Markers.RemoveAt(index);
                waypoint4_text.Text = null;
                waypoint4_text.Enabled = true;
                loc4_check = false;
                markersOverlay.Routes.RemoveAt(markersOverlay.Routes.Count - 1);
                pathPoints.RemoveAt(index);
            }
            add4.Enabled = true;
        }

        private void del5_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                int index = markersOverlay.Markers.Count - 1;
                markersOverlay.Markers.RemoveAt(index);
                waypoint5_text.Text = null;
                waypoint5_text.Enabled = true; 
                loc5_check = false;
                markersOverlay.Routes.RemoveAt(markersOverlay.Routes.Count - 1);
                pathPoints.RemoveAt(index);
            }
            add5.Enabled = true;
        }

        private void allwaypoint_del_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            markersOverlay.Routes.Clear();

            waypoint1_text.Text = null;
            waypoint1_text.Enabled = true;
            loc1_check = false;

            waypoint2_text.Text = null;
            waypoint2_text.Enabled = true;
            loc2_check = false;

            waypoint3_text.Text = null;
            waypoint3_text.Enabled = true;
            loc3_check = false;

            waypoint4_text.Text = null;
            waypoint4_text.Enabled = true;
            loc4_check = false;

            waypoint5_text.Text = null;
            waypoint5_text.Enabled = true;
            loc5_check = false;
            Debug.WriteLine("Delete all");
        }

        private void locate_btn_Click(object sender, EventArgs e)
        {
            if (current_lat.Text == "" || current_lon.Text == "")
            {
                gmap.Position = new PointLatLng(21.004489, 105.8458816);
                gmap.Zoom = 15;
            }    
            else
            {
                gmap.Position = new PointLatLng(double.Parse(current_lat.Text), double.Parse(current_lon.Text));
                gmap.Zoom = 15;
                movingMarker.Position = new PointLatLng(double.Parse(current_lat.Text), double.Parse(current_lon.Text));
            }    
        }


        // Arduino control
        private void stop()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write("4");      // 0: STOP
            }
        }
        private void forward()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write("1");      // 1: FORWARD
            }
        }

        private void left()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write("3");      // 2: LEFT
            }
        }
        private void right()
        {
            if(serialPort.IsOpen)
            {
                serialPort.Write("2");      // 3: RIGHT
            }
        }
        private void backward()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write("5");      // 4: BACKWARD
            }
        }

        private void forward_btn_Click(object sender, EventArgs e)
        {
            forward();
            Debug.WriteLine("forward");
            System.Threading.Thread.Sleep(1000);
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            stop();
            Debug.WriteLine("stop");
            System.Threading.Thread.Sleep(1000);
        }

        private void backward_btn_Click(object sender, EventArgs e)
        {
            backward();
            Debug.WriteLine("backward");
            System.Threading.Thread.Sleep(1000);
        }

        private void left_btn_Click(object sender, EventArgs e)
        {
            left();
            Debug.WriteLine("left");
            System.Threading.Thread.Sleep(1000);
        }

        private void right_btn_Click(object sender, EventArgs e)
        {
            right();
            Debug.WriteLine("right");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
