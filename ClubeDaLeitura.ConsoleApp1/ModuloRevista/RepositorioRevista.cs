namespace ClubeDaLeitura.ConsoleApp1.ModuloRevista;

public class RepositorioRevista
{
    private List<Revista> revistas = new();
    private int contadorId = 1;

    public List<Revista> SelecionarTodos() => revistas;

    public Revista SelecionarPorId(int id) =>
        revistas.FirstOrDefault(r => r.Id == id)!;

    public void Inserir(Revista revista)
    {
        revista.Id = contadorId++;
        revistas.Add(revista);
    }

    public void Editar(Revista revistaAtualizada)
    {
        var revista = SelecionarPorId(revistaAtualizada.Id);
        if (revista != null)
        {
            revista.Titulo = revistaAtualizada.Titulo;
            revista.NumeroEdicao = revistaAtualizada.NumeroEdicao;
            revista.Ano = revistaAtualizada.Ano;
            revista.Caixa = revistaAtualizada.Caixa;
        }
    }

    public void Excluir(int id)
    {
        var revista = SelecionarPorId(id);
        if (revista != null)
            revistas.Remove(revista);
    }
}

