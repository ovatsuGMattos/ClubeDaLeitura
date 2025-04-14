public class Amigo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeResponsavel { get; set; }
    public string Telefone { get; set; }

    public List<Emprestimo> Emprestimos { get; set; } = new();

    public override string ToString()
    {
        return $"{Id}. {Nome} (Responsável: {NomeResponsavel}, Tel: {Telefone})";
    }
}

