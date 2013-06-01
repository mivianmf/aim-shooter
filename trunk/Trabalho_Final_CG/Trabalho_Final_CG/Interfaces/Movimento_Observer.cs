using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final_CG.Interfaces
{
    interface Movimento_Observer
    {
        void atualizar(Movimento_Subject sujeito);
    }
}
