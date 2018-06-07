using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Steiner
{
    public partial class DrawingForm : Form
    {
        private Pen linePen;
        private Color red;
        private List<Line> lines;
        private int height = 300;
        private int leftMargin = 50;

        public DrawingForm(List<Line> lines)
        {
            InitializeComponent();

            linePen = new Pen(Color.Black, 2);
            this.lines = lines;
            red = Color.FromArgb(255, 0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Line line in lines)
            {
                PointF A = GetPoint(line.A.X, line.A.Y);
                PointF B = GetPoint(line.B.X, line.B.Y);

                if (A.X != B.X && A.Y != B.Y)
                {
                    PointF p;
                    if (A.Y < B.Y)
                        p = new PointF(A.X, B.Y);
                    else
                        p = new PointF(B.X, A.Y);

                    g.DrawLine(linePen, A, p);
                    g.DrawLine(linePen, B, p);
                }
                else
                    g.DrawLine(linePen, A, B);

                DrawPoint(new PointF(A.X - 2, A.Y - 2), g, red);
                DrawPoint(new PointF(B.X - 2, B.Y - 2), g, red);
            }
        }

        private void DrawPoint(PointF point, Graphics g, Color color)
        {
            int x = (int)point.X;
            int y = (int)point.Y;
            Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, new RectangleF(x, y, 5, 5));
        }

        private PointF GetPoint(float x, float y)
        {
            return new PointF(x + leftMargin, height - y);
        }
    }
}
