﻿namespace MyApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.locate_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.compass_groupbox = new System.Windows.Forms.GroupBox();
            this.compass_picturebox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disconnect_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.connect_to_device_btn = new System.Windows.Forms.Button();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.longitude_textbox = new System.Windows.Forms.Label();
            this.latitude_textbox = new System.Windows.Forms.Label();
            this.current_lat = new System.Windows.Forms.TextBox();
            this.current_lon = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.waypoint5_del = new System.Windows.Forms.Button();
            this.waypoint4_del = new System.Windows.Forms.Button();
            this.waypoint3_del = new System.Windows.Forms.Button();
            this.waypoint2_del = new System.Windows.Forms.Button();
            this.waypoint1_del = new System.Windows.Forms.Button();
            this.goto_btn = new System.Windows.Forms.Button();
            this.add5 = new System.Windows.Forms.Button();
            this.add4 = new System.Windows.Forms.Button();
            this.add3 = new System.Windows.Forms.Button();
            this.add2 = new System.Windows.Forms.Button();
            this.add1 = new System.Windows.Forms.Button();
            this.waypoint5_text = new System.Windows.Forms.TextBox();
            this.waypoint5 = new System.Windows.Forms.Label();
            this.waypoint4_text = new System.Windows.Forms.TextBox();
            this.waypoint4 = new System.Windows.Forms.Label();
            this.waypoint3_text = new System.Windows.Forms.TextBox();
            this.waypoint3 = new System.Windows.Forms.Label();
            this.allwaypoint_del = new System.Windows.Forms.Button();
            this.waypoint1_text = new System.Windows.Forms.TextBox();
            this.waypoint2_text = new System.Windows.Forms.TextBox();
            this.waypoint_lon = new System.Windows.Forms.Label();
            this.waypoint1 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.forward_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.backward_btn = new System.Windows.Forms.Button();
            this.left_btn = new System.Windows.Forms.Button();
            this.right_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.compass_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compass_picturebox)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.locate_btn);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.compass_groupbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(343, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 811);
            this.panel1.TabIndex = 0;
            // 
            // locate_btn
            // 
            this.locate_btn.Location = new System.Drawing.Point(977, 242);
            this.locate_btn.Name = "locate_btn";
            this.locate_btn.Size = new System.Drawing.Size(75, 23);
            this.locate_btn.TabIndex = 3;
            this.locate_btn.Text = "Locate";
            this.locate_btn.UseVisualStyleBackColor = true;
            this.locate_btn.Click += new System.EventHandler(this.locate_btn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 695);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1070, 116);
            this.panel3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1064, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // compass_groupbox
            // 
            this.compass_groupbox.Controls.Add(this.compass_picturebox);
            this.compass_groupbox.Location = new System.Drawing.Point(786, 3);
            this.compass_groupbox.Name = "compass_groupbox";
            this.compass_groupbox.Size = new System.Drawing.Size(272, 233);
            this.compass_groupbox.TabIndex = 2;
            this.compass_groupbox.TabStop = false;
            this.compass_groupbox.Text = "Compass ";
            // 
            // compass_picturebox
            // 
            this.compass_picturebox.Location = new System.Drawing.Point(6, 16);
            this.compass_picturebox.Name = "compass_picturebox";
            this.compass_picturebox.Size = new System.Drawing.Size(260, 211);
            this.compass_picturebox.TabIndex = 1;
            this.compass_picturebox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 811);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disconnect_btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.connect_to_device_btn);
            this.groupBox1.Controls.Add(this.comboBox_port);
            this.groupBox1.Controls.Add(this.longitude_textbox);
            this.groupBox1.Controls.Add(this.latitude_textbox);
            this.groupBox1.Controls.Add(this.current_lat);
            this.groupBox1.Controls.Add(this.current_lon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 173);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device ";
            // 
            // disconnect_btn
            // 
            this.disconnect_btn.Location = new System.Drawing.Point(161, 61);
            this.disconnect_btn.Name = "disconnect_btn";
            this.disconnect_btn.Size = new System.Drawing.Size(147, 23);
            this.disconnect_btn.TabIndex = 15;
            this.disconnect_btn.Text = "Diconnect";
            this.disconnect_btn.UseVisualStyleBackColor = true;
            this.disconnect_btn.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "COMPORT";
            // 
            // connect_to_device_btn
            // 
            this.connect_to_device_btn.Location = new System.Drawing.Point(6, 61);
            this.connect_to_device_btn.Name = "connect_to_device_btn";
            this.connect_to_device_btn.Size = new System.Drawing.Size(149, 23);
            this.connect_to_device_btn.TabIndex = 11;
            this.connect_to_device_btn.Text = "Connect ";
            this.connect_to_device_btn.UseVisualStyleBackColor = true;
            this.connect_to_device_btn.Click += new System.EventHandler(this.connect_to_device_btn_Click);
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(106, 31);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(122, 24);
            this.comboBox_port.TabIndex = 13;
            // 
            // longitude_textbox
            // 
            this.longitude_textbox.AutoSize = true;
            this.longitude_textbox.Location = new System.Drawing.Point(6, 129);
            this.longitude_textbox.Name = "longitude_textbox";
            this.longitude_textbox.Size = new System.Drawing.Size(107, 16);
            this.longitude_textbox.TabIndex = 3;
            this.longitude_textbox.Text = "Current longitude";
            // 
            // latitude_textbox
            // 
            this.latitude_textbox.AutoSize = true;
            this.latitude_textbox.Location = new System.Drawing.Point(6, 98);
            this.latitude_textbox.Name = "latitude_textbox";
            this.latitude_textbox.Size = new System.Drawing.Size(95, 16);
            this.latitude_textbox.TabIndex = 1;
            this.latitude_textbox.Text = "Current latitude";
            // 
            // current_lat
            // 
            this.current_lat.Location = new System.Drawing.Point(123, 95);
            this.current_lat.Name = "current_lat";
            this.current_lat.Size = new System.Drawing.Size(186, 22);
            this.current_lat.TabIndex = 0;
            // 
            // current_lon
            // 
            this.current_lon.Location = new System.Drawing.Point(123, 126);
            this.current_lon.Name = "current_lon";
            this.current_lon.Size = new System.Drawing.Size(186, 22);
            this.current_lon.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.waypoint5_del);
            this.groupBox2.Controls.Add(this.waypoint4_del);
            this.groupBox2.Controls.Add(this.waypoint3_del);
            this.groupBox2.Controls.Add(this.waypoint2_del);
            this.groupBox2.Controls.Add(this.waypoint1_del);
            this.groupBox2.Controls.Add(this.goto_btn);
            this.groupBox2.Controls.Add(this.add5);
            this.groupBox2.Controls.Add(this.add4);
            this.groupBox2.Controls.Add(this.add3);
            this.groupBox2.Controls.Add(this.add2);
            this.groupBox2.Controls.Add(this.add1);
            this.groupBox2.Controls.Add(this.waypoint5_text);
            this.groupBox2.Controls.Add(this.waypoint5);
            this.groupBox2.Controls.Add(this.waypoint4_text);
            this.groupBox2.Controls.Add(this.waypoint4);
            this.groupBox2.Controls.Add(this.waypoint3_text);
            this.groupBox2.Controls.Add(this.waypoint3);
            this.groupBox2.Controls.Add(this.allwaypoint_del);
            this.groupBox2.Controls.Add(this.waypoint1_text);
            this.groupBox2.Controls.Add(this.waypoint2_text);
            this.groupBox2.Controls.Add(this.waypoint_lon);
            this.groupBox2.Controls.Add(this.waypoint1);
            this.groupBox2.Location = new System.Drawing.Point(12, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 608);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set waypoint";
            // 
            // waypoint5_del
            // 
            this.waypoint5_del.Location = new System.Drawing.Point(283, 153);
            this.waypoint5_del.Name = "waypoint5_del";
            this.waypoint5_del.Size = new System.Drawing.Size(26, 23);
            this.waypoint5_del.TabIndex = 27;
            this.waypoint5_del.Text = "-";
            this.waypoint5_del.UseVisualStyleBackColor = true;
            this.waypoint5_del.Click += new System.EventHandler(this.del5_Click);
            // 
            // waypoint4_del
            // 
            this.waypoint4_del.Location = new System.Drawing.Point(283, 117);
            this.waypoint4_del.Name = "waypoint4_del";
            this.waypoint4_del.Size = new System.Drawing.Size(26, 23);
            this.waypoint4_del.TabIndex = 26;
            this.waypoint4_del.Text = "-";
            this.waypoint4_del.UseVisualStyleBackColor = true;
            this.waypoint4_del.Click += new System.EventHandler(this.del4_Click);
            // 
            // waypoint3_del
            // 
            this.waypoint3_del.Location = new System.Drawing.Point(282, 85);
            this.waypoint3_del.Name = "waypoint3_del";
            this.waypoint3_del.Size = new System.Drawing.Size(26, 23);
            this.waypoint3_del.TabIndex = 25;
            this.waypoint3_del.Text = "-";
            this.waypoint3_del.UseVisualStyleBackColor = true;
            this.waypoint3_del.Click += new System.EventHandler(this.del3_Click);
            // 
            // waypoint2_del
            // 
            this.waypoint2_del.Location = new System.Drawing.Point(282, 55);
            this.waypoint2_del.Name = "waypoint2_del";
            this.waypoint2_del.Size = new System.Drawing.Size(26, 23);
            this.waypoint2_del.TabIndex = 24;
            this.waypoint2_del.Text = "-";
            this.waypoint2_del.UseVisualStyleBackColor = true;
            this.waypoint2_del.Click += new System.EventHandler(this.del2_Click);
            // 
            // waypoint1_del
            // 
            this.waypoint1_del.Location = new System.Drawing.Point(283, 26);
            this.waypoint1_del.Name = "waypoint1_del";
            this.waypoint1_del.Size = new System.Drawing.Size(26, 23);
            this.waypoint1_del.TabIndex = 23;
            this.waypoint1_del.Text = "-";
            this.waypoint1_del.UseVisualStyleBackColor = true;
            this.waypoint1_del.Click += new System.EventHandler(this.del1_Click);
            // 
            // goto_btn
            // 
            this.goto_btn.Location = new System.Drawing.Point(6, 192);
            this.goto_btn.Name = "goto_btn";
            this.goto_btn.Size = new System.Drawing.Size(75, 23);
            this.goto_btn.TabIndex = 4;
            this.goto_btn.Text = "Go to";
            this.goto_btn.UseVisualStyleBackColor = true;
            this.goto_btn.Click += new System.EventHandler(this.goto_btn_Click);
            // 
            // add5
            // 
            this.add5.Location = new System.Drawing.Point(258, 153);
            this.add5.Name = "add5";
            this.add5.Size = new System.Drawing.Size(26, 23);
            this.add5.TabIndex = 22;
            this.add5.Text = "+";
            this.add5.UseVisualStyleBackColor = true;
            this.add5.Click += new System.EventHandler(this.add5_Click);
            // 
            // add4
            // 
            this.add4.Location = new System.Drawing.Point(258, 117);
            this.add4.Name = "add4";
            this.add4.Size = new System.Drawing.Size(26, 23);
            this.add4.TabIndex = 21;
            this.add4.Text = "+";
            this.add4.UseVisualStyleBackColor = true;
            this.add4.Click += new System.EventHandler(this.add4_Click);
            // 
            // add3
            // 
            this.add3.Location = new System.Drawing.Point(258, 85);
            this.add3.Name = "add3";
            this.add3.Size = new System.Drawing.Size(26, 23);
            this.add3.TabIndex = 20;
            this.add3.Text = "+";
            this.add3.UseVisualStyleBackColor = true;
            this.add3.Click += new System.EventHandler(this.add3_Click);
            // 
            // add2
            // 
            this.add2.Location = new System.Drawing.Point(258, 55);
            this.add2.Name = "add2";
            this.add2.Size = new System.Drawing.Size(26, 23);
            this.add2.TabIndex = 19;
            this.add2.Text = "+";
            this.add2.UseVisualStyleBackColor = true;
            this.add2.Click += new System.EventHandler(this.add2_Click);
            // 
            // add1
            // 
            this.add1.Location = new System.Drawing.Point(258, 26);
            this.add1.Name = "add1";
            this.add1.Size = new System.Drawing.Size(26, 23);
            this.add1.TabIndex = 18;
            this.add1.Text = "+";
            this.add1.UseVisualStyleBackColor = true;
            this.add1.Click += new System.EventHandler(this.add1_Click);
            // 
            // waypoint5_text
            // 
            this.waypoint5_text.Location = new System.Drawing.Point(95, 153);
            this.waypoint5_text.Name = "waypoint5_text";
            this.waypoint5_text.Size = new System.Drawing.Size(157, 22);
            this.waypoint5_text.TabIndex = 17;
            // 
            // waypoint5
            // 
            this.waypoint5.AutoSize = true;
            this.waypoint5.Location = new System.Drawing.Point(7, 156);
            this.waypoint5.Name = "waypoint5";
            this.waypoint5.Size = new System.Drawing.Size(74, 16);
            this.waypoint5.TabIndex = 16;
            this.waypoint5.Text = "Waypoint 5";
            // 
            // waypoint4_text
            // 
            this.waypoint4_text.Location = new System.Drawing.Point(95, 118);
            this.waypoint4_text.Name = "waypoint4_text";
            this.waypoint4_text.Size = new System.Drawing.Size(157, 22);
            this.waypoint4_text.TabIndex = 15;
            // 
            // waypoint4
            // 
            this.waypoint4.AutoSize = true;
            this.waypoint4.Location = new System.Drawing.Point(6, 121);
            this.waypoint4.Name = "waypoint4";
            this.waypoint4.Size = new System.Drawing.Size(74, 16);
            this.waypoint4.TabIndex = 14;
            this.waypoint4.Text = "Waypoint 4";
            // 
            // waypoint3_text
            // 
            this.waypoint3_text.Location = new System.Drawing.Point(95, 85);
            this.waypoint3_text.Name = "waypoint3_text";
            this.waypoint3_text.Size = new System.Drawing.Size(157, 22);
            this.waypoint3_text.TabIndex = 13;
            // 
            // waypoint3
            // 
            this.waypoint3.AutoSize = true;
            this.waypoint3.Location = new System.Drawing.Point(6, 88);
            this.waypoint3.Name = "waypoint3";
            this.waypoint3.Size = new System.Drawing.Size(74, 16);
            this.waypoint3.TabIndex = 12;
            this.waypoint3.Text = "Waypoint 3";
            // 
            // allwaypoint_del
            // 
            this.allwaypoint_del.Location = new System.Drawing.Point(123, 192);
            this.allwaypoint_del.Name = "allwaypoint_del";
            this.allwaypoint_del.Size = new System.Drawing.Size(75, 23);
            this.allwaypoint_del.TabIndex = 11;
            this.allwaypoint_del.Text = "Delete";
            this.allwaypoint_del.UseVisualStyleBackColor = true;
            this.allwaypoint_del.Click += new System.EventHandler(this.allwaypoint_del_Click);
            // 
            // waypoint1_text
            // 
            this.waypoint1_text.Location = new System.Drawing.Point(95, 26);
            this.waypoint1_text.Name = "waypoint1_text";
            this.waypoint1_text.Size = new System.Drawing.Size(157, 22);
            this.waypoint1_text.TabIndex = 9;
            // 
            // waypoint2_text
            // 
            this.waypoint2_text.Location = new System.Drawing.Point(95, 55);
            this.waypoint2_text.Name = "waypoint2_text";
            this.waypoint2_text.Size = new System.Drawing.Size(157, 22);
            this.waypoint2_text.TabIndex = 10;
            // 
            // waypoint_lon
            // 
            this.waypoint_lon.AutoSize = true;
            this.waypoint_lon.Location = new System.Drawing.Point(6, 58);
            this.waypoint_lon.Name = "waypoint_lon";
            this.waypoint_lon.Size = new System.Drawing.Size(74, 16);
            this.waypoint_lon.TabIndex = 8;
            this.waypoint_lon.Text = "Waypoint 2";
            // 
            // waypoint1
            // 
            this.waypoint1.AutoSize = true;
            this.waypoint1.Location = new System.Drawing.Point(7, 29);
            this.waypoint1.Name = "waypoint1";
            this.waypoint1.Size = new System.Drawing.Size(74, 16);
            this.waypoint1.TabIndex = 7;
            this.waypoint1.Text = "Waypoint 1";
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM3";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.right_btn);
            this.groupBox4.Controls.Add(this.left_btn);
            this.groupBox4.Controls.Add(this.backward_btn);
            this.groupBox4.Controls.Add(this.stop_btn);
            this.groupBox4.Controls.Add(this.forward_btn);
            this.groupBox4.Location = new System.Drawing.Point(10, 222);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 260);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Manual control";
            // 
            // forward_btn
            // 
            this.forward_btn.Location = new System.Drawing.Point(85, 32);
            this.forward_btn.Name = "forward_btn";
            this.forward_btn.Size = new System.Drawing.Size(127, 44);
            this.forward_btn.TabIndex = 0;
            this.forward_btn.Text = "forward";
            this.forward_btn.UseVisualStyleBackColor = true;
            this.forward_btn.Click += new System.EventHandler(this.forward_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(113, 111);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 28);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // backward_btn
            // 
            this.backward_btn.Location = new System.Drawing.Point(85, 173);
            this.backward_btn.Name = "backward_btn";
            this.backward_btn.Size = new System.Drawing.Size(127, 44);
            this.backward_btn.TabIndex = 2;
            this.backward_btn.Text = "Backward";
            this.backward_btn.UseVisualStyleBackColor = true;
            this.backward_btn.Click += new System.EventHandler(this.backward_btn_Click);
            // 
            // left_btn
            // 
            this.left_btn.Location = new System.Drawing.Point(7, 77);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(64, 97);
            this.left_btn.TabIndex = 3;
            this.left_btn.Text = "Left";
            this.left_btn.UseVisualStyleBackColor = true;
            this.left_btn.Click += new System.EventHandler(this.left_btn_Click);
            // 
            // right_btn
            // 
            this.right_btn.Location = new System.Drawing.Point(228, 77);
            this.right_btn.Name = "right_btn";
            this.right_btn.Size = new System.Drawing.Size(64, 97);
            this.right_btn.TabIndex = 4;
            this.right_btn.Text = "Right";
            this.right_btn.UseVisualStyleBackColor = true;
            this.right_btn.Click += new System.EventHandler(this.right_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 811);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.compass_groupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compass_picturebox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label latitude_textbox;
        private System.Windows.Forms.TextBox current_lat;
        private System.Windows.Forms.Label longitude_textbox;
        private System.Windows.Forms.TextBox current_lon;
        private System.Windows.Forms.Button goto_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label waypoint_lon;
        private System.Windows.Forms.Label waypoint1;
        private System.Windows.Forms.TextBox waypoint1_text;
        private System.Windows.Forms.TextBox waypoint2_text;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button connect_to_device_btn;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button disconnect_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button allwaypoint_del;
        private System.Windows.Forms.PictureBox compass_picturebox;
        private System.Windows.Forms.GroupBox compass_groupbox;
        private System.Windows.Forms.TextBox waypoint3_text;
        private System.Windows.Forms.Label waypoint3;
        private System.Windows.Forms.Label waypoint4;
        private System.Windows.Forms.TextBox waypoint5_text;
        private System.Windows.Forms.Label waypoint5;
        private System.Windows.Forms.TextBox waypoint4_text;
        private System.Windows.Forms.Button waypoint5_del;
        private System.Windows.Forms.Button waypoint4_del;
        private System.Windows.Forms.Button waypoint3_del;
        private System.Windows.Forms.Button waypoint2_del;
        private System.Windows.Forms.Button waypoint1_del;
        private System.Windows.Forms.Button add5;
        private System.Windows.Forms.Button add4;
        private System.Windows.Forms.Button add3;
        private System.Windows.Forms.Button add2;
        private System.Windows.Forms.Button add1;
        private System.Windows.Forms.Button locate_btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button forward_btn;
        private System.Windows.Forms.Button right_btn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Button backward_btn;
    }
}

