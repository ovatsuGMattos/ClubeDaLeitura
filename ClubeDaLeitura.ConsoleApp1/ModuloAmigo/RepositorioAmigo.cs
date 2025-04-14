public class RepositorioAmigo
{
    private List<Amigo> amigos = new();
    private int contadorId = 1;

    public List<Amigo> SelecionarTodos() => amigos;

    public Amigo SelecionarPorId(int id) =>
        amigos.FirstOrDefault(a => a.Id == id)!;

    public void Inserir(Amigo amigo)
    {
        amigo.Id = contadorId++;
        amigos.Add(amigo);
    }

    public void Editar(Amigo amigoAtualizado)
    {
        var amigo = SelecionarPorId(amigoAtualizado.Id);
        if (amigo != null)
        {
            amigo.Nome = amigoAtualizado.Nome;
            amigo.NomeResponsavel = amigoAtualizado.NomeResponsavel;
            amigo.Telefone = amigoAtualizado.Telefone;
        }
    }

    public bool Excluir(int id)
    {
        var amigo = SelecionarPorId(id);
        if (amigo == null || amigo.Emprestimos.Any())
            return false;

        return amigos.Remove(amigo);
    }
}
