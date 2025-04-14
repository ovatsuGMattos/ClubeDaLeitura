namespace ClubeDaLeitura.ModuloCaixa;

public class ValidadorCaixa
{
    public static List<string> Validar(Caixa caixa, List<Caixa> caixasExistentes)
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(caixa.Etiqueta) || caixa.Etiqueta.Length > 50)
            erros.Add("A etiqueta é obrigatória e deve ter no máximo 50 caracteres.");

        if (string.IsNullOrWhiteSpace(caixa.Cor))
            erros.Add("A cor é obrigatória.");

        if (caixasExistentes.Any(c => c.Etiqueta == caixa.Etiqueta && c.Id != caixa.Id))
            erros.Add("Já existe uma caixa com esta etiqueta.");

        if (caixa.DiasEmprestimo <= 0)
            erros.Add("O número de dias de empréstimo deve ser maior que zero.");

        return erros;
    }
}

