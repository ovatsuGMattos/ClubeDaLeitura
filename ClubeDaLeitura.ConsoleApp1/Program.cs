namespace ClubeDaLeitura.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new();
            TelaAmigo telaAmigo = new(repositorioAmigo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Clube da Leitura ====");
                Console.WriteLine("1 - Inserir amigo");
                Console.WriteLine("2 - Editar amigo");
                Console.WriteLine("3 - Excluir amigo");
                Console.WriteLine("4 - Visualizar amigos");
                Console.WriteLine("5 - Visualizar empréstimos do amigo");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine()!;

                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        telaAmigo.Inserir();
                        break;
                    case "2":
                        telaAmigo.Editar();
                        break;
                    case "3":
                        telaAmigo.Excluir();
                        break;
                    case "4":
                        telaAmigo.Visualizar();
                        break;
                    case "5":
                        telaAmigo.VisualizarEmprestimos();
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
        }
    }

}
