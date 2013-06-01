using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Trabalho_Final_CG
{
    using Trabalho_Final_CG.Estruturas;
    public partial class Aplicacao : Form
    {
        private Brush pincel;
        private Alvo alvo;
        private BackgroundWorker bg_thread;
        private int cont = 0;
        private Bitmap imagemFundo = new Bitmap("C:/Users/Mí/Documents/Visual Studio 2012/Projects/Trabalho_Final_CG/Trabalho_Final_CG/Trabalho_Final_CG/Properties/madeira.jpg");

        public Aplicacao()
        {
            InitializeComponent();
            
            
            //BACKGROUND COLOR
            this.BackColor = System.Drawing.Color.White;

            //BACKGROUND THREAD
            bg_thread = new BackgroundWorker();

            this.bg_thread.RunWorkerAsync();
            bg_thread.WorkerReportsProgress = true;

            //ATRIBUTOS
            this.pincel = new SolidBrush(System.Drawing.Color.Black);
            
            this.alvo = new Alvo();

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            this.WindowState = FormWindowState.Maximized;

            //EVENTOS
            this.MouseMove += Aplicacao_MouseMove;
            this.MouseClick += Aplicacao_MouseClick;
            bg_thread.ProgressChanged += new ProgressChangedEventHandler(funciona);
            bg_thread.DoWork += new DoWorkEventHandler(funcionaT);
        }

        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
           
        }
        

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(imagemFundo, 0, 0, this.Width, this.Height);
            this.alvo.draw(e.Graphics);
        }//end OnPaint




        private void funcionaT(object obj, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)obj;

            for (; ;) 
            {
                System.Threading.Thread.Sleep(40);
                worker.ReportProgress(0);
            }
        }

        private void funciona(object obj, ProgressChangedEventArgs e)
        {
            mover();
            this.Refresh();

        }

        public void  mover(){

            if (cont < 100) 
            {
                this.alvo.translacao("direita", 2);
            }
            if (cont >=100 && cont < 150 )
            {
                this.alvo.translacao("cima",2);
            }


       }

        public static void desenhar(Graphics g, Brush pincel, int x, int y)
        {
            
            g.FillEllipse(pincel, x, y, 2, 2);

        }//end desenhar

        private void Aplicacao_MouseMove(object sender, MouseEventArgs args)
        {
            
        }//end mouseMove

        private void Aplicacao_MouseClick(object sender, MouseEventArgs args)
        {

        }//end mouseClick
    }
}
