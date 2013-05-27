using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Trabalho_Final_CG.Estruturas
{
    class Alvo
    {
        private Circulo[] circulos;
        private Pen caneta;
        private const int quantidade_circulos = 4;
        private Point centro = new Point(200, 200);

        public Alvo()
        {

            Random aleatorio = new Random();

            this.caneta = new Pen(System.Drawing.Color.Black, 4);

            //Define os círculos do alvo
            this.circulos = new Circulo[quantidade_circulos];
            
            //Define cores internas, tamanho, etc.
            this.circulos[0] = new Circulo(this.centro, 100, caneta, Color.Black);
            this.circulos[1] = new Circulo(this.centro, 60, caneta, Color.Blue);
            this.circulos[2] = new Circulo(this.centro, 30, caneta, Color.Red);
            this.circulos[3] = new Circulo(this.centro, 10, caneta, Color.Yellow);
            
        }//end constructor

        public void draw(Graphics g)
        {
            //Desenha os círculos
            for (int i = 0; i < quantidade_circulos; i++)
            {
                //Desenha o círculo
                this.circulos[i].draw(g);
                
                //Colore o alvo de acordo com a cor do círculo
                colorirAlvo(g, this.circulos[i].getCor());
            }//end for
            
            
        }

        private void colorirAlvo(Graphics g, Color cor)
        {
            //FLOOD FILL


        }//end draw

        private static bool ColorMatch(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        static void FloodFill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(pt);
            while (q.Count > 0)
            {
                Point n = q.Dequeue();
                if (!ColorMatch(bmp.GetPixel(n.X, n.Y), targetColor))
                    continue;
                Point w = n, e = new Point(n.X + 1, n.Y);
                while ((w.X > 0) && ColorMatch(bmp.GetPixel(w.X, w.Y), targetColor))
                {
                    bmp.SetPixel(w.X, w.Y, replacementColor);
                    if ((w.Y > 0) && ColorMatch(bmp.GetPixel(w.X, w.Y - 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y - 1));
                    if ((w.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(w.X, w.Y + 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y + 1));
                    w.X--;
                }
                while ((e.X < bmp.Width - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y), targetColor))
                {
                    bmp.SetPixel(e.X, e.Y, replacementColor);
                    if ((e.Y > 0) && ColorMatch(bmp.GetPixel(e.X, e.Y - 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y - 1));
                    if ((e.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y + 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y + 1));
                    e.X++;
                }
            }
        }
    }//end class Alvo


}//end namespace
