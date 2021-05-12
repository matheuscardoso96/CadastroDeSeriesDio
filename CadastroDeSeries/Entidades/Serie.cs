using CadastroDeSeries.Enums;

namespace CadastroDeSeries.Entidades
{
    public class Serie : Entidade
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public Genero Genero { get; private set; }

        public Serie(int id,string titulo, string descricao, int ano, Genero genero): base(id)
        {
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Genero = genero;
        }

        public override string ToString()
        {
        
            return $"Id:{Id}\r\nTitulo: {Titulo}\r\nDescricao: {Descricao}\r\nAno: {Ano}\r\nGênero {Genero}\r\nAtivo: {Ativo}\r\n";
        }
    }
    
}