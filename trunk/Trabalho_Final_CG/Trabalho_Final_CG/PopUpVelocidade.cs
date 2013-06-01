using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_Final_CG.Interfaces;

namespace Trabalho_Final_CG
{
    public partial class PopUpVelocidade : Form, Velocidade_Subject 
    {
        private int velocidade;
        private List<Velocidade_Observer> observadores;

        public PopUpVelocidade()
        {
            InitializeComponent();

            this.observadores = new List<Velocidade_Observer>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.velocidade = int.Parse(this.comboVelocidade.Text);
            notificar();
            this.Dispose();
        }

        public int getVelocidade()
        {
            return this.velocidade;
        }
        
        public void adicionarObservador(Velocidade_Observer observador)
        {
            this.observadores.Add(observador);
        }

        public void removerObservador(Velocidade_Observer observador)
        {
            this.observadores.Remove(observador);
        }

        public void notificar()
        {
            foreach(Velocidade_Observer observador in this.observadores)
            {
                observador.atualizar(this);
            }
        }
    }
}
