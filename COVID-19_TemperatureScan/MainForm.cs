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

namespace COVID_19_TemperatureScan
{
    public partial class MainForm : Form
    {
        Image<Bgr, byte> imgRgb;
        Image<Bgr, byte> imgTemp;
        Image<Bgr, byte> imgResult;

        public MainForm()
        {
            InitializeComponent();
        }

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

        private void btnStart_Click(object sender, EventArgs e)
        {
            DetectFace();
        }
        private void DetectFace()
        {
            try
            {
                if (imgRgb == null)
                {
                    return;
                }
                var pathFaceData = Path.GetFullPath(@"../../data/haarcascade_frontalface_default.xml");

                var classifier = new CascadeClassifier(pathFaceData);
                var imgGray = imgRgb.Convert<Gray, byte>().Clone();
                Rectangle[] faces = classifier.DetectMultiScale(imgGray, 1.1, 4);

                imgResult = imgRgb.Clone();
                foreach (var face in faces)
                {
                    imgResult.Draw(face, new Bgr(255, 0, 0), 2);
                }
                pbResult.Image = imgResult.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
