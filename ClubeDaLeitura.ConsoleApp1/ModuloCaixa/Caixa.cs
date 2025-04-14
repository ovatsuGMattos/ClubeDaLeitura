namespace ClubeDaLeitura.ModuloCaixa;

public class Caixa
{
    public int Id { get; set; }
    public string Etiqueta { get; set; }
    public string Cor { get; set; }
    public int DiasEmprestimo { get; set; } = 7;

    public List<Revista> Revistas { get; set; } = new();

    public override string ToString()
    {
        return $"{Id}. Etiqueta: {Etiqueta} | Cor: {Cor} | Dias Empréstimo: {DiasEmprestimo}";
    }
}
