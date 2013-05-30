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

            //EVENTOS
            this.MouseMove += Aplicacao_MouseMove;
            this.MouseClick += Aplicacao_MouseClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int cont = 0;
             while(cont < 5){
                this.alvo.drawDireita(e.Graphics);
                this.Refresh();
                cont++;
             }

             cont = 0;
             while (cont < 5)
             {
                 this.alvo.drawBaixo(e.Graphics);
                 this.Refresh();
                 this.
                 cont++;
             }


             Console.WriteLine("SAIU");
             Environment.Exit(0);
 
        }//end OnPaint

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
