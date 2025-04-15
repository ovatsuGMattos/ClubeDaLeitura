using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaMulta
    {
        private RepositorioMulta repositorioMulta;

        public TelaMulta(RepositorioMulta repositorioMulta)
        {
            this.repositorioMulta = repositorioMulta;
        }

        public void VisualizarTodas()
        {
            Console.Clear();
            Console.WriteLine("=== Multas Cadastradas ===");

            var multas = repositorioMulta.Listar();

            if (multas.Count == 0)
            {
                Console.WriteLine("Nenhuma multa encontrada.");
            }
            else
            {
                foreach (var m in multas)
                {
                    ExibirMulta(m);
                }
            }

            Console.ReadLine();
        }

        public void VisualizarPendentes()
        {
            Console.Clear();
            Console.WriteLine("=== Multas Pendentes ===");

            var multas = repositorioMulta.ListarPendentes();

            if (multas.Count == 0)
            {
                Console.WriteLine("Nenhuma multa pendente.");
            }
            else
            {
                foreach (var m in multas)
                {
                    ExibirMulta(m);
                }
            }

            Console.ReadLine();
        }
        public void VisualizarPorAmigo()
        {
            Console.Clear();
            Console.WriteLine("=== Multas de um Amigo ===");

            Console.Write("Digite o nome do amigo: ");
            string nomeAmigo = Console.ReadLine()!;

            var multas = repositorioMulta.BuscarPorAmigo(nomeAmigo);

            if (multas.Count == 0)
            {
                Console.WriteLine("Nenhuma multa encontrada para este amigo.");
            }
            else
            {
                foreach (var m in multas)
                {
                    ExibirMulta(m);
                }
            }

            Console.ReadLine();
        }

        public void QuitarMulta()
        {
            Console.Clear();
            Console.WriteLine("=== Quitar Multa ===");

            var multas = repositorioMulta.ListarPendentes();

            if (multas.Count == 0)
            {
                Console.WriteLine("Nenhuma multa pendente para quitar.");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < multas.Count; i++)
            {
                var m = multas[i];
                Console.WriteLine($"{i + 1} - Amigo: {m.Emprestimo.Amigo.Nome}, Valor: R${m.Valor:F2}, Status: {m.Status}");
            }

            Console.Write("Escolha a multa para quitar (número): ");
            if (!int.TryParse(Console.ReadLine(), out int idMulta) || idMulta < 1 || idMulta > multas.Count)
            {
                Console.WriteLine("Opção inválida!");
                Console.ReadLine();
                return;
            }

            repositorioMulta.Quitar(multas[idMulta - 1].Id);

            Console.WriteLine("Multa quitada com sucesso!");
            Console.ReadLine();
        }

        private void ExibirMulta(Multa m)
        {
            Console.WriteLine($"Amigo: {m.Emprestimo.Amigo.Nome} | Valor: R${m.Valor:F2} | " +
                              $"Status: {m.Status} | Empréstimo em: {m.Emprestimo.DataEmprestimo:dd/MM/yyyy} | " +
                              $"Devolução: {m.Emprestimo.DataDevolucao:dd/MM/yyyy}");
        }
    }
}
