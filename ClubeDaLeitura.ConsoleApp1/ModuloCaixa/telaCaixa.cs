using ClubeDaLeitura.ConsoleApp1.Compartilhada;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class TelaCaixa : TelaBase
    {
        private readonly RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public override void Cadastrar()
        {
            Console.WriteLine("Cadastro de Caixa:");

            Console.Write("Etiqueta: ");
            string etiqueta = Console.ReadLine()!;
            if (repositorioCaixa.VerificarEtiquetaDuplicada(etiqueta))
            {
                Console.WriteLine("Já existe uma caixa com essa etiqueta.");
                return;
            }

            Console.Write("Cor (ex: #FFFFFF ou nome da cor): ");
            string cor = Console.ReadLine()!;
            Console.Write("Dias de empréstimo: ");
            int diasEmprestimo = int.Parse(Console.ReadLine()!);

            Caixa novaCaixa = new Caixa(etiqueta, cor, diasEmprestimo);
            repositorioCaixa.Adicionar(novaCaixa);

            Console.WriteLine("Caixa cadastrada com sucesso!");
        }

        public override void Editar()
        {
            Console.Write("Digite o ID da caixa a ser editada: ");
            int id = int.Parse(Console.ReadLine()!);

            Caixa caixa = repositorioCaixa.ObterPorId(id);

            if (caixa == null)
            {
                Console.WriteLine("Caixa não encontrada.");
                return;
            }

            Console.Write("Nova etiqueta: ");
            caixa.Etiqueta = Console.ReadLine()!;
            Console.Write("Nova cor: ");
            caixa.Cor = Console.ReadLine()!;
            Console.Write("Novos dias de empréstimo: ");
            caixa.DiasEmprestimo = int.Parse(Console.ReadLine()!);

            repositorioCaixa.Editar(id, caixa);

            Console.WriteLine("Caixa atualizada com sucesso!");
        }

        public override void Excluir()
        {
            Console.Write("Digite o ID da caixa a ser excluída: ");
            int id = int.Parse(Console.ReadLine()!);

            Caixa caixa = repositorioCaixa.ObterPorId(id);

            if (caixa == null)
            {
                Console.WriteLine("Caixa não encontrada.");
                return;
            }

            repositorioCaixa.Excluir(id);
            Console.WriteLine("Caixa excluída com sucesso!");
        }

        public override void Visualizar()
        {
            Console.WriteLine("== Lista de Caixas ==");
            var caixas = repositorioCaixa.ObterTodos();

            if (caixas.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada.");
                return;
            }

            foreach (var caixa in caixas)
            {
                Console.WriteLine($"ID: {caixa.Id} - Etiqueta: {caixa.Etiqueta} - Cor: {caixa.Cor} - Dias de Empréstimo: {caixa.DiasEmprestimo}");
            }
        }
    }
}
