public class TelaAmigo
{
    private RepositorioAmigo repositorio;

    public TelaAmigo(RepositorioAmigo repositorio)
    {
        this.repositorio = repositorio;
    }

    public void Inserir()
    {
        var amigo = ObterDadosAmigo();
        var erros = ValidadorAmigo.Validar(amigo, repositorio.SelecionarTodos());

        if (erros.Any())
        {
            MostrarErros(erros);
            return;
        }

        repositorio.Inserir(amigo);
        Console.WriteLine("Amigo inserido com sucesso!");
    }

    public void Editar()
    {
        Visualizar();

        Console.Write("Informe o ID do amigo para editar: ");
        int id = int.Parse(Console.ReadLine()!);

        var amigo = ObterDadosAmigo();
        amigo.Id = id;

        var erros = ValidadorAmigo.Validar(amigo, repositorio.SelecionarTodos());

        if (erros.Any())
        {
            MostrarErros(erros);
            return;
        }

        repositorio.Editar(amigo);
        Console.WriteLine("Amigo editado com sucesso!");
    }

    public void Excluir()
    {
        Visualizar();

        Console.Write("Informe o ID do amigo para excluir: ");
        int id = int.Parse(Console.ReadLine()!);

        bool sucesso = repositorio.Excluir(id);

        if (!sucesso)
            Console.WriteLine("Não foi possível excluir. O amigo pode ter empréstimos vinculados.");
        else
            Console.WriteLine("Amigo excluído com sucesso!");
    }

    public void Visualizar()
    {
        Console.WriteLine("\nLista de amigos cadastrados:\n");

        var amigos = repositorio.SelecionarTodos();
        foreach (var amigo in amigos)
            Console.WriteLine(amigo);
    }

    public void VisualizarEmprestimos()
    {
        Visualizar();

        Console.Write("Informe o ID do amigo para ver os empréstimos: ");
        int id = int.Parse(Console.ReadLine()!);

        var amigo = repositorio.SelecionarPorId(id);

        if (amigo == null)
        {
            Console.WriteLine("Amigo não encontrado.");
            return;
        }

        Console.WriteLine($"\nEmpréstimos do amigo {amigo.Nome}:\n");

        if (amigo.Emprestimos.Count == 0)
            Console.WriteLine("Nenhum empréstimo registrado.");
        else
        {
            foreach (var emprestimo in amigo.Emprestimos)
                Console.WriteLine(emprestimo); 
        }
    }
    private Amigo ObterDadosAmigo()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("Nome do Responsável: ");
        string nomeResp = Console.ReadLine()!;

        Console.Write("Telefone (formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX): ");
        string telefone = Console.ReadLine()!;

        return new Amigo
        {
            Nome = nome,
            NomeResponsavel = nomeResp,
            Telefone = telefone
        };
    }

    private void MostrarErros(List<string> erros)
    {
        Console.WriteLine("\nErros encontrados:");
        foreach (var erro in erros)
            Console.WriteLine($"- {erro}");
    }
}

