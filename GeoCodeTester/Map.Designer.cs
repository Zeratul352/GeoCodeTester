namespace GeoCodeTester
{
    partial class Map
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
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.latitude = new System.Windows.Forms.TextBox();
            this.longitude = new System.Windows.Forms.TextBox();
            this.build = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AutoSize = true;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(605, 426);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // latitude
            // 
            this.latitude.Location = new System.Drawing.Point(635, 13);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(153, 22);
            this.latitude.TabIndex = 1;
            // 
            // longitude
            // 
            this.longitude.Location = new System.Drawing.Point(635, 64);
            this.longitude.Name = "longitude";
            this.longitude.Size = new System.Drawing.Size(153, 22);
            this.longitude.TabIndex = 2;
            // 
            // build
            // 
            this.build.Location = new System.Drawing.Point(635, 122);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(153, 54);
            this.build.TabIndex = 3;
            this.build.Text = "Add";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.build_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(635, 227);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(153, 54);
            this.clear.TabIndex = 4;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.build);
            this.Controls.Add(this.longitude);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.gmap);
            this.Name = "Map";
            this.Text = "Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TextBox latitude;
        private System.Windows.Forms.TextBox longitude;
        private System.Windows.Forms.Button build;
        private System.Windows.Forms.Button clear;
    }
}