using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final_CG.Interfaces
{
    public interface Movimento_Subject
    {
        void adicionarObservador(Movimento_Observer observador);
        void notificar();
        void removerObservador(Movimento_Observer observador);
    }
}
