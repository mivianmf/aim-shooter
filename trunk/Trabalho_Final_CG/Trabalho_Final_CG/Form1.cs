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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
      
            this.Refresh();
            if (this.cont < 250){
                this.alvo.drawCima(e.Graphics);
                this.cont++;
            }
            if (this.cont>= 250 && cont< 800 ){
                this.alvo.drawDireita(e.Graphics);
                this.cont++;
            }
            if (this.cont >= 800 && cont < 1050)
            {
                this.alvo.drawBaixo(e.Graphics);
                this.cont++;
            }
            if (this.cont >= 1050 && cont < 1600)
            {
                this.alvo.drawEsquerda(e.Graphics);
                this.cont++;
            }
            if (this.cont >= 1600 && cont < 1900)
            {
                this.alvo.drawCimaDireita(e.Graphics);
                this.cont++;
            }
            if (this.cont >= 1900 && cont < 2100)
            {
                this.alvo.drawCimaEsquerda(e.Graphics);
                this.cont++;
            }
            if (this.cont >= 2100 && cont < 2300)
            {
                this.alvo.drawBaixoEsquerda(e.Graphics);
                this.cont++;
            }
            if (this.cont >= 2300 && cont < 2600)
            {
                this.alvo.drawBaixoDireita(e.Graphics);
                this.cont++;
            }




             Console.WriteLine("SAIU");
        
 
        }//end OnPaint


        public static void  mover(){

            
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
