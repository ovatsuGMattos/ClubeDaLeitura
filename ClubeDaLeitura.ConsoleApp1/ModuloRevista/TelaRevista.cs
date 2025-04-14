using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp1.ModuloRevista;

public class TelaRevista
{
    private RepositorioRevista repositorio;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorio, RepositorioCaixa repositorioCaixa)
    {
        this.repositorio = repositorio;
        this.repositorioCaixa = repositorioCaixa;
    }
    public void Inserir()
    {
        var revista = ObterDadosRevista();
        var erros = ValidadorRevista.Validar(revista, repositorio.SelecionarTodos());

        if (erros.Any())
        {
            MostrarErros(erros);
            return;
        }

        repositorio.Inserir(revista);
        revista.Caixa.Revistas.Add(revista);
        Console.WriteLine("Revista cadastrada com sucesso!");
    }

    public void Editar()
    {
        Visualizar();

        Console.Write("Informe o ID da revista para editar: ");
        int id = int.Parse(Console.ReadLine()!);

        var revistaAtualizada = ObterDadosRevista();
        revistaAtualizada.Id = id;

        var erros = ValidadorRevista.Validar(revistaAtualizada, repositorio.SelecionarTodos());

        if (erros.Any())
        {
            MostrarErros(erros);
            return;
        }

        repositorio.Editar(revistaAtualizada);
        Console.WriteLine("Revista editada com sucesso!");
    }

    public void Excluir()
    {
        Visualizar();

        Console.Write("\nInforme o ID da revista para excluir: ");
        int id = int.Parse(Console.ReadLine()!);

        repositorio.Excluir(id);
        Console.WriteLine("Revista excluída com sucesso!");
    }
    public void Visualizar()
    {
        Console.WriteLine("Lista de revistas cadastradas:\n");

        var revistas = repositorio.SelecionarTodos();
        if (revistas.Count == 0)
        {
            Console.WriteLine("Nenhuma revista cadastrada.");
            return;
        }

        foreach (var revista in revistas)
            Console.WriteLine(revista);
    }
    private Revista ObterDadosRevista()
    {
        Console.Write("Título (2 a 100 caracteres): ");
        string titulo = Console.ReadLine()!;

        Console.Write("Número da edição: ");
        int edicao = int.Parse(Console.ReadLine()!);

        Console.Write("Ano de publicação: ");
        int ano = int.Parse(Console.ReadLine()!);

        Console.WriteLine("\nCaixas disponíveis:");
        var caixas = repositorioCaixa.SelecionarTodos();
        foreach (var caixa in caixas)
            Console.WriteLine($"{caixa.Id} - {caixa.Etiqueta}");

        Console.Write("Escolha o ID da caixa: ");
        int idCaixa = int.Parse(Console.ReadLine()!);
        var caixaSelecionada = repositorioCaixa.SelecionarPorId(idCaixa);

        return new Revista
        {
            Titulo = titulo,
            NumeroEdicao = edicao,
            Ano = ano,
            Caixa = caixaSelecionada
        };
    }
    private void MostrarErros(List<string> erros)
    {
        Console.WriteLine("Erros encontrados:");
        foreach (var erro in erros)
            Console.WriteLine($"- {erro}");
    }
}
