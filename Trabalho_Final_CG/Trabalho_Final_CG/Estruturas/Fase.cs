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
            this.pontoCentral = desenhoFase.getVertices()[0];
        }

        public void iniciar()
        {
            Point[] vertices = this.desenhoFase.getVertices();

            for (int i = 0; i < vertices.Length - 1; i++)
            {
                this.caminharEntreVertices(vertices[i], vertices[i + 1]);
            }//end for
            //Caminha do último até o primeiro
            //this.caminharEntreVertices(vertices[vertices.Length - 1], vertices[0]);
        }

        private void caminharEntreVertices(Point vertice1, Point vertice2)
        {
            this.DDA(vertice1, vertice2);
        }

        /*
     

        public void bresenhamReta (Point p1, Point p2)
        {
	        int dx, dy, x, y ,const1, const2, p;
	        int incrX= 0;
	        int incrY = 0;
	
	        dx = Math.Abs(p2.X - p1.X);
	        dy = Math.Abs(p2.X - p1.Y);
	
	        if (dx >= 0)
		        incrX = this.velocidade;
	        else
	        {
		        incrX = ((-1)*this.velocidade);
		        dx = ((-1)*dx);
	        }
	        if (dy>=0)
		        incrY = this.velocidade;
	        else
	        {
		        incrY = ((-1)*this.velocidade);
		        dy = ((-1)*dy);
	        }
	
	        x = p1.X;
	        y = p1.Y;
	        this.pontoCentral = new Point (x,y);
	        this.notificar();
	
	        if (dy < dx)
	        {
		        p = 2*(dy-dx);
		        const1 = 2*dy;
		        const2= 2*(dy-dx);
		
		        for (int i =0; i < dx; i++)
		        {
			        x+= incrX;
			
			        if (p<0)
			        {
				        p+= const1;
			        }
			        else
			        {
				        y += incrY;
				        p+= const2;
			        }
			        this.pontoCentral = new Point (x,y);
			        this.notificar();
		        }
	
	        }
	        else
	        {
		        p=2*dx-dy;
		        const1 = 2*dx;
		        const2 = 2*(dx-dy);
		
		        for(int j = 0; j < dy; j++)
		        {
			        y+= incrY;
			        if (p<0)
			        {
				        p+=const1;
			        }
			        else
			        {
				        x+= incrX;
				        p+= const2;
			        }
			        this.pontoCentral = new Point (x,y);
			        this.notificar();
		        }
	        }
        }
        */
        
        

        //Algoritmo de Bresenham DDA inteiro
        private void DDA(Point p1, Point p2)
        {
            int x, y, erro, deltaX, deltaY;
            erro = 0;
            x = p1.X;
            y = p1.Y;
            deltaX = p2.X - p1.X;
            deltaY = p2.Y - p1.Y;

            this.pontoCentral = p1;
            //Notifica as mudanças ao observador para transladar
            this.notificar();

            if ((Math.Abs(deltaY) >= Math.Abs(deltaX) && p1.Y > p2.Y)
                || (Math.Abs(deltaY) < Math.Abs(deltaX) && deltaY < 0))
            {
                /*x = p2.X;
                y = p2.Y;*/

                deltaX = p1.X - p2.X;
                deltaY = p1.Y - p2.Y;
                if (deltaX >= 0)
                {
                    if (Math.Abs(deltaX) >= Math.Abs(deltaY))
                    {
                        for (int i = 1; i < Math.Abs(deltaX) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += deltaY*this.velocidade;
                            }
                            else
                            {
                                x+=this.velocidade;
                                y-=this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY - deltaX)*this.velocidade;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < Math.Abs(deltaY) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x += this.velocidade;
                                y -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY - deltaX)*this.velocidade;
                            }
                            else
                            {
                                y -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro -= deltaX*this.velocidade;
                            }
                        }
                    }
                }
                else
                { // deltaX<0
                    if (Math.Abs(deltaX) >= Math.Abs(deltaY))
                    {
                        for (int i = 1; i < Math.Abs(deltaX) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += deltaY*this.velocidade;
                            }
                            else
                            {
                                x -= this.velocidade;
                                y -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY + deltaX)*this.velocidade;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < Math.Abs(deltaY) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x -= this.velocidade;
                                y -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY + deltaX)*this.velocidade;
                            }
                            else
                            {
                                y -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += deltaX*this.velocidade;
                            }//end else
                        }//end for
                    }//end else
                }//end else
            }
            else
            {
                if (deltaX >= 0)
                {
                    if (Math.Abs(deltaX) >= Math.Abs(deltaY))
                    {
                        for (int i = 1; i < Math.Abs(deltaX) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += deltaY*this.velocidade;
                            }
                            else
                            {
                                x += this.velocidade;
                                y += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY - deltaX)*this.velocidade;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < Math.Abs(deltaY) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x += this.velocidade;
                                y += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY - deltaX)*this.velocidade;
                            }
                            else
                            {
                                y += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro -= deltaX*this.velocidade;
                            }
                        }
                    }
                }
                else
                { // deltaX<0
                    if (Math.Abs(deltaX) >= Math.Abs(deltaY))
                    {
                        for (int i = 1; i < Math.Abs(deltaX) / this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x -= this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += deltaY*this.velocidade;
                            }
                            else
                            {
                                x -= this.velocidade;
                                y += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY + deltaX)*this.velocidade;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < Math.Abs(deltaY)/this.velocidade; i++)
                        {
                            if (erro < 0)
                            {
                                x -= this.velocidade;
                                y += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += (deltaY + deltaX)*this.velocidade;
                            }
                            else
                            {
                                y += this.velocidade;
                                this.pontoCentral = new Point(x, y);
                                //Notifica as mudanças ao observador para transladar
                                this.notificar();
                                erro += deltaX*this.velocidade;
                            }//end else
                        }//end for
                    }//end else
                }//end else
            }//end else
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
