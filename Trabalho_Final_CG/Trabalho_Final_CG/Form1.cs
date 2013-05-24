using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Final_CG
{
    using Trabalho_Final_CG.Estruturas;
    public partial class Aplicacao : Form
    {
        private Pen caneta;
        //private Circulo[] circulos;
        private Alvo alvo;
        private BackgroundWorker bg_thread;
        private int quantidade_circulos;

        public Aplicacao()
        {
            int x_aleat, y_aleat;

            InitializeComponent();

            //BACKGROUND COLOR
            this.BackColor = System.Drawing.Color.White;

            //BACKGROUND THREAD
            bg_thread = new BackgroundWorker();

            this.bg_thread.RunWorkerAsync();
            bg_thread.WorkerReportsProgress = true;

            //ATRIBUTOS
            this.caneta = new Pen(System.Drawing.Color.Black, 4);
            
            this.alvo = new Alvo();
                       
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            //EVENTOS
            this.MouseMove += Aplicacao_MouseMove;
            this.MouseClick += Aplicacao_MouseClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.alvo.draw(e.Graphics);
        }//end OnPaint

        public static void desenhar(Graphics g, Pen caneta, int x, int y)
        {
            g.DrawLine(caneta, new Point(x,y), new Point(x + 1, y + 1));
        }//end desenhar

        private void Aplicacao_MouseMove(object sender, MouseEventArgs args)
        {
            
        }//end mouseMove

        private void Aplicacao_MouseClick(object sender, MouseEventArgs args)
        {

        }//end mouseClick
    }
}
