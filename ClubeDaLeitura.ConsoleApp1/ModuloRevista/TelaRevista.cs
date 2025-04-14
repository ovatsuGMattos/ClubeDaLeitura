using ClubeDaLeitura.ModuloCaixa;
using System;

namespace ClubeDaLeitura.ModuloRevista
{
    public class TelaRevista : ClubeDaLeitura.ConsoleApp1.Compartilhada.TelaBase
    {
        private readonly RepositorioRevista repositorioRevista;
        private readonly RepositorioCaixa repositorioCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("Cadastro de Revista:");

            Console.Write("Título: ");
            string titulo = Console.ReadLine()!;

            Console.Write("Número da Edição: ");
            int edicao = int.Parse(Console.ReadLine()!);

            if (repositorioRevista.VerificarTituloEdicaoDuplicado(titulo, edicao))
            {
                Console.WriteLine("Já existe uma revista com esse título e edição.");
                return;
            }

            Console.Write("Ano de Publicação: ");
            int anoPublicacao = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Selecione a Caixa:");
            var caixas = repositorioCaixa.ObterTodos();
            for (int i = 0; i < caixas.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {caixas[i].Etiqueta}");
            }
            int idCaixa = int.Parse(Console.ReadLine()!) - 1;

            Caixa caixaSelecionada = caixas[idCaixa];

            Revista novaRevista = new Revista(titulo, edicao, anoPublicacao, caixaSelecionada);
            repositorioRevista.Adicionar(novaRevista);

            Console.WriteLine("Revista cadastrada com sucesso!");
        }

        public override void Editar()
        {
            Console.Write("Digite o ID da revista a ser editada: ");
            int id = int.Parse(Console.ReadLine()!);

            Revista revista = repositorioRevista.ObterPorId(id);

            if (revista == null)
            {
                Console.WriteLine("Revista não encontrada.");
                return;
            }

            Console.Write("Novo título: ");
            revista.Titulo = Console.ReadLine()!;

            Console.Write("Nova edição: ");
            revista.Edicao = int.Parse(Console.ReadLine()!);

            Console.Write("Novo ano de publicação: ");
            revista.AnoPublicacao = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Selecione a nova caixa:");
            var caixas = repositorioCaixa.ObterTodos();
            for (int i = 0; i < caixas.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {caixas[i].Etiqueta}");
            }
            int idCaixa = int.Parse(Console.ReadLine()!) - 1;

            revista.Caixa = caixas[idCaixa];

            repositorioRevista.Editar(id, revista);

            Console.WriteLine("Revista atualizada com sucesso!");
        }

        public override void Excluir()
        {
            Console.Write("Digite o ID da revista a ser excluída: ");
            int id = int.Parse(Console.ReadLine()!);

            Revista revista = repositorioRevista.ObterPorId(id);

            if (revista == null)
            {
                Console.WriteLine("Revista não encontrada.");
                return;
            }

            repositorioRevista.Excluir(id);
            Console.WriteLine("Revista excluída com sucesso!");
        }

        public override void Visualizar()
        {
            Console.WriteLine("== Lista de Revistas ==");
            var revistas = repositorioRevista.ObterTodos();

            if (revistas.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada.");
                return;
            }

            foreach (var revista in revistas)
            {
                Console.WriteLine($"ID: {revista.Id} - Título: {revista.Titulo} - Edição: {revista.Edicao} - Ano: {revista.AnoPublicacao} - Status: {revista.Status} - Caixa: {revista.Caixa.Etiqueta}");
            }
        }
    }
}
