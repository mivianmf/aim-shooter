using System;
namespace Trabalho_Final_CG.Interfaces
{
    public interface Velocidade_Subject
    {
        void adicionarObservador(Velocidade_Observer observador);
        void notificar();
        void removerObservador(Velocidade_Observer observador);
    }
}
