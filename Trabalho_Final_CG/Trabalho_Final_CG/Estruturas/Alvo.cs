using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Trabalho_Final_CG.Estruturas
{
    class Alvo
    {
        private Circulo[] circulos;
        private Brush pincel;
        private const int quantidade_circulos = 4;
        private Point centro = new Point(350, 600);

        public Alvo()
        {

            Random aleatorio = new Random();

            this.pincel = new SolidBrush(System.Drawing.Color.Black);

            //Define os círculos do alvo
            this.circulos = new Circulo[quantidade_circulos];
            
            //Define cores internas, tamanho, etc.
            
            
        }//end constructor

        public void draw(Graphics g)
        {

            //Desenha os círculos
            this.circulos[0] = new Circulo(this.centro, 95, pincel, Color.Black);
            this.circulos[1] = new Circulo(this.centro, 60, pincel, Color.Blue);
            this.circulos[2] = new Circulo(this.centro, 30, pincel, Color.Red);
            this.circulos[3] = new Circulo(this.centro, 10, pincel, Color.Yellow);
                for (int i = 0; i < quantidade_circulos; i++)
                {
                    //Desenha o círculo
                    this.circulos[i].draw(g);
                    //Colore o alvo de acordo com a cor do círculo
                    colorirAlvo(g, i);
                }//end for
               // Thread.Sleep(1);
        }//end draw


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



        public void translacao(String direcao, int velocidade)
        { 
            switch(direcao)
            {
                case "direita":
                    this.centro.X += velocidade;
                    break;
                case "esquerda":
                    this.centro.X -= velocidade;
                    break;

                case "cima":
                    this.centro.Y -= velocidade;
                    break;
            
                case "baixo":
                    this.centro.Y += velocidade;
                    break;
                
                case "cimaEsquerda":
                    this.centro.X -= velocidade;
                    this.centro.Y -= velocidade;
                    break;

                case "cimaDireita":
                    this.centro.X += velocidade;
                    this.centro.Y -= velocidade;            
                    break;

                case "baixoEsquerda":
                    this.centro.X -= velocidade;
                    this.centro.Y += velocidade;
                    break;

                case "baixoDireita":
                    this.centro.X += velocidade;
                    this.centro.Y += velocidade;
                    break;

            }
        }

    }//end class Alvo

}//end namespace
