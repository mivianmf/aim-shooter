using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Trabalho_Final_CG.Estruturas
{
    class Desenho
    {
        private Point[] vertices;

        public Desenho(){}

        public Desenho(int numVertices)
        {
            this.vertices = new Point[numVertices];
        }

        public Point[] getVertices()
        {
            return this.vertices;
        }

        public void setVertices(Point[] vertices)
        {
            this.vertices = vertices;
        }
    }
}
