using System;
using CadastroDeSeries.Entidades;
using CadastroDeSeries.Enums;
using CadastroDeSeries.Interfaces;
using CadastroDeSeries.Repositorio;
using System.Globalization;

namespace CadastroDeSeries
{
    class Program
    {
        private static IRepositorio<Serie> _serieRepositorio = new SerieRepositorio();
        static void Main(string[] args)
        {


          string opcaoEscolhida = "";

            while(opcaoEscolhida != "S")
            {
                opcaoEscolhida = ObtenhaOpcao();
                switch(opcaoEscolhida)
                {
                    case "1" :
                    ListarSeries();
                     break;
                    case "2" :
                    InserirNovaSerie();
                     break;
                    case "3" :
                    AtualizarSerie();
                     break;
                    case "4" :
                    ExcluirSerie();
                     break;
                    case "5" :
                    VisualizarSerie();
                     break;
                    case "C" :
                    Console.Clear();
                     break;
                    case "S" :
                    Console.Clear();
                     break;
                    default:
                    Console.WriteLine("Argumento inválido.");
                    break;
                }
                Console.WriteLine("Operação efetuada.");
                Console.WriteLine("Aperte enter para continua");
                Console.ReadLine();

                
            }
        }

          private static string ObtenhaOpcao()
        {
            Console.WriteLine("Bem-vindo ao sistema de cadastro de series.\nInforme a opção:\n");
            Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("S- Sair");
            Console.WriteLine();
            return Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Todas as séries cadastradas:");
            var lista = _serieRepositorio.Listar();

            if(lista.Count == 0)
            {
               Console.WriteLine("Nenhuma serie cadastrada");
               return;
            }
            
            
            foreach(var serie in lista)
            {
                Console.WriteLine(serie);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void InserirNovaSerie()
        {
            Console.WriteLine("Inserir série");
            Serie serie = GerarNovoRegistroDeSerie();
            _serieRepositorio.Inserir(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");
            Console.Write("Id da série: ");
            int id = int.Parse(Console.ReadLine());
            Serie serie = GerarNovoRegistroDeSerie();
            _serieRepositorio.Atualizar(id,serie);
        }

        private static Serie GerarNovoRegistroDeSerie()
        {
            ListaGeneros();
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Descricao: ");
            string descricao = Console.ReadLine();
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Código do gênero: ");
            Genero genero = Enum.Parse<Genero>(Console.ReadLine());
            Serie serie = new Serie(_serieRepositorio.ProximoId(),titulo, descricao, ano, genero);
            return serie;
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série");
            Console.Write("Id da série: ");
            int id = int.Parse(Console.ReadLine());
            _serieRepositorio.Excluir(id);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");
            Console.Write("Id da série: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(_serieRepositorio.ObterPorId(id).ToString());
        }

        private static void ListaGeneros()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"Código: {i} Gênero: {Enum.GetName(typeof(Genero), i)}");
            }
        }
      
    }
}
