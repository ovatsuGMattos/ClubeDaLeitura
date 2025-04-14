using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp1.ModuloRevista;

public enum StatusRevista
{
    Disponivel,
    Emprestada,
    Reservada
}
public class Revista
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int NumeroEdicao { get; set; }
    public int Ano { get; set; }
    public Caixa Caixa { get; set; }
    public StatusRevista Status { get; set; } = StatusRevista.Disponivel;

    public override string ToString()
    {
        return $"{Id}. {Titulo} - Edição {NumeroEdicao} ({Ano}) | Caixa: {Caixa?.Etiqueta} | Status: {Status}";
    }
}
