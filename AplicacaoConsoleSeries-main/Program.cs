using CadastroSeries.Classe;
using CadastroSeries.Interface;
using System;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio Repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao_Usuario = menu();
            while(opcao_Usuario.ToUpper() != "X")
            {
                switch (opcao_Usuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao_Usuario = menu();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
        }

        private static void ListarSerie()
        {
            Console.WriteLine("=================Lista de series================");
            var lista = Repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nnenhuma serie cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.RetornoExcluido();
                Console.WriteLine("ID {0}: - {1} - {2}", serie.RetornoId(), serie.RetornaTitulo(), excluido ? "Excluido" : "Não excluido");
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("=================Inserir serie================");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i ,  Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Selecione um dos generos acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: Repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            Repositorio.Inserir(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Qual o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("=================Atualizar  serie================");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Selecione um dos generos acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaeSerie = new Serie(id: Repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            Repositorio.Atualizar(indiceSerie, atualizaeSerie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Qual o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja mesmo excluir esta serie S/N");
            string respoUsu = Console.ReadLine().ToUpper();

            if(respoUsu == "N")
            {
                return;
            }
            else
            {
                Repositorio.Excluir(indiceSerie);
            }

        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Qual o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = Repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("================Informe a opção desejada==================");

            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir uma nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Exluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;


        }
    }
}
