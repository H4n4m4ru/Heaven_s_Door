namespace Heaven_s_Door
{
    partial class Board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.A_val = new System.Windows.Forms.TextBox();
            this.B_val = new System.Windows.Forms.TextBox();
            this.G_val = new System.Windows.Forms.TextBox();
            this.R_val = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Alpha = new System.Windows.Forms.TrackBar();
            this.Blue = new System.Windows.Forms.TrackBar();
            this.Green = new System.Windows.Forms.TrackBar();
            this.Red = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.EraserColorDisplay = new System.Windows.Forms.PictureBox();
            this.PenColorDisplay = new System.Windows.Forms.PictureBox();
            this.turna = new System.Windows.Forms.PictureBox();
            this.Picker = new System.Windows.Forms.Button();
            this.Blucket = new System.Windows.Forms.Button();
            this.Eraser = new System.Windows.Forms.Button();
            this.Pencil = new System.Windows.Forms.Button();
            this.ColorPool = new System.Windows.Forms.PictureBox();
            this.ColorRing = new System.Windows.Forms.PictureBox();
            this.PenWidth = new System.Windows.Forms.TrackBar();
            this.PenPreview = new System.Windows.Forms.PictureBox();
            this.PenWidthLabel1 = new System.Windows.Forms.Label();
            this.PenWidthVal = new System.Windows.Forms.Label();
            this.PenWidthLabel2 = new System.Windows.Forms.Label();
            this.ErrorRange = new System.Windows.Forms.TrackBar();
            this.ErrorRangeLabel1 = new System.Windows.Forms.Label();
            this.ErrorRangeVal = new System.Windows.Forms.Label();
            this.Debuger = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraserColorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenColorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorRange)).BeginInit();
            this.SuspendLayout();
            // 
            // A_val
            // 
            this.A_val.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.A_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.A_val.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.A_val.ForeColor = System.Drawing.Color.GreenYellow;
            this.A_val.Location = new System.Drawing.Point(908, 327);
            this.A_val.Multiline = true;
            this.A_val.Name = "A_val";
            this.A_val.Size = new System.Drawing.Size(47, 22);
            this.A_val.TabIndex = 27;
            this.A_val.Text = "255";
            this.A_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.A_val.TextChanged += new System.EventHandler(this.A_val_TextChanged);
            this.A_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.A_val_KeyPress);
            this.A_val.Leave += new System.EventHandler(this.A_val_Leave);
            // 
            // B_val
            // 
            this.B_val.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.B_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.B_val.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_val.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_val.Location = new System.Drawing.Point(908, 295);
            this.B_val.Multiline = true;
            this.B_val.Name = "B_val";
            this.B_val.Size = new System.Drawing.Size(47, 22);
            this.B_val.TabIndex = 26;
            this.B_val.Text = "0";
            this.B_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.B_val.TextChanged += new System.EventHandler(this.B_val_TextChanged);
            this.B_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.B_val_KeyPress);
            this.B_val.Leave += new System.EventHandler(this.B_val_Leave);
            // 
            // G_val
            // 
            this.G_val.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.G_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.G_val.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.G_val.ForeColor = System.Drawing.Color.GreenYellow;
            this.G_val.Location = new System.Drawing.Point(908, 263);
            this.G_val.Multiline = true;
            this.G_val.Name = "G_val";
            this.G_val.Size = new System.Drawing.Size(47, 22);
            this.G_val.TabIndex = 25;
            this.G_val.Text = "0";
            this.G_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G_val.TextChanged += new System.EventHandler(this.G_val_TextChanged);
            this.G_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.G_val_KeyPress);
            this.G_val.Leave += new System.EventHandler(this.G_val_Leave);
            // 
            // R_val
            // 
            this.R_val.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.R_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.R_val.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.R_val.ForeColor = System.Drawing.Color.GreenYellow;
            this.R_val.Location = new System.Drawing.Point(908, 231);
            this.R_val.Multiline = true;
            this.R_val.Name = "R_val";
            this.R_val.Size = new System.Drawing.Size(47, 22);
            this.R_val.TabIndex = 24;
            this.R_val.Text = "255";
            this.R_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R_val.TextChanged += new System.EventHandler(this.R_val_TextChanged);
            this.R_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.R_val_KeyPress);
            this.R_val.Leave += new System.EventHandler(this.R_val_Leave);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.GreenYellow;
            this.label4.Location = new System.Drawing.Point(734, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "A";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(734, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "B";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.GreenYellow;
            this.label2.Location = new System.Drawing.Point(734, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "G";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Alpha
            // 
            this.Alpha.AutoSize = false;
            this.Alpha.Location = new System.Drawing.Point(746, 327);
            this.Alpha.Maximum = 255;
            this.Alpha.Name = "Alpha";
            this.Alpha.Size = new System.Drawing.Size(165, 29);
            this.Alpha.TabIndex = 20;
            this.Alpha.TickFrequency = 32;
            this.Alpha.Value = 255;
            this.Alpha.Scroll += new System.EventHandler(this.Alpha_Scroll);
            // 
            // Blue
            // 
            this.Blue.AutoSize = false;
            this.Blue.Location = new System.Drawing.Point(746, 295);
            this.Blue.Maximum = 255;
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(165, 29);
            this.Blue.TabIndex = 19;
            this.Blue.TickFrequency = 32;
            this.Blue.Scroll += new System.EventHandler(this.Blue_Scroll);
            // 
            // Green
            // 
            this.Green.AutoSize = false;
            this.Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Green.Location = new System.Drawing.Point(746, 263);
            this.Green.Maximum = 255;
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(165, 29);
            this.Green.TabIndex = 18;
            this.Green.TickFrequency = 32;
            this.Green.Scroll += new System.EventHandler(this.Green_Scroll);
            // 
            // Red
            // 
            this.Red.AutoSize = false;
            this.Red.LargeChange = 16;
            this.Red.Location = new System.Drawing.Point(746, 231);
            this.Red.Maximum = 255;
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(165, 29);
            this.Red.TabIndex = 17;
            this.Red.TickFrequency = 32;
            this.Red.Value = 255;
            this.Red.Scroll += new System.EventHandler(this.Red_Scroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(734, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "R";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EraserColorDisplay
            // 
            this.EraserColorDisplay.BackColor = System.Drawing.Color.White;
            this.EraserColorDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EraserColorDisplay.Location = new System.Drawing.Point(8, 398);
            this.EraserColorDisplay.Name = "EraserColorDisplay";
            this.EraserColorDisplay.Size = new System.Drawing.Size(23, 23);
            this.EraserColorDisplay.TabIndex = 35;
            this.EraserColorDisplay.TabStop = false;
            // 
            // PenColorDisplay
            // 
            this.PenColorDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PenColorDisplay.Location = new System.Drawing.Point(8, 343);
            this.PenColorDisplay.Name = "PenColorDisplay";
            this.PenColorDisplay.Size = new System.Drawing.Size(23, 23);
            this.PenColorDisplay.TabIndex = 30;
            this.PenColorDisplay.TabStop = false;
            // 
            // turna
            // 
            this.turna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.turna.Cursor = System.Windows.Forms.Cursors.Default;
            this.turna.Image = global::Heaven_s_Door.Properties.Resources.turn_32__gray;
            this.turna.Location = new System.Drawing.Point(5, 368);
            this.turna.Name = "turna";
            this.turna.Size = new System.Drawing.Size(28, 28);
            this.turna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.turna.TabIndex = 0;
            this.turna.TabStop = false;
            this.turna.Click += new System.EventHandler(this.turna_Click);
            this.turna.MouseEnter += new System.EventHandler(this.turna_MouseEnter);
            this.turna.MouseLeave += new System.EventHandler(this.turna_MouseLeave);
            // 
            // Picker
            // 
            this.Picker.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.Picker.FlatAppearance.BorderSize = 2;
            this.Picker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(104)))), ((int)(((byte)(228)))));
            this.Picker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(104)))), ((int)(((byte)(228)))));
            this.Picker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Picker.Image = global::Heaven_s_Door.Properties.Resources.Picker;
            this.Picker.Location = new System.Drawing.Point(7, 131);
            this.Picker.Name = "Picker";
            this.Picker.Size = new System.Drawing.Size(26, 26);
            this.Picker.TabIndex = 34;
            this.Picker.UseVisualStyleBackColor = true;
            this.Picker.Click += new System.EventHandler(this.Picker_Click);
            // 
            // Blucket
            // 
            this.Blucket.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Blucket.FlatAppearance.BorderSize = 2;
            this.Blucket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(148)))), ((int)(((byte)(166)))));
            this.Blucket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(148)))), ((int)(((byte)(166)))));
            this.Blucket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Blucket.Image = ((System.Drawing.Image)(resources.GetObject("Blucket.Image")));
            this.Blucket.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Blucket.Location = new System.Drawing.Point(7, 92);
            this.Blucket.Name = "Blucket";
            this.Blucket.Size = new System.Drawing.Size(26, 26);
            this.Blucket.TabIndex = 33;
            this.Blucket.UseVisualStyleBackColor = true;
            this.Blucket.Click += new System.EventHandler(this.Blucket_Click);
            // 
            // Eraser
            // 
            this.Eraser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Eraser.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.Eraser.FlatAppearance.BorderSize = 2;
            this.Eraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(3)))), ((int)(((byte)(168)))));
            this.Eraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(3)))), ((int)(((byte)(168)))));
            this.Eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eraser.Image = ((System.Drawing.Image)(resources.GetObject("Eraser.Image")));
            this.Eraser.Location = new System.Drawing.Point(7, 53);
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(26, 26);
            this.Eraser.TabIndex = 32;
            this.Eraser.UseVisualStyleBackColor = false;
            this.Eraser.Click += new System.EventHandler(this.Eraser_Click);
            // 
            // Pencil
            // 
            this.Pencil.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(26)))), ((int)(((byte)(125)))));
            this.Pencil.FlatAppearance.BorderSize = 2;
            this.Pencil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.Pencil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.Pencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pencil.Image = global::Heaven_s_Door.Properties.Resources.pen;
            this.Pencil.Location = new System.Drawing.Point(7, 14);
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(26, 26);
            this.Pencil.TabIndex = 31;
            this.Pencil.UseVisualStyleBackColor = true;
            this.Pencil.Click += new System.EventHandler(this.Pencil_Click);
            // 
            // ColorPool
            // 
            this.ColorPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPool.Location = new System.Drawing.Point(792, 58);
            this.ColorPool.Name = "ColorPool";
            this.ColorPool.Size = new System.Drawing.Size(116, 116);
            this.ColorPool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ColorPool.TabIndex = 28;
            this.ColorPool.TabStop = false;
            this.ColorPool.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorPool_Paint);
            this.ColorPool.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPool_MouseDown);
            this.ColorPool.MouseEnter += new System.EventHandler(this.ColorPool_MouseEnter);
            this.ColorPool.MouseLeave += new System.EventHandler(this.ColorPool_MouseLeave);
            this.ColorPool.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorPool_MouseMove);
            this.ColorPool.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ColorPool_MouseUp);
            // 
            // ColorRing
            // 
            this.ColorRing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ColorRing.BackgroundImage = global::Heaven_s_Door.Properties.Resources.fool;
            this.ColorRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorRing.Location = new System.Drawing.Point(0, 0);
            this.ColorRing.Name = "ColorRing";
            this.ColorRing.Size = new System.Drawing.Size(969, 436);
            this.ColorRing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ColorRing.TabIndex = 29;
            this.ColorRing.TabStop = false;
            this.ColorRing.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorRing_Paint);
            this.ColorRing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorRing_MouseDown);
            this.ColorRing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorRing_MouseMove);
            this.ColorRing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ColorRing_MouseUp);
            // 
            // PenWidth
            // 
            this.PenWidth.AutoSize = false;
            this.PenWidth.Location = new System.Drawing.Point(797, 393);
            this.PenWidth.Maximum = 50;
            this.PenWidth.Minimum = 1;
            this.PenWidth.Name = "PenWidth";
            this.PenWidth.Size = new System.Drawing.Size(162, 29);
            this.PenWidth.TabIndex = 36;
            this.PenWidth.TickFrequency = 5;
            this.PenWidth.Value = 1;
            this.PenWidth.Scroll += new System.EventHandler(this.PenWidth_Scroll);
            // 
            // PenPreview
            // 
            this.PenPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.PenPreview.Location = new System.Drawing.Point(737, 364);
            this.PenPreview.Name = "PenPreview";
            this.PenPreview.Size = new System.Drawing.Size(58, 58);
            this.PenPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PenPreview.TabIndex = 37;
            this.PenPreview.TabStop = false;
            // 
            // PenWidthLabel1
            // 
            this.PenWidthLabel1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PenWidthLabel1.ForeColor = System.Drawing.Color.GreenYellow;
            this.PenWidthLabel1.Location = new System.Drawing.Point(802, 368);
            this.PenWidthLabel1.Name = "PenWidthLabel1";
            this.PenWidthLabel1.Size = new System.Drawing.Size(101, 22);
            this.PenWidthLabel1.TabIndex = 38;
            this.PenWidthLabel1.Text = "Pen Width  :";
            this.PenWidthLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PenWidthVal
            // 
            this.PenWidthVal.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PenWidthVal.ForeColor = System.Drawing.Color.GreenYellow;
            this.PenWidthVal.Location = new System.Drawing.Point(880, 368);
            this.PenWidthVal.Name = "PenWidthVal";
            this.PenWidthVal.Size = new System.Drawing.Size(28, 22);
            this.PenWidthVal.TabIndex = 39;
            this.PenWidthVal.Text = "1";
            this.PenWidthVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PenWidthLabel2
            // 
            this.PenWidthLabel2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PenWidthLabel2.ForeColor = System.Drawing.Color.GreenYellow;
            this.PenWidthLabel2.Location = new System.Drawing.Point(905, 368);
            this.PenWidthLabel2.Name = "PenWidthLabel2";
            this.PenWidthLabel2.Size = new System.Drawing.Size(29, 22);
            this.PenWidthLabel2.TabIndex = 40;
            this.PenWidthLabel2.Text = "pt";
            this.PenWidthLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ErrorRange
            // 
            this.ErrorRange.AutoSize = false;
            this.ErrorRange.Enabled = false;
            this.ErrorRange.Location = new System.Drawing.Point(797, 393);
            this.ErrorRange.Maximum = 255;
            this.ErrorRange.Name = "ErrorRange";
            this.ErrorRange.Size = new System.Drawing.Size(162, 29);
            this.ErrorRange.TabIndex = 41;
            this.ErrorRange.TickFrequency = 16;
            this.ErrorRange.Visible = false;
            this.ErrorRange.Scroll += new System.EventHandler(this.ErrorRange_Scroll);
            // 
            // ErrorRangeLabel1
            // 
            this.ErrorRangeLabel1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ErrorRangeLabel1.ForeColor = System.Drawing.Color.GreenYellow;
            this.ErrorRangeLabel1.Location = new System.Drawing.Point(802, 368);
            this.ErrorRangeLabel1.Name = "ErrorRangeLabel1";
            this.ErrorRangeLabel1.Size = new System.Drawing.Size(66, 22);
            this.ErrorRangeLabel1.TabIndex = 42;
            this.ErrorRangeLabel1.Text = "擴散範圍 :";
            this.ErrorRangeLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ErrorRangeLabel1.Visible = false;
            // 
            // ErrorRangeVal
            // 
            this.ErrorRangeVal.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ErrorRangeVal.ForeColor = System.Drawing.Color.GreenYellow;
            this.ErrorRangeVal.Location = new System.Drawing.Point(867, 368);
            this.ErrorRangeVal.Name = "ErrorRangeVal";
            this.ErrorRangeVal.Size = new System.Drawing.Size(32, 22);
            this.ErrorRangeVal.TabIndex = 44;
            this.ErrorRangeVal.Text = "0";
            this.ErrorRangeVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ErrorRangeVal.Visible = false;
            // 
            // Debuger
            // 
            this.Debuger.AutoSize = true;
            this.Debuger.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Debuger.ForeColor = System.Drawing.Color.GreenYellow;
            this.Debuger.Location = new System.Drawing.Point(920, 210);
            this.Debuger.Name = "Debuger";
            this.Debuger.Size = new System.Drawing.Size(0, 11);
            this.Debuger.TabIndex = 45;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(969, 436);
            this.Controls.Add(this.Debuger);
            this.Controls.Add(this.ErrorRangeVal);
            this.Controls.Add(this.ErrorRangeLabel1);
            this.Controls.Add(this.ErrorRange);
            this.Controls.Add(this.PenWidthLabel2);
            this.Controls.Add(this.PenWidthVal);
            this.Controls.Add(this.PenWidthLabel1);
            this.Controls.Add(this.PenPreview);
            this.Controls.Add(this.PenWidth);
            this.Controls.Add(this.EraserColorDisplay);
            this.Controls.Add(this.PenColorDisplay);
            this.Controls.Add(this.turna);
            this.Controls.Add(this.Picker);
            this.Controls.Add(this.Blucket);
            this.Controls.Add(this.Eraser);
            this.Controls.Add(this.Pencil);
            this.Controls.Add(this.A_val);
            this.Controls.Add(this.B_val);
            this.Controls.Add(this.G_val);
            this.Controls.Add(this.R_val);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Alpha);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorPool);
            this.Controls.Add(this.ColorRing);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Board";
            this.Load += new System.EventHandler(this.Board_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraserColorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenColorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox A_val;
        public System.Windows.Forms.TextBox B_val;
        public System.Windows.Forms.TextBox G_val;
        public System.Windows.Forms.TextBox R_val;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TrackBar Alpha;
        public System.Windows.Forms.TrackBar Blue;
        public System.Windows.Forms.TrackBar Green;
        public System.Windows.Forms.TrackBar Red;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ColorPool;
        private System.Windows.Forms.PictureBox ColorRing;
        private System.Windows.Forms.PictureBox PenColorDisplay;
        private System.Windows.Forms.Button Pencil;
        private System.Windows.Forms.Button Eraser;
        private System.Windows.Forms.Button Blucket;
        private System.Windows.Forms.Button Picker;
        private System.Windows.Forms.PictureBox EraserColorDisplay;
        private System.Windows.Forms.PictureBox turna;
        public System.Windows.Forms.TrackBar PenWidth;
        private System.Windows.Forms.PictureBox PenPreview;
        private System.Windows.Forms.Label PenWidthLabel1;
        private System.Windows.Forms.Label PenWidthVal;
        private System.Windows.Forms.Label PenWidthLabel2;
        private System.Windows.Forms.TrackBar ErrorRange;
        private System.Windows.Forms.Label ErrorRangeLabel1;
        private System.Windows.Forms.Label ErrorRangeVal;
        private System.Windows.Forms.Label Debuger;
    }
}