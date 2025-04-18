using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ConsoleApp1.Compartilhada;
using System;
using System.Linq;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaBase
    {
        private readonly RepositorioEmprestimo repositorioEmprestimo;
        private readonly RepositorioAmigo repositorioAmigo;
        private readonly RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("Cadastro de Empréstimo:");

            Console.Write("Digite o ID do amigo: ");
            int idAmigo = int.Parse(Console.ReadLine()!);
            Amigo amigo = repositorioAmigo.ObterPorId(idAmigo);

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            if (repositorioEmprestimo.VerificarEmprestimoAtivo(idAmigo))
            {
                Console.WriteLine("Este amigo já tem um empréstimo ativo.");
                return;
            }

            Console.Write("Digite o ID da revista: ");
            int idRevista = int.Parse(Console.ReadLine()!);
            Revista revista = repositorioRevista.ObterPorId(idRevista);

            if (revista == null || revista.Status != "Disponível")
            {
                Console.WriteLine("Revista não disponível para empréstimo.");
                return;
            }

            Console.Write("Data de empréstimo (dd/MM/yyyy): ");
            DateTime dataEmprestimo = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);

            Emprestimo novoEmprestimo = new Emprestimo(amigo, revista, dataEmprestimo, revista.Caixa.DiasEmprestimo);
            repositorioEmprestimo.Adicionar(novoEmprestimo);

            revista.Status = "Emprestada";

            Console.WriteLine("Empréstimo registrado com sucesso!");
        }

        public override void Editar()
        {
            Console.Write("Digite o ID do empréstimo a ser editado: ");
            int id = int.Parse(Console.ReadLine()!);

            Emprestimo emprestimo = repositorioEmprestimo.ObterPorId(id);

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado.");
                return;
            }

            Console.Write("Novo status (Aberto / Concluído / Atrasado): ");
            emprestimo.Status = Console.ReadLine()!;

            repositorioEmprestimo.Adicionar(emprestimo);
            Console.WriteLine("Empréstimo atualizado com sucesso!");
        }

        public override void Excluir()
        {
            Console.Write("Digite o ID do empréstimo a ser excluído: ");
            int id = int.Parse(Console.ReadLine()!);

            Emprestimo emprestimo = repositorioEmprestimo.ObterPorId(id);

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado.");
                return;
            }

            repositorioEmprestimo.Devolver(id);

            Console.WriteLine("Empréstimo devolvido e status atualizado para 'Concluído'.");
        }

        public override void Visualizar()
        {
            Console.WriteLine("== Lista de Empréstimos ==");
            var emprestimos = repositorioEmprestimo.ObterTodos();

            if (!emprestimos.Any())
            {
                Console.WriteLine("Nenhum empréstimo registrado.");
                return;
            }

            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"ID: {emprestimo.Id} | Amigo: {emprestimo.Amigo.Nome} | Revista: {emprestimo.Revista.Titulo} | Status: {emprestimo.Status} | Data Empréstimo: {emprestimo.DataEmprestimo:dd/MM/yyyy} | Data Devolução: {emprestimo.DataDevolucao:dd/MM/yyyy}");
            }
        }

        internal void Devolver()
        {
            throw new NotImplementedException();
        }

        internal void Registrar()
        {
            throw new NotImplementedException();
        }
    }
}
