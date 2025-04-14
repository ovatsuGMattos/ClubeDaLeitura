namespace ClubeDaLeitura.ConsoleApp1.ModuloRevista;

public class ValidadorRevista
{
    public static List<string> Validar(Revista revista, List<Revista> revistasExistentes)
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(revista.Titulo) || revista.Titulo.Length < 2 || revista.Titulo.Length > 100)
            erros.Add("O título deve ter entre 2 e 100 caracteres.");

        if (revista.NumeroEdicao <= 0)
            erros.Add("O número da edição deve ser positivo.");

        if (revista.Ano < 1900 || revista.Ano > DateTime.Now.Year)
            erros.Add("Ano de publicação inválido.");

        if (revista.Caixa == null)
            erros.Add("A caixa da revista é obrigatória.");

        if (revistasExistentes.Any(r =>
            r.Titulo.Equals(revista.Titulo, StringComparison.OrdinalIgnoreCase)
            && r.NumeroEdicao == revista.NumeroEdicao
            && r.Id != revista.Id))
            erros.Add("Já existe uma revista com esse título e edição.");

        return erros;
    }
}
