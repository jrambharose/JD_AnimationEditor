using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JD_AnimationEditor
{
    public partial class Form1 : Form
    {
        System.Drawing.Point m_pInitial;
        System.Drawing.Point m_pFinal;

        List<Rectangle> m_rcCollisionRects = new List<Rectangle>();

        Boolean m_bDraw;

        public Form1()
        {
            InitializeComponent();
        }

        private Rectangle getRectangle()
        {
            return new Rectangle(Convert.ToInt32(Math.Min(m_pInitial.X, m_pFinal.X)), Convert.ToInt32(Math.Min(m_pInitial.Y, m_pFinal.Y)),
                                Convert.ToInt32(Math.Abs(m_pInitial.X - m_pFinal.X)), Convert.ToInt32(Math.Abs(m_pInitial.Y - m_pFinal.Y)));
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (m_rcCollisionRects.Count > 0)
            {
                e.Graphics.DrawRectangles(Pens.Black, m_rcCollisionRects.ToArray());
            }
            if (m_bDraw)
            {
                e.Graphics.DrawRectangle(Pens.Red, getRectangle());
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            m_pInitial = m_pFinal = e.Location;
            m_bDraw = true;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            m_pFinal = e.Location;
            if (m_bDraw)
            {
                pictureBox2.Invalidate();
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bDraw)
            {
                m_bDraw = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0)
                {
                    m_rcCollisionRects.Add(rc);
                }
                pictureBox2.Invalidate();
            }
        }
    }
}
