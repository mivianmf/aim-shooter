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
        private int fase = 1;
        private Bitmap imagemFundo = new Bitmap("../../Recursos/madeira.jpg");
        private Point posicaoMouse;
        private long pontuacao;

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

            this.pontuacao = 0L;

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
            e.Graphics.DrawString(this.pontuacao.ToString(),
                new Font(FontFamily.GenericSansSerif, 50),
                this.pincel, 100, 100);
        }//end OnPaint

        private void funcionaT(object obj, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)obj;

            for (; ; )
            {
                System.Threading.Thread.Sleep(40);
                worker.ReportProgress(0);
            }
        }

        private void funciona(object obj, ProgressChangedEventArgs e)
        {
            this.pontuacao += this.alvo.estaDentro(this.posicaoMouse);
            if (this.fase == 1)
            {
                movimentoFase1();
            }
            this.Refresh();


        }

        public void mover()
        {

            if (this.fase == 1)
            {
                movimentoFase1();
            }

        }


        public void movimentoFase1()
        {
            if (cont < 500)
            {
                this.alvo.translacao("direita", 1);
                this.cont++;
            }
            if (cont >= 500 && cont < 700)
            {
                this.alvo.translacao("cima", 1);
                this.cont++;
            }
            if (cont >= 700 && cont < 1200)
            {
                this.alvo.translacao("esquerda", 1);
                this.cont++;
            }
            if (cont >= 1200 && cont < 1400)
            {
                this.alvo.translacao("baixo", 1);
                this.cont++;
            }
            if (cont >= 1400 && cont < 1838)
            {
                this.alvo.translacao("cimaDireita", 1);
                this.cont++;
            }
            if (cont >= 1838 && cont < 2306)
            {
                this.alvo.translacao("baixoDireita", 1);
                this.cont++;
            }
        }

        public static void desenhar(Graphics g, Brush pincel, int x, int y)
        {

            g.FillEllipse(pincel, x, y, 2, 2);

        }//end desenhar

        private void Aplicacao_MouseClick(object sender, MouseEventArgs args)
        {

        }//end mouseClick

        private void Aplicacao_MouseMove(object sender, MouseEventArgs args)
        {
            this.posicaoMouse.X = args.X;
            this.posicaoMouse.Y = args.Y;

            //Console.WriteLine("Circulo = " + this.alvo.estaDentro(this.posicaoMouse));
            
            //Console.Write("X = " + args.X);
            //Console.WriteLine(" Y = " + args.Y);
        }//end mouseMove

        public Point getPosicaoMouse()
        {
            return this.posicaoMouse;
        }//end getPosicaoMouse

    }
}
