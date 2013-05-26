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

        public Circulo(System.Drawing.Point centro, int raio, Pen caneta)
        {
            this.centro = centro;
            this.raio = raio;
            this.caneta = caneta;
            this.cor = caneta.Color;
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
        }

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
                }
                else
                {
                    p = p + 4 * (x - y) + 10;
                    y = y - 1;
                }
                x = x + 1;

                plotarCirculo(g, x, y);
            }

        }
    }
}
