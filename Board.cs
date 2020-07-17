using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//Update:2017-02-13_21-54
namespace Heaven_s_Door
{
    public partial class Board : Form
    {
        Pen _brush = new Pen(Color.Black, 1);
        Pen _eraser = new Pen(Color.White, 1);
        Point Poolpoint_Lock_on;    //色池目前的鎖定位置
        bool EnterPressed = false;  //是否輸入enter的旗標
        //====================== ColorRing ========================
        Pen ColorRing_Dot = new Pen(Color.White, 3);
        Bitmap ColorRingBgImageClone;
        //=================== 繪製SV矩陣用 ========================
        Bitmap bm_temp = new Bitmap(116, 116);                   //繪圖用的bitmap物件
        double bm_temp_Size;                                     //bm_temp寬度(像素)的常數
        double H, S, V, _minimum, _incresing, _decresing, delta; //色相(degree,0~359),飽和度(0~1),明度(0~255)
        int posiPrint_X = 0, posiPrint_Y = 0, section = 0;       //繪製的座標,色相目前的區段(0~5)
        Pen ReverseColor = new Pen(Color.White, 3);
        Rectangle bm_temp_Rectangle;
        //======================= 繪圖區 ==========================
        HanaPanel Hana;                                          //Panel物件
        int Hana_Width;                                          //Panel寬
        int Hana_Height;                                         //Panel高
        List<Point> _line = new List<Point>();                   //紀錄路徑
        Bitmap HanaBitmap;                                       //繪製的圖
        Bitmap HanaBuffer;                                       //作為緩衝區用的Bitmap
        bool DrawBuffer = false;                                 //選擇要繪製「已畫完的圖片(HanaBitmap)」還是「正在繪製中的圖片緩衝區(HanaBuffer)」
        Rectangle Hana_Rectangle;
        //====================== 筆刷預覽 =========================
        Bitmap PenPreviewBitmap;
        SolidBrush PenPreviewSBrush = new SolidBrush(Color.FromArgb(255, 31, 31, 31));
        //======================== 游標 ===========================
        Cursor cursor_Pencil, cursor_Eraser, cursor_Picker, cursor_Blucket;    //特定游標
        Bitmap cursor_P_Bitmap = new Bitmap(51, 51);
        Bitmap cursor_E_Bitmap = new Bitmap(51, 51);
        SolidBrush CursorBrush = new SolidBrush(Color.FromArgb(107, 0, 0, 0));
        //======================== 油漆桶 =========================
        int _targetColor_A, _targetColor_R, _targetColor_G, _targetColor_B;    //欲取代之目標顏色
        int _brushColor_A, _brushColor_R, _brushColor_G, _brushColor_B;        //欲填上之筆刷顏色
        Queue<Point> wait_For_Check = new Queue<Point>();
        Point[] directions = { new Point(0, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 0) };  //用於疊代檢查填色區周圍四個點時
        int _error = 0;                                                       //判斷欲取代之顏色時能設定誤差範圍
        //=========================================================
        enum LockArea { 
            InPanel,InPool,InRing,None}
        enum Mode {
            Pencil, Eraser, Blucket, Picker, None
        }
        LockArea _lockarea = LockArea.None;
        Mode _mode = Mode.None;

        void Draw_SV_Matrix(){
            section = (int)H / 60;
            delta = (H / 60.0) - section;
            //====================== 繪製SV矩陣 ====================================================
            BitmapData bm_temp_inMem = bm_temp.LockBits(bm_temp_Rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int offset = bm_temp_inMem.Stride - (int)bm_temp_Size * 3;
            unsafe
            {
                byte* pointer = (byte*)bm_temp_inMem.Scan0;

                for (posiPrint_Y = 0; posiPrint_Y < bm_temp_Size; posiPrint_Y++, pointer += offset)
                {
                    V = ((bm_temp_Size - 1) - posiPrint_Y) / (bm_temp_Size - 1) * 255.0;
                    for (posiPrint_X = 0; posiPrint_X < bm_temp_Size; posiPrint_X++, pointer += 3)
                    {
                        S = posiPrint_X / (bm_temp_Size - 1);
                        if (posiPrint_X == 0)
                        {
                            pointer[2] = pointer[1] = pointer[0] = (byte)(int)V;
                            continue;
                        }
                        _minimum = V * (1 - S);
                        _decresing = V * (1 - S * delta);
                        _incresing = V * (1 - S * (1 - delta));

                        switch (section)
                        {
                            case 0: pointer[2] = (byte)(int)V; pointer[1] = (byte)(int)_incresing; pointer[0] = (byte)(int)_minimum; break;
                            case 1: pointer[2] = (byte)(int)_decresing; pointer[1] = (byte)(int)V; pointer[0] = (byte)(int)_minimum; break;
                            case 2: pointer[2] = (byte)(int)_minimum; pointer[1] = (byte)(int)V; pointer[0] = (byte)(int)_incresing; break;
                            case 3: pointer[2] = (byte)(int)_minimum; pointer[1] = (byte)(int)_decresing; pointer[0] = (byte)(int)V; break;
                            case 4: pointer[2] = (byte)(int)_incresing; pointer[1] = (byte)(int)_minimum; pointer[0] = (byte)(int)V; break;
                            default: pointer[2] = (byte)(int)V; pointer[1] = (byte)(int)_minimum; pointer[0] = (byte)(int)_decresing; break;
                        }
                    }
                }
            }
            bm_temp.UnlockBits(bm_temp_inMem);
        }
        //Draw_SV_Matrix: 根據目前的相位,將bm_temp重繪成對應的SV矩陣(使用前必須確認相位是正確的)
        bool RGB_to_HSV() {
            /* 將會變成S的值*115.0後轉成int,變成poolPoint_Lock_on的X
             * 將會變成V的值/255.0*115.0後拿去給115減掉後的值即為poolPoint_Lock_on的Y
             * 求出H後
             * Draw_Sv_Matrix();
            */
            double _min, _max, _delta;
            double _r = (double)_brush.Color.R; 
            double _g = (double)_brush.Color.G; 
            double _b = (double)_brush.Color.B;
   
            if (_r >= _g){
                if (_r < _b) { _max = _b; _min = _g; }
                else{ _max = _r; _min = (_g >= _b) ? _b : _g; }
            }
            else {
                if (_r >= _b) { _max = _g; _min = _b; }
                else { _min = _r; _max = (_g >= _b) ? _g : _b; }
            }

            Poolpoint_Lock_on.Y = (int)((bm_temp_Size - 1) - (_max / 255.0) * (bm_temp_Size - 1));
            _delta = _max - _min;

            if ((_r == _g) && (_g == _b)){
                //灰階,色相不變,飽和度為0
                Poolpoint_Lock_on.X = 0;
                return false;
            }
            else { 
                //非灰階,飽和度>0
                Poolpoint_Lock_on.X = (int)((_delta / _max) * (bm_temp_Size - 1));
            }

            if (_r == _max) H = (_g - _b) / _delta;     // between yellow & magenta
            else if (_g == _max) H = 2 + (_b - _r) / _delta; // between cyan & yellow
            else H = 4 + (_r - _g) / _delta; // between magenta & cyan
            H = H * 60;               // degrees
            if (H < 0) H += 360;
            return true;
        }
        //RGB_to_HSV:根據目前筆刷的RGB值來推算 相位及色池的鎖定位置,若色相改變則回傳true
        public Board()
        {    //建構式
            InitializeComponent();            
            System.IO.MemoryStream memStream01=new System.IO.MemoryStream(Heaven_s_Door.Properties.Resources.cursor_color_picker);
            System.IO.MemoryStream memStream02 = new System.IO.MemoryStream(Heaven_s_Door.Properties.Resources.Blucket1);
            cursor_Picker = new Cursor(memStream01);
            cursor_Blucket=new Cursor(memStream02);
            bm_temp_Size = (double)bm_temp.Size.Height;
            bm_temp_Rectangle = new Rectangle(0, 0, (int)bm_temp_Size, (int)bm_temp_Size);

            Hana = new HanaPanel();
            Hana_Width = Hana.Width;
            Hana_Height = Hana.Height;
            Hana_Rectangle = new Rectangle(0, 0, Hana_Width, Hana_Height);
            HanaBitmap = new Bitmap(Hana_Width,Hana_Height);
            using (Graphics Hbmp = Graphics.FromImage(HanaBitmap)) Hbmp.Clear(Color.White);
            HanaBuffer = new Bitmap(Hana.Width, Hana.Height);
            PenPreviewBitmap = new Bitmap(PenPreview.Width, PenPreview.Height);
        }
        private void Board_Load(object sender, EventArgs e)
        {
            _mode = Mode.Pencil;
            Pencil.BackColor = Pencil.FlatAppearance.MouseDownBackColor;
            bm_temp.SetResolution(192, 192);
            Poolpoint_Lock_on = new Point((int)(bm_temp_Size-1), 0);
            H = 0;
            
            Draw_SV_Matrix();
            //=======================繪製結束=====================================================
            _brush.Color = bm_temp.GetPixel(Poolpoint_Lock_on.X, Poolpoint_Lock_on.Y);
            PenColorDisplay.BackColor = _brush.Color;

            ColorRing.Invalidate();

            ColorPool.Image = bm_temp;

            this.Controls.Add(Hana);
            Hana.BringToFront();
            Hana.MouseMove += this.HanaPanel_MouseMove;
            Hana.MouseClick += this.HanaPanel_MouseClick;
            Hana.MouseDown += this.HanaPanel_MouseDown;
            Hana.MouseUp += this.HanaPanel_MouseUp;
            Hana.MouseEnter += this.HanaPanel_MouseEnter;
            Hana.MouseLeave += this.HanaPanel_MouseLeave;
            Hana.Paint += this.HanaPanel_Paint;

            using (Graphics gp = Graphics.FromImage(cursor_P_Bitmap)){
                gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gp.FillEllipse(CursorBrush, 25 - _brush.Width / 2, 25 - _brush.Width / 2, 1, 1);
            }
            using (Graphics ge = Graphics.FromImage(cursor_E_Bitmap)){
                ge.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                ge.FillEllipse(CursorBrush, 25 - _eraser.Width / 2, 25 - _eraser.Width / 2, 1, 1);
            }
            cursor_Pencil = new Cursor(cursor_P_Bitmap.GetHicon());
            cursor_Eraser = new Cursor(cursor_E_Bitmap.GetHicon());

            ColorRingBgImageClone = (Bitmap)ColorRing.BackgroundImage.Clone(); ;//複製一份色池的圖片,擷取顏色用
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< HanaPanel_Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void HanaPanel_MouseMove(object sender, MouseEventArgs e){
            //繪圖,橡皮擦
            if (_lockarea != LockArea.InPanel) return;

            if (_mode == Mode.Pencil){
                _line.Add(e.Location);
                HanaBuffer.Dispose();
                HanaBuffer = new Bitmap(HanaBitmap);
                using (Graphics Hbfr = Graphics.FromImage(HanaBuffer)){
                    //畫線
                    Hbfr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Hbfr.DrawLines(_brush, _line.ToArray());
                }
                Hana.Invalidate();
            }
            else if(_mode == Mode.Eraser){
                _line.Add(e.Location);
                HanaBuffer.Dispose();
                HanaBuffer = new Bitmap(HanaBitmap);
                using (Graphics Hbfr = Graphics.FromImage(HanaBuffer)){
                    //畫線
                    Hbfr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Hbfr.DrawLines(_eraser, _line.ToArray());
                }
                Hana.Invalidate();
            }
            else if (_mode == Mode.Picker){
                if ((e.X < 0) || (e.X >= Hana_Width)) return;
                if ((e.Y < 0) || (e.Y >= Hana_Height)) return;

                Color cr_temp = HanaBitmap.GetPixel(e.X, e.Y);//取得顏色
                _brush.Color = Color.FromArgb(_brush.Color.A, cr_temp.R, cr_temp.G, cr_temp.B);
                R_val.Text = _brush.Color.R.ToString();
                G_val.Text = _brush.Color.G.ToString();
                B_val.Text = _brush.Color.B.ToString();
            }
        }
        private void HanaPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (_lockarea != LockArea.InPanel) return;
            if (_mode == Mode.Blucket) {
                Color TargetColor = HanaBitmap.GetPixel(e.X, e.Y);
                if (TargetColor == _brush.Color) return;
                _targetColor_A = TargetColor.A;
                _targetColor_R = TargetColor.R;
                _targetColor_G = TargetColor.G;
                _targetColor_B = TargetColor.B;
                _brushColor_A = _brush.Color.A;
                _brushColor_R = _brush.Color.R;
                _brushColor_G = _brush.Color.G;
                _brushColor_B = _brush.Color.B;
                //已取得欲填滿之色彩範圍
                Blucketio(e.X, e.Y);
            }
            else if (_mode == Mode.Picker) {
                Color cr_temp = HanaBitmap.GetPixel(e.X, e.Y);//取得顏色
                _brush.Color = Color.FromArgb(_brush.Color.A, cr_temp.R, cr_temp.G, cr_temp.B);
                R_val.Text = _brush.Color.R.ToString();
                G_val.Text = _brush.Color.G.ToString();
                B_val.Text = _brush.Color.B.ToString();
            }
        }
        private void HanaPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _lockarea = LockArea.InPanel;
            Hana.Focus();

            if (_mode == Mode.Pencil){
                _line.Add(e.Location);
                HanaBuffer.Dispose();
                HanaBuffer = new Bitmap(HanaBitmap);
                using (Graphics Hbfr = Graphics.FromImage(HanaBuffer)) {
                    //畫點
                    Hbfr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    int _wd = (int)_brush.Width;
                    Hbfr.FillEllipse(new SolidBrush(_brush.Color), e.X - _wd / 2, e.Y - _wd / 2, _wd, _wd);
                }
                DrawBuffer = true;
                Hana.Invalidate();
            }
            else if (_mode == Mode.Eraser) {
                _line.Add(e.Location);
                HanaBuffer.Dispose();
                HanaBuffer = new Bitmap(HanaBitmap);
                using (Graphics Hbfr = Graphics.FromImage(HanaBuffer)){   
                    //畫點
                    Hbfr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    int _wd = (int)_eraser.Width;
                    Hbfr.FillEllipse(new SolidBrush(_eraser.Color), e.X - _wd / 2, e.Y - _wd / 2, _wd, _wd);
                }
                DrawBuffer = true;
                Hana.Invalidate();
            }
        }
        private void HanaPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _lockarea = LockArea.None;
            DrawBuffer = false;
            if (_mode == Mode.Pencil){
                using (Graphics Hbmp = Graphics.FromImage(HanaBitmap))
                {
                    //畫線
                    Hbmp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    if (_line.Count > 1) Hbmp.DrawLines(_brush, _line.ToArray());
                    else {
                        int _wd = (int)_brush.Width;
                        Hbmp.FillEllipse(new SolidBrush(_brush.Color), e.X - _wd / 2, e.Y - _wd / 2, _wd, _wd);
                    }
                }
                _line.Clear();
            }
            else if(_mode == Mode.Eraser){
                using (Graphics Hbmp = Graphics.FromImage(HanaBitmap))
                {
                    //畫線
                    Hbmp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    if (_line.Count > 1) Hbmp.DrawLines(_eraser, _line.ToArray());
                    else{
                        int _wd = (int)_eraser.Width;
                        Hbmp.FillEllipse(new SolidBrush(_eraser.Color), e.X - _wd / 2, e.Y - _wd / 2, _wd, _wd);
                    }
                }
                _line.Clear();
            }
        }
        private void HanaPanel_MouseEnter(object sender, EventArgs e)
        {
            switch (_mode){
                case Mode.Pencil: this.Cursor = cursor_Pencil; break;
                case Mode.Eraser: this.Cursor = cursor_Eraser; break;
                case Mode.Blucket: this.Cursor = cursor_Blucket; break;
                case Mode.Picker: this.Cursor = cursor_Picker; break;
                case Mode.None: this.Cursor = Cursors.Default; break;
            }
        }
        private void HanaPanel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void HanaPanel_Paint(object sender, PaintEventArgs e) {
            if (DrawBuffer) e.Graphics.DrawImage(HanaBuffer, 0, 0);
            else e.Graphics.DrawImage(HanaBitmap, 0, 0);
        }
        private unsafe void Blucketio(int _x,int _y) {
            BitmapData HanaBitmap_inMem = HanaBitmap.LockBits(Hana_Rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int _stride = HanaBitmap_inMem.Stride, centerX, centerY;
            byte* HanaPtr = (byte*)HanaBitmap_inMem.Scan0;
            //於指定的_x,_y處填色
            HanaPtr[_y * _stride + _x * 4 + 3] = (byte)_brushColor_A;
            HanaPtr[_y * _stride + _x * 4 + 2] = (byte)_brushColor_R;
            HanaPtr[_y * _stride + _x * 4 + 1] = (byte)_brushColor_G;
            HanaPtr[_y * _stride + _x * 4] = (byte)_brushColor_B;
            //
            wait_For_Check.Enqueue(new Point(_x, _y));
            while (wait_For_Check.Count > 0) {
                centerX = wait_For_Check.Peek().X;
                centerY = wait_For_Check.Peek().Y;
                wait_For_Check.Dequeue();
                foreach(Point _dir in directions){
                    //依序檢查上右下左四個方向
                    _x = centerX + _dir.X;
                    _y = centerY + _dir.Y;
                    HanaPtr = (byte*)HanaBitmap_inMem.Scan0 + _x * 4 + _y * _stride;

                    if ((_x < 0) || (_x >= Hana_Width)) continue;   //超出繪圖範圍
                    if ((_y < 0) || (_y >= Hana_Height)) continue;  //超出繪圖範圍

                    if ((int)*(HanaPtr) == _brushColor_B)
                        if ((int)*(HanaPtr + 1) == _brushColor_G)
                            if ((int)*(HanaPtr + 2) == _brushColor_R)
                                if ((int)*(HanaPtr + 3) == _brushColor_A) continue; //與筆刷顏色相同會造成無窮迴圈,故略過

                    if (((int)*(HanaPtr + 3) < (_targetColor_A - _error)) || ((int)*(HanaPtr+3) > (_targetColor_A + _error))) continue;   //超出欲填滿之顏色的可容許誤差範圍
                    if (((int)*(HanaPtr + 2) < (_targetColor_R - _error)) || ((int)*(HanaPtr+2) > (_targetColor_R + _error))) continue;   //超出欲填滿之顏色的可容許誤差範圍
                    if (((int)*(HanaPtr + 1) < (_targetColor_G - _error)) || ((int)*(HanaPtr+1) > (_targetColor_G + _error))) continue;   //超出欲填滿之顏色的可容許誤差範圍
                    if (((int)*(HanaPtr) < (_targetColor_B - _error)) || ((int)*(HanaPtr) > (_targetColor_B + _error))) continue;   //超出欲填滿之顏色的可容許誤差範圍
                    
                    //於指定的_x,_y處填色
                    *(HanaPtr + 3) = (byte)_brushColor_A;
                    *(HanaPtr + 2) = (byte)_brushColor_R;
                    *(HanaPtr + 1) = (byte)_brushColor_G;
                    *(HanaPtr) = (byte)_brushColor_B;
                    wait_For_Check.Enqueue(new Point(_x, _y));
                }
            }
            HanaBitmap.UnlockBits(HanaBitmap_inMem);
            Hana.Invalidate();
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ColorPool_Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void ColorPool_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _lockarea = LockArea.InPool;

            if ((e.X <= (bm_temp_Size - 1)) && (e.X >= 0)) Poolpoint_Lock_on.X = e.X;
            else if (e.X > (bm_temp_Size - 1)) Poolpoint_Lock_on.X = (int)(bm_temp_Size - 1);
            else Poolpoint_Lock_on.X = 0;
            if ((e.Y <= (bm_temp_Size - 1)) && (e.Y >= 0)) Poolpoint_Lock_on.Y = e.Y;
            else if (e.Y > (bm_temp_Size - 1)) Poolpoint_Lock_on.Y = (int)(bm_temp_Size - 1);
            else Poolpoint_Lock_on.Y = 0;   //更新lock座標

            Draw_SV_Matrix();
            //=======================繪製結束=====================================================
            Color cr_temp = bm_temp.GetPixel(Poolpoint_Lock_on.X, Poolpoint_Lock_on.Y);
            _brush.Color = Color.FromArgb(_brush.Color.A, cr_temp.R, cr_temp.G, cr_temp.B);
            PenColorDisplay.BackColor = _brush.Color;

            Red.Value = _brush.Color.R;
            Green.Value = _brush.Color.G;
            Blue.Value = _brush.Color.B;

            R_val.Text = _brush.Color.R.ToString();
            G_val.Text = _brush.Color.G.ToString();
            B_val.Text = _brush.Color.B.ToString();

            ColorPool.Image = bm_temp;

        }
        private void ColorPool_MouseUp(object sender, MouseEventArgs e)
        {
            _lockarea = LockArea.None;
        }
        private void ColorPool_MouseMove(object sender, MouseEventArgs e)
        {
            if (_lockarea != LockArea.InPool) return;
            if ((e.X <= (bm_temp_Size - 1)) && (e.X >= 0)) Poolpoint_Lock_on.X = e.X;
            else if (e.X > (bm_temp_Size - 1)) Poolpoint_Lock_on.X = (int)(bm_temp_Size - 1);
            else Poolpoint_Lock_on.X = 0;

            if ((e.Y <= (bm_temp_Size - 1)) && (e.Y >= 0)) Poolpoint_Lock_on.Y = e.Y;
            else if (e.Y > (bm_temp_Size - 1)) Poolpoint_Lock_on.Y = (int)(bm_temp_Size - 1);
            else Poolpoint_Lock_on.Y = 0;

            Draw_SV_Matrix();
            //=======================繪製結束=====================================================
            Color cr_temp = bm_temp.GetPixel(Poolpoint_Lock_on.X, Poolpoint_Lock_on.Y);
            _brush.Color = Color.FromArgb(_brush.Color.A, cr_temp.R, cr_temp.G, cr_temp.B);
            PenColorDisplay.BackColor = _brush.Color;

            Red.Value = _brush.Color.R;
            Green.Value = _brush.Color.G;
            Blue.Value = _brush.Color.B;

            R_val.Text = _brush.Color.R.ToString();
            G_val.Text = _brush.Color.G.ToString();
            B_val.Text = _brush.Color.B.ToString();

            ColorPool.Image = bm_temp;
        }
        private void ColorPool_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = cursor_Picker;
        }
        private void ColorPool_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void ColorPool_Paint(object sender, PaintEventArgs e)
        {
            ReverseColor.Color = Color.FromArgb(255, 255 - _brush.Color.R, 255 - _brush.Color.G, 255 - _brush.Color.B);
            e.Graphics.DrawEllipse(ReverseColor, Poolpoint_Lock_on.X - 4, Poolpoint_Lock_on.Y - 4, 8, 8);
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ColorRing_Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void ColorRing_MouseMove(object sender, MouseEventArgs e)
        {
            if (_lockarea != LockArea.InRing) return;
            if (!((e.X == 850) && (e.Y == 116))){
                H = Math.Atan2((double)(116 - e.Y), (double)(e.X - 850));//求出色相的degree
                H = H / Math.PI * 180 - 90;
                if (H < 0) H = H + 360;
            }
            Draw_SV_Matrix();
            //=======================繪製結束=====================================================
            Color cr_temp = bm_temp.GetPixel(Poolpoint_Lock_on.X, Poolpoint_Lock_on.Y);
            _brush.Color = Color.FromArgb(_brush.Color.A, cr_temp.R, cr_temp.G, cr_temp.B);
            PenColorDisplay.BackColor = _brush.Color;

            Red.Value = _brush.Color.R;
            Green.Value = _brush.Color.G;
            Blue.Value = _brush.Color.B;

            R_val.Text = _brush.Color.R.ToString();
            G_val.Text = _brush.Color.G.ToString();
            B_val.Text = _brush.Color.B.ToString();

            ColorRing.Invalidate();

            ColorPool.Image = bm_temp;
        }
        private void ColorRing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Color tempColor = _brush.Color;
            try { tempColor = ColorRingBgImageClone.GetPixel(e.X, e.Y); }
            catch { ;}

            if (tempColor.A != 255) return;
            _lockarea = LockArea.InRing;

            if (!((e.X == 850) && (e.Y == 116))){
                H = Math.Atan2((double)(116 - e.Y), (double)(e.X - 850));//求出色相的degree
                H = H / Math.PI * 180 - 90;
                if (H < 0) H = H + 360;
            }
            Draw_SV_Matrix();
            //=======================繪製結束=====================================================
            Color cr_temp = bm_temp.GetPixel(Poolpoint_Lock_on.X, Poolpoint_Lock_on.Y);
            _brush.Color = Color.FromArgb(_brush.Color.A, cr_temp.R, cr_temp.G, cr_temp.B);
            PenColorDisplay.BackColor = _brush.Color;

            Red.Value = _brush.Color.R;
            Green.Value = _brush.Color.G;
            Blue.Value = _brush.Color.B;

            R_val.Text = _brush.Color.R.ToString();
            G_val.Text = _brush.Color.G.ToString();
            B_val.Text = _brush.Color.B.ToString();

            ColorRing.Invalidate();

            ColorPool.Image = bm_temp;
        }
        private void ColorRing_MouseUp(object sender, MouseEventArgs e)
        {
            _lockarea = LockArea.None;
        }
        private void ColorRing_Paint(object sender, PaintEventArgs e)
        {
            //little_Ring,於對應目前相位的位置在ColorRing上繪製圓環,使用前須Draw_SV_Matrix()來刷新
            Color g_temp_ringcolor = bm_temp.GetPixel((int)bm_temp_Size - 1, 0);
            int target_x = (int)(850 + 95 * Math.Cos((H + 90) / 180 * Math.PI)) - 4;
            int target_y = (int)(116 - 95 * Math.Sin((H + 90) / 180 * Math.PI)) - 4;
            ColorRing_Dot.Color=Color.FromArgb(255, 255 - g_temp_ringcolor.R, 255 - g_temp_ringcolor.G, 255 - g_temp_ringcolor.B);
            e.Graphics.DrawEllipse(ColorRing_Dot, target_x, target_y, 8, 8);
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ARGB_Val_Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void R_val_TextChanged(object sender, EventArgs e)
        {
            if ((_lockarea == LockArea.InPool) || (_lockarea == LockArea.InRing)) return;
            int r_temp = 0;
            if (R_val.Text != ""){
                if (EnterPressed){
                    EnterPressed = false;
                    label1.Focus();
                    return;}
                try{
                    r_temp = int.Parse(R_val.Text);
                    //輸入為數字
                    if (r_temp > 255) { R_val.Text = "255"; return; }
                    else if (r_temp < 0) { R_val.Text = "0"; return; }
                }
                catch { R_val.Text = _brush.Color.R.ToString(); return; }
            }
            //筆刷顏色更改後的相關處理
            _brush.Color = Color.FromArgb(_brush.Color.A, r_temp, _brush.Color.G, _brush.Color.B);
            Red.Value = r_temp;
            PenColorDisplay.BackColor = _brush.Color;

            bool HueChanged = RGB_to_HSV();
            Draw_SV_Matrix();

            if (HueChanged) ColorRing.Invalidate();
            ColorPool.Image = bm_temp;
        }
        private void G_val_TextChanged(object sender, EventArgs e)
        {
            if ((_lockarea == LockArea.InPool) || (_lockarea == LockArea.InRing)) return;
            int g_temp = 0;
            if (G_val.Text != ""){
                if (EnterPressed){
                    EnterPressed = false;
                    label1.Focus();
                    return;
                }
                try{
                    g_temp = int.Parse(G_val.Text);
                    //輸入為數字
                    if (g_temp > 255) { G_val.Text = "255"; return; }
                    else if (g_temp < 0) { G_val.Text = "0"; return; }
                }
                catch { G_val.Text = _brush.Color.G.ToString(); return; }
            }
            //筆刷顏色更改後的相關處理
            _brush.Color = Color.FromArgb(_brush.Color.A, _brush.Color.R, g_temp, _brush.Color.B);
            Green.Value = g_temp;
            PenColorDisplay.BackColor = _brush.Color;
            
            bool HueChanged = RGB_to_HSV();
            Draw_SV_Matrix();

            if (HueChanged) ColorRing.Invalidate();
            ColorPool.Image = bm_temp;    
        }
        private void B_val_TextChanged(object sender, EventArgs e)
        {
            if ((_lockarea == LockArea.InPool) || (_lockarea == LockArea.InRing)) return;
            int b_temp = 0;
            if (B_val.Text != ""){
                if (EnterPressed){
                    EnterPressed = false;
                    label1.Focus();
                    return;
                }
                try{
                    b_temp = int.Parse(B_val.Text);
                    //輸入為數字
                    if (b_temp > 255) { B_val.Text = "255"; return; }
                    else if (b_temp < 0) { B_val.Text = "0"; return; }
                }
                catch { B_val.Text = _brush.Color.B.ToString(); return; }
            }
            //筆刷顏色更改後的相關處理
            _brush.Color = Color.FromArgb(_brush.Color.A, _brush.Color.R, _brush.Color.G, b_temp);
            Blue.Value = b_temp;
            PenColorDisplay.BackColor = _brush.Color;
            RGB_to_HSV();
                
            bool HueChanged = RGB_to_HSV();
            Draw_SV_Matrix();
            
            if (HueChanged) ColorRing.Invalidate();
            ColorPool.Image = bm_temp;
        }
        private void A_val_TextChanged(object sender, EventArgs e)
        {
            int a_temp = 0;
            if (A_val.Text != ""){
                if (EnterPressed){
                    EnterPressed = false;
                    label1.Focus();
                    return;
                }
                try{
                    a_temp = int.Parse(A_val.Text);
                    //輸入為數字
                    if (a_temp > 255) { A_val.Text = "255"; return; }
                    else if (a_temp < 0) { A_val.Text = "0"; return; }
                }
                catch { A_val.Text = _brush.Color.A.ToString(); return; }
            }
            //筆刷顏色更改後的相關處理
            _brush.Color = Color.FromArgb(a_temp, _brush.Color.R, _brush.Color.G, _brush.Color.B); 
            Alpha.Value = a_temp;
            PenColorDisplay.BackColor = _brush.Color;
        }

        private void R_val_Leave(object sender, EventArgs e)
        {
            R_val.Text = _brush.Color.R.ToString();
        }
        private void R_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') EnterPressed = true;
        }
        private void G_val_Leave(object sender, EventArgs e)
        {
            G_val.Text = _brush.Color.G.ToString();
        }
        private void G_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') EnterPressed = true;
        }
        private void B_val_Leave(object sender, EventArgs e)
        {
            B_val.Text = _brush.Color.B.ToString();
        }
        private void B_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') EnterPressed = true;
        }
        private void A_val_Leave(object sender, EventArgs e)
        {
            A_val.Text = _brush.Color.A.ToString();
        }
        private void A_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') EnterPressed = true;
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< TrackBar_Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void Green_Scroll(object sender, EventArgs e)
        {
            G_val.Text = Green.Value.ToString();
        }
        private void Blue_Scroll(object sender, EventArgs e)
        {
            B_val.Text = Blue.Value.ToString();
        }
        private void Alpha_Scroll(object sender, EventArgs e)
        {
            A_val.Text = Alpha.Value.ToString();
        }
        private void Red_Scroll(object sender, EventArgs e)
        {
            R_val.Text = Red.Value.ToString();
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Tool_Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void Pencil_Click(object sender, EventArgs e)
        {
            if (_mode != Mode.Pencil){
                switch (_mode){
                    case Mode.Eraser: Eraser.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Blucket: ; Blucket.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Picker: ; Picker.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                }
                _mode = Mode.Pencil;
                Pencil.BackColor = Pencil.FlatAppearance.MouseDownBackColor;

                int _width = (int)_brush.Width;
                PenWidth.Value = _width;
                PenWidthVal.Text = _width.ToString();
                //筆刷預覽(清空PenPreviewBitmap,繪製筆刷形狀,載入圖片到PenPreview)
                using (Graphics g = Graphics.FromImage(PenPreviewBitmap)){
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(Color.FromArgb(0, 0, 0, 0));
                    g.FillEllipse(PenPreviewSBrush, (28 - _width / 2), (28 - _width / 2), _width, _width);
                }
                PenPreview.Image = PenPreviewBitmap;
                //筆刷預覽
                ErrorRange.Visible = false;
                ErrorRangeLabel1.Visible = false;
                ErrorRangeVal.Visible = false;

                PenWidth.Visible = true;
                PenWidthLabel1.Visible = true;
                PenWidthLabel2.Visible = true;
                PenWidthVal.Visible = true;

                ErrorRange.Enabled = false;
                PenWidth.Enabled = true;
            }
            else {
                _mode = Mode.None;
                Pencil.BackColor = Color.FromArgb(255, 31, 31, 31);
            }
        }
        private void Eraser_Click(object sender, EventArgs e)
        {
            if (_mode != Mode.Eraser)
            {
                switch (_mode)
                {
                    case Mode.Pencil: Pencil.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Blucket: ; Blucket.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Picker: ; Picker.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                }
                _mode = Mode.Eraser;
                Eraser.BackColor = Eraser.FlatAppearance.MouseDownBackColor;

                int _width = (int)_eraser.Width;
                PenWidth.Value = _width;
                PenWidthVal.Text = _width.ToString();
                //筆刷預覽(清空PenPreviewBitmap,繪製筆刷形狀,載入圖片到PenPreview)
                using (Graphics g = Graphics.FromImage(PenPreviewBitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(Color.FromArgb(0, 0, 0, 0));
                    g.FillEllipse(PenPreviewSBrush, (28 - _width / 2), (28 - _width / 2), _width, _width);
                }
                PenPreview.Image = PenPreviewBitmap;
                //筆刷預覽
                ErrorRange.Visible = false;
                ErrorRangeLabel1.Visible = false;
                ErrorRangeVal.Visible = false;

                PenWidth.Visible = true;
                PenWidthLabel1.Visible = true;
                PenWidthLabel2.Visible = true;
                PenWidthVal.Visible = true;

                ErrorRange.Enabled = false;
                PenWidth.Enabled = true;
            }
            else
            {
                _mode = Mode.None;
                Eraser.BackColor = Color.FromArgb(255, 31, 31, 31);
            }
        }
        private void Blucket_Click(object sender, EventArgs e)
        {
            if (_mode != Mode.Blucket)
            {
                switch (_mode)
                {
                    case Mode.Pencil: ; Pencil.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Eraser: Eraser.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Picker: ; Picker.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                }
                _mode = Mode.Blucket;
                Blucket.BackColor = Blucket.FlatAppearance.MouseDownBackColor;

                ErrorRange.Visible = true;
                ErrorRangeLabel1.Visible = true;
                ErrorRangeVal.Visible = true;

                PenWidth.Visible = false;
                PenWidthLabel1.Visible = false;
                PenWidthLabel2.Visible = false;
                PenWidthVal.Visible = false;

                ErrorRange.Enabled = true;
                PenWidth.Enabled = false;
            }
            else
            {
                _mode = Mode.None;
                Blucket.BackColor = Color.FromArgb(255, 31, 31, 31);

                ErrorRange.Visible = false;
                ErrorRangeLabel1.Visible = false;
                ErrorRangeVal.Visible = false;

                PenWidth.Visible = true;
                PenWidthLabel1.Visible = true;
                PenWidthLabel2.Visible = true;
                PenWidthVal.Visible = true;

                ErrorRange.Enabled = false;
                PenWidth.Enabled = true;
            }
        }
        private void Picker_Click(object sender, EventArgs e)
        {
            if (_mode != Mode.Picker)
            {
                switch (_mode)
                {
                    case Mode.Pencil: ; Pencil.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Eraser: Eraser.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                    case Mode.Blucket: ; Blucket.BackColor = Color.FromArgb(255, 31, 31, 31); break;
                }
                _mode = Mode.Picker;
                Picker.BackColor = Picker.FlatAppearance.MouseDownBackColor;
            }
            else
            {
                _mode = Mode.None;
                Picker.BackColor = Color.FromArgb(255, 31, 31, 31);
            }
        }
        private void turna_Click(object sender, EventArgs e)
        {
            Color temp = _brush.Color;
            _brush.Color = _eraser.Color;
            _eraser.Color = temp;

            PenColorDisplay.BackColor = _brush.Color;
            EraserColorDisplay.BackColor = _eraser.Color;

            R_val.Text = _brush.Color.R.ToString();
            G_val.Text = _brush.Color.G.ToString();
            B_val.Text = _brush.Color.B.ToString();
            A_val.Text = _brush.Color.A.ToString();
        }
        private void turna_MouseEnter(object sender, EventArgs e)
        {
            turna.Image = Heaven_s_Door.Properties.Resources.turn_32_;
        }
        private void turna_MouseLeave(object sender, EventArgs e)
        {
            turna.Image = Heaven_s_Door.Properties.Resources.turn_32__gray;
        }
        private void PenWidth_Scroll(object sender, EventArgs e){
            int new_PenWidth = PenWidth.Value;
            PenWidthVal.Text = new_PenWidth.ToString();
            //筆刷預覽(清空PenPreviewBitmap,繪製筆刷形狀,載入圖片到PenPreview)
            using (Graphics g = Graphics.FromImage(PenPreviewBitmap)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.FillEllipse(PenPreviewSBrush, (28 - new_PenWidth / 2), (28 - new_PenWidth / 2), new_PenWidth, new_PenWidth);
            }
            PenPreview.Image = PenPreviewBitmap;
            //筆刷預覽
            switch (_mode) {
                case Mode.Pencil: 
                    _brush.Width = new_PenWidth;
                    using (Graphics gp = Graphics.FromImage(cursor_P_Bitmap)){
                        gp.Clear(Color.FromArgb(0, 0, 0, 0));
                        gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        gp.FillEllipse(CursorBrush, 25 - new_PenWidth / 2, 25 - new_PenWidth / 2, new_PenWidth, new_PenWidth);
                    }
                    cursor_Pencil = new Cursor(cursor_P_Bitmap.GetHicon());
                    break;
                case Mode.Eraser: 
                    _eraser.Width = new_PenWidth;
                    using (Graphics ge = Graphics.FromImage(cursor_E_Bitmap))
                    {
                        ge.Clear(Color.FromArgb(0, 0, 0, 0));
                        ge.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        ge.FillEllipse(CursorBrush, 25 - new_PenWidth / 2, 25 - new_PenWidth / 2, new_PenWidth, new_PenWidth);
                    }
                    cursor_Eraser = new Cursor(cursor_E_Bitmap.GetHicon());
                    break;
            }
        }
        private void ErrorRange_Scroll(object sender, EventArgs e)
        {
            _error = ErrorRange.Value;
            ErrorRangeVal.Text = ErrorRange.Value.ToString();
        }
    } //>>>>>===================== Class Board ========================<<<<<<
    public class HanaPanel:Panel {
       public HanaPanel() {
           DoubleBuffered = true;
           BackColor = Color.White;
           BorderStyle = BorderStyle.FixedSingle;
           Location = new Point(39, 12);
           Size = new Size(688, 410);
       }
    }
}
