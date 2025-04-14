using ClubeDaLeitura.ModuloEmprestimo;
using System;
using System.Linq;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class TelaAmigo : ClubeDaLeitura.ConsoleApp1.Compartilhada.TelaBase
    {
        private readonly RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("Cadastro de Amigo:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;
            Console.Write("Nome do Responsável: ");
            string nomeResponsavel = Console.ReadLine()!;
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine()!;

            if (repositorioAmigo.VerificarSeExiste(nome, telefone))
            {
                Console.WriteLine("Já existe um amigo com esse nome e telefone.");
                return;
            }

            Amigo novoAmigo = new Amigo(nome, nomeResponsavel, telefone);
            repositorioAmigo.Adicionar(novoAmigo);

            Console.WriteLine("Amigo cadastrado com sucesso!");
        }

        public override void Editar()
        {
            Console.Write("Digite o ID do amigo a ser editado: ");
            int id = int.Parse(Console.ReadLine()!);

            Amigo amigo = repositorioAmigo.ObterPorId(id);

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            Console.Write("Novo nome: ");
            amigo.Nome = Console.ReadLine()!;
            Console.Write("Novo nome do responsável: ");
            amigo.NomeResponsavel = Console.ReadLine()!;
            Console.Write("Novo telefone: ");
            amigo.Telefone = Console.ReadLine()!;

            repositorioAmigo.Editar(id, amigo);

            Console.WriteLine("Amigo atualizado com sucesso!");
        }

        public override void Excluir(RepositorioEmprestimo repositorioEmprestimo)
        {
            Console.Write("Digite o ID do amigo a ser excluído: ");
            int id = int.Parse(Console.ReadLine()!);

            Amigo amigo = repositorioAmigo.ObterPorId(id);

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            repositorioAmigo.Excluir(id);
            Console.WriteLine("Amigo excluído com sucesso!");
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Visualizar()
        {
            Console.WriteLine("== Lista de Amigos ==");
            var amigos = repositorioAmigo.ObterTodos();

            if (!amigos.Any())
            {
                Console.WriteLine("Nenhum amigo cadastrado.");
                return;
            }

            foreach (var amigo in amigos)
            {
                Console.WriteLine($"ID: {amigo.Id} - Nome: {amigo.Nome} - Telefone: {amigo.Telefone} - Responsável: {amigo.NomeResponsavel}");
            }
        }

        public void VisualizarEmprestimos(RepositorioEmprestimo repositorioEmprestimo)
        {
            Console.Write("Digite o ID do amigo para visualizar seus empréstimos: ");
            int id = int.Parse(Console.ReadLine()!);

            Amigo amigo = repositorioAmigo.ObterPorId(id);
            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            var emprestimos = repositorioEmprestimo.ObterEmprestimosPorAmigo(id);
            if (!emprestimos.Any())
            {
                Console.WriteLine("Esse amigo não possui empréstimos.");
                return;
            }

            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"Revista: {emprestimo.Revista.Titulo} | Status: {emprestimo.Status} | Data Empréstimo: {emprestimo.DataEmprestimo}");
            }
        }
    }
}
