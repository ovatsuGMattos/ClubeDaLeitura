using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using ClubeDaLeitura.ConsoleApp.Telas;

namespace ClubeDaLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            RepositorioMulta repositorioMulta = new RepositorioMulta();

            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);
            TelaMulta telaMulta = new TelaMulta(repositorioMulta);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Clube da Leitura ===");
                Console.WriteLine("1. Módulo de Amigos");
                Console.WriteLine("2. Módulo de Caixas");
                Console.WriteLine("3. Módulo de Revistas");
                Console.WriteLine("4. Módulo de Empréstimos");
                Console.WriteLine("5. Módulo de Multas");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

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

                    case "4":
                        MenuEmprestimos(telaEmprestimo);
                        break;

                    case "5":
                        MenuMultas(telaMulta);
                        break;

                    case "6":
                        Console.WriteLine("Saindo...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        static void MenuAmigos(TelaAmigo telaAmigo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Amigos ===");
                Console.WriteLine("1. Cadastrar Amigo");
                Console.WriteLine("2. Editar Amigo");
                Console.WriteLine("3. Excluir Amigo");
                Console.WriteLine("4. Visualizar Amigos");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        telaAmigo.Cadastrar();
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
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        static void MenuCaixas(TelaCaixa telaCaixa)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Caixas ===");
                Console.WriteLine("1. Cadastrar Caixa");
                Console.WriteLine("2. Editar Caixa");
                Console.WriteLine("3. Excluir Caixa");
                Console.WriteLine("4. Visualizar Caixas");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        telaCaixa.Cadastrar();
                        break;

                    case "2":
                        telaCaixa.Editar();
                        break;

                    case "3":
                        telaCaixa.Excluir();
                        break;

                    case "4":
                        telaCaixa.Visualizar();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }
        static void MenuRevistas(TelaRevista telaRevista)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Revistas ===");
                Console.WriteLine("1. Cadastrar Revista");
                Console.WriteLine("2. Editar Revista");
                Console.WriteLine("3. Excluir Revista");
                Console.WriteLine("4. Visualizar Revistas");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        telaRevista.Cadastrar();
                        break;

                    case "2":
                        telaRevista.Editar();
                        break;

                    case "3":
                        telaRevista.Excluir();
                        break;

                    case "4":
                        telaRevista.Visualizar();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        static void MenuEmprestimos(TelaEmprestimo telaEmprestimo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Empréstimos ===");
                Console.WriteLine("1. Cadastrar Empréstimo");
                Console.WriteLine("2. Registrar Devolução");
                Console.WriteLine("3. Visualizar Empréstimos");
                Console.WriteLine("4. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        telaEmprestimo.Cadastrar();
                        break;

                    case "2":
                        telaEmprestimo.Excluir();
                        break;

                    case "3":
                        telaEmprestimo.Visualizar();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        static void MenuMultas(TelaMulta telaMulta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Módulo de Multas ===");
                Console.WriteLine("1. Visualizar Todas");
                Console.WriteLine("2. Visualizar Pendentes");
                Console.WriteLine("3. Visualizar Por Amigo");
                Console.WriteLine("4. Quitar Multa");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        telaMulta.VisualizarTodas();
                        break;

                    case "2":
                        telaMulta.VisualizarPendentes();
                        break;

                    case "3":
                        telaMulta.VisualizarPorAmigo();
                        break;

                    case "4":
                        telaMulta.QuitarMulta();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }
    }
}
