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
        private Pen caneta;

        public Circulo(System.Drawing.Point centro, int raio, Pen caneta, Color corInterna)
        {
            this.centro = centro;
            this.raio = raio;
            this.caneta = caneta;
            this.cor = corInterna;
        }

        private void plotarCirculo(Graphics g, int x, int y)
        {
            Aplicacao.desenhar(g, caneta, centro.X + x, centro.Y + y);
            Aplicacao.desenhar(g, caneta, centro.X - x, centro.Y + y);

            Aplicacao.desenhar(g, caneta, centro.X + x, centro.Y - y);
            Aplicacao.desenhar(g, caneta, centro.X - x, centro.Y - y);

            Aplicacao.desenhar(g, caneta, centro.X + y, centro.Y + x);
            Aplicacao.desenhar(g, caneta, centro.X - y, centro.Y + x);

            Aplicacao.desenhar(g, caneta, centro.X + y, centro.Y - x);
            Aplicacao.desenhar(g, caneta, centro.X - y, centro.Y - x);
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

        public void setCaneta(Pen caneta)
        {
            this.caneta = caneta;
        }

        public Pen getCaneta()
        {
            return this.caneta;
        }
        
    }//end class
}//end namespace
