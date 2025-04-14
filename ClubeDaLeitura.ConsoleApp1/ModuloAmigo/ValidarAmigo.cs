using System.Text.RegularExpressions;

public class ValidadorAmigo
{
    public static List<string> Validar(Amigo amigo, List<Amigo> amigosExistentes)
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(amigo.Nome) || amigo.Nome.Length < 3 || amigo.Nome.Length > 100)
            erros.Add("O nome deve ter entre 3 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(amigo.NomeResponsavel) || amigo.NomeResponsavel.Length < 3 || amigo.NomeResponsavel.Length > 100)
            erros.Add("O nome do responsável deve ter entre 3 e 100 caracteres.");

        if (!Regex.IsMatch(amigo.Telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
            erros.Add("Telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.");

        if (amigosExistentes.Any(a => a.Nome == amigo.Nome && a.Telefone == amigo.Telefone && a.Id != amigo.Id))
            erros.Add("Já existe um amigo com o mesmo nome e telefone.");

        return erros;
    }
}
