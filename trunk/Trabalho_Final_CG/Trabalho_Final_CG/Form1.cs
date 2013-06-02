﻿using System;
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
    using Trabalho_Final_CG.Interfaces;
    public partial class Aplicacao : Form, Movimento_Observer
    {
        private Brush pincel;
        private Alvo alvo;
        private BackgroundWorker bg_thread;
        private Fase[] fases;
        private int faseAtual;
        private Bitmap imagemFundo = new Bitmap("../../Recursos/madeira.jpg");
        private Point posicaoMouse;
        private long pontuacao;
        private int velocidade;

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
            this.faseAtual = 1;

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            this.WindowState = FormWindowState.Maximized;

            //EVENTOS
            //this.MouseMove += Aplicacao_MouseMove;
            //this.MouseClick += Aplicacao_MouseClick;
            bg_thread.ProgressChanged += new ProgressChangedEventHandler(funciona);
            bg_thread.DoWork += new DoWorkEventHandler(funcionaT);

            //TODO: IMPORTANTE
            this.fases = new Fase[1];
            Desenho estrela = new Desenho(9);
            Point[] pontosEstrela = { new Point(400, 500), new Point (500,370),
                       new Point(655,300), new Point(500,200),
        new Point(400,55), new Point(300,200),
        new Point (135,300), new Point(300,370),
        new Point(400, 500)};
            estrela.setVertices(pontosEstrela);
            this.fases[0] = new Fase(1, estrela, 1);
            this.alvo = new Alvo(this.fases[0].getPontoCentral());
            this.fases[0].adicionarObservador(this.alvo);
            this.fases[0].adicionarObservador(this);
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
            if (this.faseAtual == 1)
            {
                this.fases[0].iniciar();
                this.faseAtual = -1;
            }

        }

        public Point getPosicaoMouse()
        {
            return this.posicaoMouse;
        }//end getPosicaoMouse

        public void atualizar(Movimento_Subject sujeito)
        {
            this.pontuacao += this.alvo.estaDentro(Cursor.Position);
            this.Refresh();
        }//end atualizar
    }//end class
}//end namespace
