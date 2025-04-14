
using ClubeDaLeitura.ConsoleApp1.ModuloRevista;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevista;

internal class Program
{
    private static void Main(string[] args)
    {
        RepositorioRevista repositorioRevista = new();
        TelaRevista telaRevista = new(repositorioRevista, repositorioCaixa);
        RepositorioCaixa repositorioCaixa = new();
        TelaCaixa telaCaixa = new(repositorioCaixa);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Clube da Leitura ====");
            Console.WriteLine("1 - Módulo de Amigos");
            Console.WriteLine("2 - Módulo de Caixas");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine()!;
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    MenuAmigos(telaAmigo);
                    break;
                case "2":
                    MenuCaixas(telaCaixa);
                    break;
                case "3":
                    MenuRevistas(telaRevista);
                    break;

                case "0":
                    Console.WriteLine("Encerrando o programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void MenuAmigos(TelaAmigo telaAmigo)
        {
            Console.WriteLine("== Módulo de Amigos ==");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar");
            Console.WriteLine("5 - Ver empréstimos do amigo");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine()!;

            Console.Clear();
            switch (opcao)
            {
                case "1": telaAmigo.Inserir(); break;
                case "2": telaAmigo.Editar(); break;
                case "3": telaAmigo.Excluir(); break;
                case "4": telaAmigo.Visualizar(); break;
                case "5": telaAmigo.VisualizarEmprestimos(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }

        static void MenuCaixas(TelaCaixa telaCaixa)
        {
            Console.WriteLine("== Módulo de Caixas ==");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine()!;

            Console.Clear();
            switch (opcao)
            {
                case "1": telaCaixa.Inserir(); break;
                case "2": telaCaixa.Editar(); break;
                case "3": telaCaixa.Excluir(); break;
                case "4": telaCaixa.Visualizar(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
        static void MenuRevistas(TelaRevista telaRevista)
        {
            Console.WriteLine("== Módulo de Revistas ==");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine()!;

            Console.Clear();
            switch (opcao)
            {
                case "1": telaRevista.Inserir(); break;
                case "2": telaRevista.Editar(); break;
                case "3": telaRevista.Excluir(); break;
                case "4": telaRevista.Visualizar(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
    }
}