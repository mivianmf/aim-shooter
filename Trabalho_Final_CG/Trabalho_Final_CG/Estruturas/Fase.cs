using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Trabalho_Final_CG.Interfaces;

namespace Trabalho_Final_CG.Estruturas
{
    class Fase : Movimento_Subject
    {
        private int numFase;
        private Desenho desenhoFase;
        private int velocidade;
        private Point pontoCentral;
        private List<Movimento_Observer> observadores;

        public Fase(int numFase, Desenho desenhoFase, int velocidade)
        {
            this.desenhoFase = desenhoFase;
            this.velocidade = velocidade;
            this.numFase = numFase;
            this.observadores = new List<Movimento_Observer>();
        }

        public void iniciar()
        {
            Point[] vertices = this.desenhoFase.getVertices();

            for (int i = 0; i < vertices.Length - 1; i++)
            {
                this.caminharEntreVertices(vertices[i], vertices[i + 1]);
            }//end for
        }

        private void caminharEntreVertices(Point vertice1, Point vertice2)
        {
            this.DDA(vertice1, vertice2);
        }

        //Algoritmo de Bresenham DDA inteiro
        private void DDA(Point p1, Point p2)
        {
            int x, y, erro, deltaX, deltaY;
            erro = 0;
            x = p1.X;
            y = p1.Y;
            deltaX = p2.X - p1.X;
            deltaY = p2.Y - p1.Y;

            if ((Math.Abs(deltaY) >= Math.Abs(deltaX) && p1.Y > p2.Y)
                || (Math.Abs(deltaY) < Math.Abs(deltaX) && deltaY < 0))
            {

                x = p2.X;
                y = p2.Y;
                deltaX = p1.X - p2.X;
                deltaY = p1.Y - p2.Y;
            }
            this.pontoCentral = p1;
            //Notifica as mudanças ao observador para transladar
            this.notificar();
            if (deltaX >= 0)
            {
                if (Math.Abs(deltaX) >= Math.Abs(deltaY))
                {
                    for (int i = 1; i < Math.Abs(deltaX); i++)
                    {
                        if (erro < 0)
                        {
                            x++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaY;
                        }
                        else
                        {
                            x++;
                            y++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaY - deltaX;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < Math.Abs(deltaY); i++)
                    {
                        if (erro < 0)
                        {
                            x++;
                            y++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaY - deltaX;
                        }
                        else
                        {
                            y++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro -= deltaX;
                        }
                    }
                }
            }
            else
            { // deltaX<0
                if (Math.Abs(deltaX) >= Math.Abs(deltaY))
                {
                    for (int i = 1; i < Math.Abs(deltaX); i++)
                    {
                        if (erro < 0)
                        {
                            x--;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaY;
                        }
                        else
                        {
                            x--;
                            y++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaY + deltaX;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < Math.Abs(deltaY); i++)
                    {
                        if (erro < 0)
                        {
                            x--;
                            y++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaY + deltaX;
                        }
                        else
                        {
                            y++;
                            this.pontoCentral = new Point(x, y);
                            //Notifica as mudanças ao observador para transladar
                            this.notificar();
                            erro += deltaX;
                        }
                    }
                }
            }
        }


        public void adicionarObservador(Movimento_Observer observador)
        {
            this.observadores.Add(observador);
        }

        public void removerObservador(Movimento_Observer observador)
        {
            this.observadores.Remove(observador);
        }

        public void notificar()
        {
            foreach (Movimento_Observer observador in this.observadores)
            {
                observador.atualizar(this);
            }
        }

        //Retorna o ponto central
        public Point getPontoCentral()
        {
            return this.pontoCentral;
        }
    }
}
