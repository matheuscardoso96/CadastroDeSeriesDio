namespace CadastroDeSeries.Entidades
{
    public abstract class Entidade 
    {
        public int Id { get; protected set; }
        public bool Ativo { get; protected set; }

        public Entidade(int id)
        {
            Id = id;
            Ativo = true;
        }

        public void InativarOuAtivar(bool situacao)
        {
            Ativo = situacao;

        }
    }
    
}