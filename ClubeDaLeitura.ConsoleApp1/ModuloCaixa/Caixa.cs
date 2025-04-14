namespace ClubeDaLeitura.ModuloCaixa
{
    public class Caixa : ClubeDaLeitura.ConsoleApp1.Compartilhada.EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }
    }
}
