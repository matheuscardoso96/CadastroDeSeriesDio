using CadastroDeSeries.Entidades;
using System.Collections.Generic;

namespace CadastroDeSeries.Interfaces
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Inserir(T entidade);
        void Atualizar(int indice,T entidade);
        void Excluir(int id);
        IReadOnlyCollection<T> Listar();
        T ObterPorId(int id);
        int ProximoId();

    }
    
}