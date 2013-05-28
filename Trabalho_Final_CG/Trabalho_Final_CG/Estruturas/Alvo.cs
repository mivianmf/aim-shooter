﻿using System;
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
                colorirAlvo(g, i);
            }//end for
            
            
        }

        private void colorirAlvo(Graphics g, int id_circulo)
        {
            //Pega o raio da cirunferência atual
            int raioAtual = this.circulos[id_circulo].getRaio();

            //Declara o pincel de pintura 
            Brush pincel = new SolidBrush(this.circulos[id_circulo].getCor());

            //Preenche os círculos
            g.FillEllipse(pincel,
                this.centro.X - raioAtual, this.centro.Y - raioAtual,
                raioAtual * 2, raioAtual * 2);
        }//end draw
               
    }//end class Alvo


}//end namespace