using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu;
using Emgu.CV.Structure;
using Multispectral_Image_Integration_Library;
using System.Configuration;

namespace COVID_19_TemperatureScan
{
    public partial class MainForm : Form
    {
        Image<Bgr, byte> imgRgb;
        Image<Bgr, byte> imgTemp;
        Image<Bgr, byte> imgResult;

        string Mode;
        int TempStart;
        int TempFinish;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;

            this.ContextMenuStrip = new ContextMenuStrip();
            var textButton = "Setting";
            this.ContextMenuStrip.Items.Add(textButton, Properties.Resources.Setting,
                                            ContextMenuStripItem_Click);
        }
        private void ContextMenuStripItem_Click(object sender, EventArgs e)
        {
            ///TODO: Refactoring 
            var setting = new SettingForm();
            var dialogResult = setting.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var confCollection = configManager.AppSettings.Settings;

                Mode = confCollection["Mode"].Value;
                TempStart = int.Parse(confCollection["TempStart"].Value);
                TempFinish = int.Parse(confCollection["TempFinish"].Value);
            }
        }
        #region Save and Load Image
        private void pbResult_DoubleClick(object sender, EventArgs e)
        {
            if (pbResult.Image == null)
            {
                return;
            }
            ImageSave(pbResult);
        }

        private void pbRgb_DoubleClick(object sender, EventArgs e)
        {
            imgRgb = ImageLoad(pbRgb);
        }

        private void pbTemp_DoubleClick(object sender, EventArgs e)
        {
           imgTemp = ImageLoad(pbTemp);
        }

        /// <summary>
        /// Сохраняет изображение из PictureBox.
        /// </summary>
        /// <param name="pictureBox">PictureBox</param>
        void ImageSave(PictureBox pictureBox)
        {
            if (pictureBox.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.PNG)|*.PNG|Image Files(*.JPG)|*.JPG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = false;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Загружает изображение в PictureBox.
        /// </summary>
        /// <param name="image">Переменная изображения</param>
        /// <param name="pictureBox">PictureBox</param>
        Image<Bgr, byte> ImageLoad(PictureBox pictureBox)
        {
            //создание диалогового окна "Открыть изображение", для сохранения изображения
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Открыть изображение";
            //отображать ли предупреждение, если пользователь указывает несуществующее название файла
            openDialog.CheckFileExists = true;
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            openDialog.CheckPathExists = true;
            //отображается ли кнопка "Справка" в диалоговом окне
            openDialog.ShowHelp = false;
            //список форматов файла, отображаемый в поле "Тип файла"
            openDialog.Filter = "Image Files(*.PNG)|*.PNG|Image Files(*.JPG)|*.JPG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    //Получаем путь к файлу
                    var path = openDialog.FileName;
                    //Получаем изображение 
                    var img = new Image<Bgr, byte>(path);
                    //Загружаем изображение в PictureBox
                    pictureBox.Image = img.ToBitmap() ;
                    return img;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }
        #endregion
        private void btnStart_Click(object sender, EventArgs e)
        {
            ///TODO: Refactoring 
            var imgGray = imgRgb?.Clone().Convert<Gray, byte>();
            var face = FaceDetect(imgGray);

            var imgFusionMethod = GetFusionMethod(Mode);
            var imgFusion = imgFusionMethod.Fusion(new FastBitmap(imgRgb.ToBitmap()), new FastBitmap(imgTemp.ToBitmap()));
            imgResult = new Image<Bgr, byte>(imgFusion.Bitmap);

            if (imgResult == null)
            {
                return;
            }
            imgResult.Draw(face, new Bgr(179, 143, 247), 3);

            var eyes = EyesDetect(imgGray, face);

            for (int i = 0; i < 2; i++)
            {
                eyes[i].X += face.X;
                eyes[i].Y += face.Y; 
                imgResult.Draw(eyes[i], new Bgr(144, 75, 87), 2);
            }

            var tempSpace = TempSpace(eyes); 
            imgResult.Draw(tempSpace, new Bgr(255, 255, 255), 2);
            var temp = TempCalc(tempSpace, imgTemp.Clone().Convert<Gray, byte>());
            pbResult.Image = imgResult.ToBitmap();
            MessageBox.Show(temp.ToString());
        }

        private Rectangle FaceDetect(Image<Gray, byte> imgGray)
        {
            var pathFaceData = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");
            if (!File.Exists(pathFaceData) || imgGray == null)
            {
                return new Rectangle();
            }

            var faceClassifier = new CascadeClassifier(pathFaceData);
            var faces = faceClassifier.DetectMultiScale(imgGray, 1.1, 4);

            if (faces.Length < 1 || faces[0] == null)
            {
                return new Rectangle();
            }

            return faces[0];
        }
        private Rectangle[] EyesDetect(Image<Gray, byte> imgGray, Rectangle faceRect)
        {
            var pathEyeData = Path.GetFullPath(@"../../data/haarcascade_lefteye_2splits.xml");
            if (!File.Exists(pathEyeData) || imgGray == null || faceRect == null)
            {
                return new Rectangle[2] { new Rectangle(), new Rectangle()};
            }
            imgGray.ROI = faceRect;
            var eyeClassifier = new CascadeClassifier(pathEyeData);
            var eyes = eyeClassifier.DetectMultiScale(imgGray, 1.1, 4);
            if (eyes.Length < 1 || (eyes[0] == null && eyes[1] == null))
            {
                return new Rectangle[2] { new Rectangle(), new Rectangle() };
            }
            if (eyes[1] == null && eyes[0] != null)
            {
                return new Rectangle[2] { eyes[0], new Rectangle() };
            }
            if (eyes[0] == null && eyes[1] != null)
            {
                return new Rectangle[2] { new Rectangle(), eyes[1] };
            }
            if (eyes.Length > 2)
            {
                return new Rectangle[2] { eyes[0], eyes[1] };
            }
            return eyes;
        }
        private Rectangle TempSpace(Rectangle[] eyesRect)
        {
            if (eyesRect.Length < 1 || eyesRect[0] == null)
            {
                return new Rectangle();
            }
            var eye = eyesRect[1];
            var w = eye.Width / 4;
            var h = eye.Height / 4;
            var x = eye.X + eye.Width - w;
            var y = eye.Y + eye.Height - (int)Math.Round(1.7*h);

            return new Rectangle(x, y, w, h);
        }
        private double TempCalc(Rectangle tempSpace, Image<Gray, byte> imgGray)
        {
            int sum = 0;
            int count = 0;
            for (int x = tempSpace.X; x < tempSpace.Width + tempSpace.X; x++)
            {
                for (int y = tempSpace.Y; y < tempSpace.Height + tempSpace.Y; y++)
                {
                    sum += imgGray.Data[x, y, 0];
                    count++;
                }
            }
            return sum / count;
        }
        private IImageFusion GetFusionMethod(string mode)
        {
            if (mode == "Maximum Method")
            {
                return new MaximumMethodFusion();
            }
            if (mode == "Interlacing Method")
            {
                return new InterlacingMethodFusion();
            }
            if (mode == "Interlacing Maximum Method")
            {
                return new InterlacingMaximumMethodFusion();
            }
            return new AveragingMethodFusion();
        }

    }
}
