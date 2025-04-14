namespace ClubeDaLeitura.ModuloCaixa;

public class TelaCaixa
{
    private RepositorioCaixa repositorio;

    public TelaCaixa(RepositorioCaixa repositorio)
    {
        this.repositorio = repositorio;
    }

    public void Inserir()
    {
        var caixa = ObterDadosCaixa();
        var erros = ValidadorCaixa.Validar(caixa, repositorio.SelecionarTodos());

        if (erros.Any())
        {
            MostrarErros(erros);
            return;
        }

        repositorio.Inserir(caixa);
        Console.WriteLine("Caixa cadastrada com sucesso!");
    }

    public void Editar()
    {
        Visualizar();

        Console.Write("\nInforme o ID da caixa para editar: ");
        int id = int.Parse(Console.ReadLine()!);

        var caixa = ObterDadosCaixa();
        caixa.Id = id;

        var erros = ValidadorCaixa.Validar(caixa, repositorio.SelecionarTodos());

        if (erros.Any())
        {
            MostrarErros(erros);
            return;
        }

        repositorio.Editar(caixa);
        Console.WriteLine("Caixa editada com sucesso!");
    }

    public void Excluir()
    {
        Visualizar();

        Console.Write("\nInforme o ID da caixa para excluir: ");
        int id = int.Parse(Console.ReadLine()!);

        bool sucesso = repositorio.Excluir(id);

        if (!sucesso)
            Console.WriteLine("Não foi possível excluir. A caixa pode ter revistas vinculadas.");
        else
            Console.WriteLine("Caixa excluída com sucesso!");
    }

    public void Visualizar()
    {
        Console.WriteLine("Lista de caixas cadastradas:\n");

        var caixas = repositorio.SelecionarTodos();
        if (caixas.Count == 0)
        {
            Console.WriteLine("Nenhuma caixa cadastrada.");
            return;
        }

        foreach (var caixa in caixas)
            Console.WriteLine(caixa);
    }

    private Caixa ObterDadosCaixa()
    {
        Console.Write("Etiqueta (máx 50 caracteres): ");
        string etiqueta = Console.ReadLine()!;

        Console.Write("Cor (ex: vermelho, #FF0000): ");
        string cor = Console.ReadLine()!;

        Console.Write("Dias de Empréstimo (padrão 7): ");
        string diasStr = Console.ReadLine()!;
        int dias = string.IsNullOrWhiteSpace(diasStr) ? 7 : int.Parse(diasStr);

        return new Caixa
        {
            Etiqueta = etiqueta,
            Cor = cor,
            DiasEmprestimo = dias
        };
    }

    private void MostrarErros(List<string> erros)
    {
        Console.WriteLine("\nErros encontrados:");
        foreach (var erro in erros)
            Console.WriteLine($"- {erro}");
    }
}
