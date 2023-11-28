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

namespace MyApp
{
    delegate void serialCallback(string val);
    public partial class Form1 : Form
    {
        GMap.NET.WindowsForms.GMapControl gmap;
        GMapOverlay markersOverlay;


        string waypoint_latitude;
        string waypoint_longitude;
        string current_latitude;
        string current_longitude;
        double compass_angle = 0;
        bool loc1_check = false;
        bool loc2_check = false;    
        bool loc3_check = false;
        bool loc4_check = false;    
        bool loc5_check = false;
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
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            
            markersOverlay = new GMapOverlay("markers");
            gmap.Overlays.Add(markersOverlay);
            string[] ports = SerialPort.GetPortNames();
            comboBox_port.Items.AddRange(ports);
            gmap.ShowCenter = false;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 20;
            gmap.Zoom = 10;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButtons.Left;
            panel1.Controls.Add(gmap);
            gmap.MouseClick += MyApp_Mouseclick;
            gmap.Position = new PointLatLng(21, 105);
            compass_picturebox.Image = Compass.DrawCompass(145, 0, 80, 0, 80, compass_picturebox.Size);
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            waypoint_latitude = textBox1.Text;
        }
        
        private void goto_btn_Click(object sender, EventArgs e)
        {
            gmap.Position = new PointLatLng(Convert.ToDouble(21), Convert.ToDouble(105));
            gmap.Zoom = 5;
            gmap.Update();
            gmap.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            waypoint_longitude = textBox2.Text;
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

        private void serialPort_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            string data_receive = serialPort.ReadLine();
            set_text(data_receive);
            //data_receive_text.Invoke((MethodInvoker)delegate
            //{
            //    data_receive_text.AppendText(data_receive + Environment.NewLine);
            //});
        }
        private void set_text(string text)
        {
            if (this.data_receive_text.InvokeRequired)
            {
                serialCallback scb = new serialCallback(set_text);
                this.Invoke(scb, new object[] {text});
            }
            else
            {
                string[] loc = text.Split(' ');
                current_latitude = loc[0];
                current_longitude = loc[1];
                //data_receive_text.Text = text;
                textBox1.Text = current_latitude;
                textBox2.Text = current_longitude;
            }    
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Write("a");
                    Thread.Sleep(1000);
                    serialPort.Write("b");
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending command to Arduino: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void add1_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint1_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.red); 
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc1_check = true;
            
        }
        
        private void add2_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint2_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc2_check = true;
        }

        private void add3_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint3_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.red); ;
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc3_check = true;
        }

        private void add4_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint4_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.red); ;
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc4_check = true;  
        }

        private void add5_Click(object sender, EventArgs e)
        {
            string[] loc = waypoint5_text.Text.Split(';');
            double lat = Convert.ToDouble(loc[0]);
            double lon = Convert.ToDouble(loc[1]);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.red); ;
            markersOverlay.Markers.Add(marker);
            gmap.Zoom += 1;
            gmap.Zoom -= 1;
            loc5_check = true;  
        }

        private void del1_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
                waypoint1.Text = null;
                waypoint1_text.Enabled = true;
                loc1_check = false;
            }
        }

        private void del2_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
                waypoint2_text.Text = null;
                waypoint2_text.Enabled = true;
                loc2_check = false;
            }
        }

        private void del3_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
                waypoint3_text.Text = null;
                waypoint3_text.Enabled = true;
                loc3_check = false;
            }
        }

        private void del4_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
                waypoint4_text.Text = null;
                waypoint4_text.Enabled = true;
                loc4_check = false;
            }
        }

        private void del5_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count > 0)
            {
                // Remove the last marker in the overlay
                markersOverlay.Markers.RemoveAt(markersOverlay.Markers.Count - 1);
                waypoint5_text.Text = null;
                waypoint5_text.Enabled = true; 
                loc5_check = false;
            }
        }

        private void allwaypoint_del_Click(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();

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
        }
    }
}