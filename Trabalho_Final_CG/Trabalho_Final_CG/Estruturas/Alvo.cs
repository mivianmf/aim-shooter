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
        private Point centro = new Point(100, 100);

        public Alvo()
        {

            Random aleatorio = new Random();

            this.pincel = new SolidBrush(System.Drawing.Color.Black);

            //Define os círculos do alvo
            this.circulos = new Circulo[quantidade_circulos];
            
            //Define cores internas, tamanho, etc.
            
            
        }//end constructor

        public void drawDireita(Graphics g)
        {
            //Desenha os círculos
            this.circulos[0] = new Circulo(this.centro, 100, pincel, Color.Black);
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

                this.translacaoDireita();
                //Thread.Sleep(3);
        }//end draw

        public void drawBaixo(Graphics g)
        {
            //Desenha os círculos
            this.circulos[0] = new Circulo(this.centro, 100, pincel, Color.Black);
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

            this.translacaoBaixo();
           // Thread.Sleep(3);
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

        public  void translacaoDireita()
        {
            //movimento para direita
            this.centro.X += 1;
        }

        public void translacaoEsquerda(){
            //movimento para esquerda
            this.centro.X -= 1;
        }

        public void translacaoCima(){
            //movimento para cima 
            this.centro.Y += 1;
        }

        public void translacaoBaixo(){
            //movimento para baixo
            this.centro.Y -= 1;
        }

        public void translacaoBaixoDireita(){
            //movimento para cima e para direita
            this.centro.X += 1;
            this.centro.Y += 1;
        }

        public void translacaoCimaDireita(){
            //movimento para baixo e para direita
            this.centro.X += 1;
            this.centro.Y -= 1;
        }

        public void translacaoBaixoEsquerda(){
            //movimento para cima e para esquerda
            this.centro.X -= 1;
            this.centro.Y += 1;
        }

        public void translacaoCimaEsquerda(){
            //movimento para baixo e para esquerda
            this.centro.X -= 1;
            this.centro.Y -= 1;
        }
    }//end class Alvo

}//end namespace
