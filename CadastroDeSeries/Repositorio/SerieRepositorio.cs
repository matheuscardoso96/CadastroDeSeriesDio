using CadastroDeSeries.Interfaces;
using CadastroDeSeries.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeSeries.Repositorio
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private IList<Serie> _series;
        public SerieRepositorio()
        {
            _series = new List<Serie>();
        }
        public void Inserir(Serie serie)
        {
            _series.Add(serie);
        }
        public void Atualizar(int id, Serie serie)
        {
            _series[id] = serie;
        }

        public void Excluir(int id)
        {
            _series.FirstOrDefault(x => x.Id == id).InativarOuAtivar(false);
        }       

        public IReadOnlyCollection<Serie> Listar()
        {
            return _series.ToArray();
        }

        public Serie ObterPorId(int id)
        {
            return _series.FirstOrDefault(x => x.Id == id);
        }

        public int ProximoId()
        {
            return _series.Count;
        }
    }

}