using Dicom;
using Dicom.Imaging;
using Dicom.Imaging.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using EvIniFile;
using Dicom.Media;
using System.Globalization;

namespace DicomViewer
{
    public partial class DicomViewer : Form
    {
        private DicomFile _file;
        private DicomImage _image;
        private bool _grayscale;
        private double _windowWidth;
        private double _windowCenter;
        private int _frame = 0;

        private List<DicomIcon> m_IconList = new List<DicomIcon>();
        public DicomViewer()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                AddFile(filename);
            }
            UpdateIcon();
        }

        public void AddFile(string FileName)
        {
            if (!File.Exists(FileName) || !DicomFile.HasValidHeader(FileName)) return;
            DicomFile dcmFile = DicomFile.Open(FileName);

            DicomFile tmpFile = dcmFile.Clone();

            var item = tmpFile.Dataset.Get<DicomItem>(DicomTag.PixelData);
            if (item == null) return;

            DicomImage dcmImage = new DicomImage(tmpFile.Dataset);
            _frame = dcmFile.Dataset.Get(DicomTag.NumberOfFrames, 0);//如果该字段不存在，则默认值为1


           // Image img = dcmImage.RenderImage(0);
           Image img =  ZoomPicture(dcmImage.RenderImage(0), 150, 150);
            img = SetIconInfo(img, _frame, m_IconList.Count);

            DicomIcon icon = new DicomIcon();
            icon.m_Img = img;
            icon.m_FileName = FileName;
            icon.m_DicomFile = dcmFile;
            icon.m_DicomImage = dcmImage;
            m_IconList.Add(icon);



        }

        public void UpdateIcon()
        {
            Thread t = new Thread(new ThreadStart(Fill));

            t.Start();

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DicomFile dcmFile = new DicomFile();
                dcmFile = ((DicomIcon)(e.Item.Tag)).m_DicomFile;
                int frames = dcmFile.Dataset.Get(DicomTag.NumberOfFrames, 0);//如果该字段不存在，则默认值为1
                DicomFile tmpFile = dcmFile.Clone();
                DicomImage dcmSingleImg = new DicomImage(tmpFile.Dataset);
                Image img = dcmSingleImg.RenderImage(0);
                Image process_img = ZoomPicture(img, pictureBox_Display.Width, pictureBox_Display.Height);
                pictureBox_Display.Image = process_img;
                _image = dcmSingleImg;
                dcmFile.Dataset.Get(DicomTag.NumberOfFrames, 0);
                _grayscale = !_image.PhotometricInterpretation.IsColor;
                if (_grayscale)
                {
                    _windowWidth = _image.WindowWidth;
                    _windowCenter = _image.WindowCenter;
                }

                int nRate = GetFrameRate(dcmSingleImg);//设置默认播放速度
                numericUpDown1.Value = nRate;

                ushort group = ushort.Parse("0028", System.Globalization.NumberStyles.HexNumber);
                ushort element = ushort.Parse("0008", System.Globalization.NumberStyles.HexNumber);

                int frame_count = Convert.ToInt16(_image.Dataset.Get<string>(new DicomTag(group, element)));//设置进度条
                trackBar1.Maximum = frame_count;

                StartPlay();//开启播放



            }

            if (radiobtn1.Checked)  //设置标签
            {
                ShowDicomInfo(false);
            }

            else
            {
                ShowDicomInfo(true);
            }

        }


        // 按比例缩放图
        public Image ZoomPicture(Image SourceImage, int TargetWidth, int TargetHeight)
        {
            int IntWidth; //新的图片宽
            int IntHeight; //新的图片高
            try
            {
                System.Drawing.Imaging.ImageFormat format = SourceImage.RawFormat;
                System.Drawing.Bitmap SaveImage = new System.Drawing.Bitmap(TargetWidth, TargetHeight);
                Graphics g = Graphics.FromImage(SaveImage);
                // g.Clear(Color.White);

                if (SourceImage.Width > TargetWidth && SourceImage.Height <= TargetHeight)//宽度比目的图片宽度大，长度比目的图片长度小
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height > TargetHeight)//宽度比目的图片宽度小，长度比目的图片长度大
                {
                    IntHeight = TargetHeight;
                    IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height <= TargetHeight) //长宽比目的图片长宽都小
                {
                    IntHeight = TargetHeight;
                    IntWidth = TargetWidth;
                }
                else//长宽比目的图片的长宽都大
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                    if (IntHeight > TargetHeight)//重新计算
                    {
                        IntHeight = TargetHeight;
                        IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                    }
                }

                g.DrawImage(SourceImage, (TargetWidth - IntWidth) / 2, (TargetHeight - IntHeight) / 2, IntWidth, IntHeight);

                SourceImage.Dispose();

                return SaveImage;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private void DisplayImage(object state)
        {
            var image = (DicomImage)state;
            if (_frame >= _image.NumberOfFrames || _frame < 0) _frame = 0;
            Image img = image.RenderImage(_frame);
            Image process_img = ZoomPicture(img, pictureBox_Display.Width, pictureBox_Display.Height);
            pictureBox_Display.Image = process_img;
            _image = image;

            SetCurrentFrame(_frame);
        }





        private bool _dragging = false;
        private Point _lastPosition = Point.Empty;

        private void pictureBox_Display_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_grayscale)
                return;

            _lastPosition = e.Location;
            _dragging = true;
        }

        private void pictureBox_Display_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void pictureBox_Display_MouseLeave(object sender, EventArgs e)
        {
            _dragging = false;
        }

        private void pictureBox_Display_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging)
                return;

            _image.WindowWidth += e.X - _lastPosition.X;
            _image.WindowCenter += e.Y - _lastPosition.Y;

            _lastPosition = e.Location;

            DisplayImage(_image);
            SetInfo();
        }



        private void ShowDicomInfo(bool b)
        {
            //   Graphics g = pictureBox_Display.CreateGraphics();
            if (_image == null || this.pictureBox_Display.Image == null) return;
            Graphics g = Graphics.FromImage(this.pictureBox_Display.Image);
            g.SmoothingMode = SmoothingMode.HighQuality;

            Font drawFont = new Font("微软雅黑", 12);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            if (b)
            {
                string filename = AppDomain.CurrentDomain.BaseDirectory + "DicomView.config";
                if (!File.Exists(filename)) return;
                string[] arr = { };
                IniFile ini = new IniFile(filename);

                //topleft

                string _strinfo = ini.IniReadValue("TopLeft", "TagInfo").Trim();
                if (_strinfo != string.Empty)
                {

                    char[] _separator = { '|' };
                    arr = _strinfo.Split(_separator);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        char[] item_separator = { ':' };
                        string[] item_arr = arr[i].Split(item_separator);

                        char[] subitem_separator = { ',' };
                        string[] subitem_arr = item_arr[1].Split(subitem_separator);

                        ushort group = ushort.Parse(subitem_arr[0], System.Globalization.NumberStyles.HexNumber);
                        ushort element = ushort.Parse(subitem_arr[1], System.Globalization.NumberStyles.HexNumber);

                        string _info = _image.Dataset.Get<string>(new DicomTag(group, element));

                        string item_text = string.Format("{0}:{1}", item_arr[0], _info);

                        SizeF sizef = g.MeasureString(item_text, drawFont);
                        PointF drawPoint = new PointF(0, sizef.Height * i);
                        g.DrawString(item_text, drawFont, drawBrush, drawPoint);

                    }
                }
                //TopRight
                _strinfo = ini.IniReadValue("TopRight", "TagInfo").Trim();
                if (_strinfo != string.Empty)
                {

                    char[] _separator = { '|' };
                    arr = _strinfo.Split(_separator);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        char[] item_separator = { ':' };
                        string[] item_arr = arr[i].Split(item_separator);

                        char[] subitem_separator = { ',' };
                        string[] subitem_arr = item_arr[1].Split(subitem_separator);

                        ushort group = ushort.Parse(subitem_arr[0], System.Globalization.NumberStyles.HexNumber);
                        ushort element = ushort.Parse(subitem_arr[1], System.Globalization.NumberStyles.HexNumber);

                        string _info = _image.Dataset.Get<string>(new DicomTag(group, element));

                        string item_text = string.Format("{0}:{1}", item_arr[0], _info);

                        SizeF sizef = g.MeasureString(item_text, drawFont);
                        PointF drawPoint = new PointF(pictureBox_Display.Width - sizef.Width, sizef.Height * i);
                        g.DrawString(item_text, drawFont, drawBrush, drawPoint);

                    }
                }
                //BottomLeft
                _strinfo = ini.IniReadValue("BottomLeft", "TagInfo").Trim();
                if (_strinfo != string.Empty)
                {

                    char[] _separator = { '|' };
                    arr = _strinfo.Split(_separator);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        char[] item_separator = { ':' };
                        string[] item_arr = arr[i].Split(item_separator);

                        char[] subitem_separator = { ',' };
                        string[] subitem_arr = item_arr[1].Split(subitem_separator);

                        ushort group = ushort.Parse(subitem_arr[0], System.Globalization.NumberStyles.HexNumber);
                        ushort element = ushort.Parse(subitem_arr[1], System.Globalization.NumberStyles.HexNumber);

                        string _info = _image.Dataset.Get<string>(new DicomTag(group, element));

                        string item_text = string.Format("{0}:{1}", item_arr[0], _info);

                        SizeF sizef = g.MeasureString(item_text, drawFont);
                        PointF drawPoint = new PointF(0, pictureBox_Display.Height - sizef.Height * i - sizef.Height);
                        g.DrawString(item_text, drawFont, drawBrush, drawPoint);

                    }
                }

                //BottomRight
                _strinfo = ini.IniReadValue("BottomRight", "TagInfo").Trim();
                if (_strinfo != string.Empty)
                {

                    char[] _separator = { '|' };
                    arr = _strinfo.Split(_separator);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        char[] item_separator = { ':' };
                        string[] item_arr = arr[i].Split(item_separator);

                        char[] subitem_separator = { ',' };
                        string[] subitem_arr = item_arr[1].Split(subitem_separator);

                        ushort group = ushort.Parse(subitem_arr[0], System.Globalization.NumberStyles.HexNumber);
                        ushort element = ushort.Parse(subitem_arr[1], System.Globalization.NumberStyles.HexNumber);

                        string _info = _image.Dataset.Get<string>(new DicomTag(group, element));

                        string item_text = string.Format("{0}:{1}", item_arr[0], _info);

                        SizeF sizef = g.MeasureString(item_text, drawFont);
                        PointF drawPoint = new PointF(pictureBox_Display.Width - sizef.Width, pictureBox_Display.Height - sizef.Height * i - sizef.Height);
                        g.DrawString(item_text, drawFont, drawBrush, drawPoint);

                    }
                }

            }
            else
            {
                DisplayImage(_image);
            }






        }



        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            if (_image == null) return;
            _frame++;
            if (_frame >= _image.NumberOfFrames || _frame < 0) _frame = 0;
            DisplayImage(_image);
            SetInfo();

        }

        private void pictureBoxPrevious_Click(object sender, EventArgs e)
        {
            if (_image == null) return;
            _frame--;
            if (_frame >= _image.NumberOfFrames || _frame < 0) _frame = 0;
            DisplayImage(_image);
            SetInfo();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetInfo();
        }

        private void radiobtn1_CheckedChanged(object sender, EventArgs e)
        {
            SetInfo();
        }

        private int GetFrameRate(DicomImage dicomImg)
        {
            int nRate = 0;
            ushort group = ushort.Parse("0008", System.Globalization.NumberStyles.HexNumber);
            ushort element = ushort.Parse("2144", System.Globalization.NumberStyles.HexNumber);

            nRate = Convert.ToInt16(dicomImg.Dataset.Get<string>(new DicomTag(group, element)));//Recommended Display Frame Rate
            if (nRate == 0)
            {
                group = ushort.Parse("0018", System.Globalization.NumberStyles.HexNumber);
                element = ushort.Parse("1063", System.Globalization.NumberStyles.HexNumber);
                float nFrameTime = Convert.ToSingle(dicomImg.Dataset.Get<string>(new DicomTag(0018, 1063)));//Frame Time
                if (nFrameTime != 0)
                {
                    nRate = (int)((1000.0 / Convert.ToSingle(nFrameTime)) + 0.5);
                }
                else
                {
                    group = ushort.Parse("0018", System.Globalization.NumberStyles.HexNumber);
                    element = ushort.Parse("0040", System.Globalization.NumberStyles.HexNumber);
                    nRate = Convert.ToInt32(dicomImg.Dataset.Get<string>(new DicomTag(group, element))); //Cine Rate
                    if (nRate == 0)
                    {
                        group = ushort.Parse("0018", System.Globalization.NumberStyles.HexNumber);
                        element = ushort.Parse("0040", System.Globalization.NumberStyles.HexNumber);
                        string sModality = dicomImg.Dataset.Get<string>(new DicomTag(group, element), "");  //Modality

                        if (sModality.Contains("XA") || sModality.Contains("CAG"))
                        {
                            nRate = 15;
                        }
                        else if (sModality.Contains("IVUS") || sModality.Contains("US"))
                        {
                            nRate = 25;
                        }
                        else //默认15
                        {
                            nRate = 15;
                        }

                    }
                }


            }


            return nRate;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_image == null) return;
            _frame++;
            if (_frame >= _image.NumberOfFrames - 1 || _frame < 0) _frame = 0;
            DisplayImage(_image);
            SetInfo();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / (int)numericUpDown1.Value;
        }
        private void StartPlay()
        {
            timer1.Interval = 1000 / (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }

        private void StopPlay()
        {
            timer1.Interval = 1000 / (int)numericUpDown1.Value;
            timer1.Enabled = false;
        }

        private void pictureBoxPlayPause_Click(object sender, EventArgs e)
        {
            StartPlay();
        }

        private void pictureBoxStop_Click(object sender, EventArgs e)
        {
            StopPlay();
        }

        private void SetInfo()
        {
            if (radiobtn1.Checked)
                ShowDicomInfo(false);
            else
                ShowDicomInfo(true);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_frame >= _image.NumberOfFrames - 1 || _frame < 0) _frame = 0;

            _frame = trackBar1.Value - 1 < 0 ? 0 : trackBar1.Value - 1;
            Image img = _image.RenderImage(_frame);
            Image process_img = ZoomPicture(img, pictureBox_Display.Width, pictureBox_Display.Height);
            pictureBox_Display.Image = process_img;
            SetInfo();

        }

        private void SetCurrentFrame(int n)
        {
            trackBar1.Value = n;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {


                var studyDir = new DirectoryInfo(dialog.SelectedPath);
                var dicomDir = new DicomDirectory();

                foreach (var file in studyDir.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    string dicomFile = file.FullName;
                    AddFile(dicomFile);

                }
                UpdateIcon();

            }

        }

        private Form frm = null;
        private Label lb = null;


        void SetLableText(string str)
        {   if(frm==null)  frm = new Form();
            frm.Size = new Size(400, 150);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.BackColor = Color.FromArgb(65, 74, 87);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            if (lb == null) lb = new Label();
            lb.Size = new Size(110, 38);
            lb.Dock = DockStyle.Top;

            Font font = new Font("微软雅黑", 16, FontStyle.Bold);
            lb.ForeColor = Color.FromArgb(172, 179, 191);
            lb.Font = font;
            lb.Text = str;
            lb.Show();
            frm.Controls.Add(lb);

            this.AddOwnedForm(frm);
            frm.Show();
        }

        void LableClose()
        {
            frm.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            SetLableText("测试下");
        }


        private void Fill()
        {
            imageList1.Images.Clear();
            listView1.Clear();

            for (int j = 0; j < m_IconList.Count; j++)
            {
                string sfilename = m_IconList[j].m_FileName;
                try
                {
                    imageList1.Images.Add(m_IconList[j].m_Img);

                    string str = string.Format("正在添加影像队列{0}/{1}", j, m_IconList.Count);
                   // SetLableText(str);

                }
                catch
                {
                    MessageBox.Show("文件：{0} 加载失败！", sfilename);
                    continue;
                }
            }


            listView1.LargeImageList = imageList1;
            //listView1.BeginUpdate();
            for (int i = 0; i < m_IconList.Count; i++)
            {
                ListViewItem lv1 = new ListViewItem();
                lv1.ImageIndex = i;
                lv1.Text = "";
                lv1.Tag = m_IconList[i];
                this.listView1.Items.Add(lv1);

                string str = string.Format("正在显示影像队列{0}/{1}", i, m_IconList.Count);
               // SetLableText(str);
            }
            //listView1.EndUpdate();
        }


        private Image SetIconInfo(Image img, int frame, int nIndex)
        {
            if (img == null) return null;
            Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = SmoothingMode.HighQuality;

            Font drawFont = new Font("微软雅黑", 8);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            string item_text = string.Format("第{0}张/{1}帧", nIndex, frame);

            SizeF sizef = g.MeasureString(item_text, drawFont);
            PointF drawPoint = new PointF(0, 0);
            g.DrawString(item_text, drawFont, drawBrush, drawPoint);

            return img;


        }
    }




    public class DicomIcon
    {
        public Image m_Img;
        public string m_FileName;
        public DicomFile m_DicomFile;
        public DicomImage m_DicomImage;
    }
}
