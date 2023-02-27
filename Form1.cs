using System.Drawing.Imaging;

namespace trabajoClase
{
    public partial class Form1 : Form
    {
        Graphics papel;
        int anchoPluma = 3;
        int x = 0; int y = 0;
        bool moving;
        Pen pen;
        byte r = 0;
        byte g = 0;
        byte b = 0;
        public Form1()
        {
            InitializeComponent();
            papel = pictureBoxPapel.CreateGraphics();
            pen = new Pen(Color.Black, anchoPluma);
            // Cuando se dibuje en el picture box se suavice el trazo
            papel.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void txtPapel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void txtPapel_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                cambiarValoresPluma();
                papel.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X; y = e.Y;
            }
        }

        private void txtPapel_MouseUp(object sender, MouseEventArgs e)
        {
            moving= false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            anchoPluma = trackBar1.Value;
        }

        private void cambiarValoresPluma()
        {
            pen = new Pen(Color.Black, anchoPluma);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            pictureBoxPapel.Image.Save(@"C:\Users\judit\Desktop\Graficación", ImageFormat.Jpeg);
        }
    }
}