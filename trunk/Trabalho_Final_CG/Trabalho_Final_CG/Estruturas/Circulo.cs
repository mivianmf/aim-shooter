using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Trabalho_Final_CG.Estruturas
{
    class Circulo
    {
        //ATRIBUTOS
        private Point centro;
        private int raio;
        private Color cor;
        private Brush pincel;

        public Circulo(System.Drawing.Point centro, int raio, Brush pincel, Color corInterna)
        {
            this.centro = centro;
            this.raio = raio;
            this.pincel = pincel;
            this.cor = corInterna;
        }

        private void plotarCirculo(Graphics g, int x, int y)
        {
            g.FillEllipse(this.pincel, this.centro.X + x - 1, this.centro.Y + y - 1, 2, 2);
            g.FillEllipse(this.pincel, this.centro.X - x - 1, this.centro.Y + y - 1, 2, 2);

            g.FillEllipse(this.pincel, this.centro.X + x - 1, this.centro.Y - y - 1, 2, 2);
            g.FillEllipse(this.pincel, this.centro.X - x - 1, this.centro.Y - y - 1, 2, 2);

            g.FillEllipse(this.pincel, this.centro.X + y - 1, this.centro.Y + x - 1, 2, 2);
            g.FillEllipse(this.pincel, this.centro.X - y - 1, this.centro.Y + x - 1, 2, 2);

            g.FillEllipse(this.pincel, this.centro.X + y - 1, this.centro.Y - x - 1, 2, 2);
            g.FillEllipse(this.pincel, this.centro.X - y - 1, this.centro.Y - x - 1, 2, 2);
        }//end plotarCirculo

        public void draw(Graphics g)
        {
            //BRESENHAN
            int x, y, p;
            x = 0;
            y = this.raio;
            p = 3 - 2 * this.raio;

            plotarCirculo(g, x, y);

            while (x < y)
            {
                if (p < 0)
                {
                    p = p + 4 * x + 6;
                }//end if
                else
                {
                    p = p + 4 * (x - y) + 10;
                    y = y - 1;
                }//end else
                x = x + 1;

                plotarCirculo(g, x, y);
            }//end while

        }//end draw

        //GETTERS AND SETTERS
        public void setCentro(Point centro)
        {
            this.centro = centro;
        }

        public Point getCentro()
        {
            return this.centro;
        }

        public void setRaio(int raio)
        {
            this.raio = raio;
        }

        public int getRaio()
        {
            return this.raio;
        }

        public void setCor(Color cor)
        {
            this.cor = cor;
        }

        public Color getCor()
        {
            return this.cor;
        }

        public void setPincel(Brush pincel)
        {
            this.pincel = pincel;
        }

        public Brush getPincel()
        {
            return this.pincel;
        }
        
    }//end class
}//end namespace
