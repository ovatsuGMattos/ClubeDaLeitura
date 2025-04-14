namespace ClubeDaLeitura.ModuloCaixa;

public class RepositorioCaixa
{
    private List<Caixa> caixas = new();
    private int contadorId = 1;

    public List<Caixa> SelecionarTodos() => caixas;

    public Caixa SelecionarPorId(int id) =>
        caixas.FirstOrDefault(c => c.Id == id)!;

    public void Inserir(Caixa caixa)
    {
        caixa.Id = contadorId++;
        caixas.Add(caixa);
    }

    public void Editar(Caixa caixaAtualizada)
    {
        var caixa = SelecionarPorId(caixaAtualizada.Id);
        if (caixa != null)
        {
            caixa.Etiqueta = caixaAtualizada.Etiqueta;
            caixa.Cor = caixaAtualizada.Cor;
            caixa.DiasEmprestimo = caixaAtualizada.DiasEmprestimo;
        }
    }

    public bool Excluir(int id)
    {
        var caixa = SelecionarPorId(id);
        if (caixa == null || caixa.Revistas.Any())
            return false;

        return caixas.Remove(caixa);
    }
}
