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

            this.circulos = new Circulo[quantidade_circulos];

            this.circulos[0] = new Circulo(this.centro, 100, caneta, System.Drawing.Color.Azure);
            this.circulos[1] = new Circulo(this.centro, 60, caneta, System.Drawing.Color.Azure);
            this.circulos[2] = new Circulo(this.centro, 30, caneta, System.Drawing.Color.Azure);
            this.circulos[3] = new Circulo(this.centro, 10, caneta, System.Drawing.Color.Azure);
            
        }

        public void draw(Graphics g)
        {
            for (int i = 0; i < quantidade_circulos; i++)
            {
                this.circulos[i].draw(g);
            }//end for
        }
    }
}
