using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Final_CG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PopUpVelocidade popUpVelocidade = new PopUpVelocidade();
            Aplicacao aplicacao = new Aplicacao();

            popUpVelocidade.adicionarObservador(aplicacao);

            Application.Run(popUpVelocidade);
            Application.Run(aplicacao);
        }
    }
}
