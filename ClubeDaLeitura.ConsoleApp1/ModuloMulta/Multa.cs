using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloMulta
{
    public class Multa
    {
        private static int contadorId = 1;

        public int Id { get; private set; }
        public Emprestimo Emprestimo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataGeracao { get; set; }
        public string Status { get; set; }

        public Multa(Emprestimo emprestimo)
        {
            Id = contadorId++;
            Emprestimo = emprestimo;
            DataGeracao = DateTime.Now;
            Status = "Pendente";

            Valor = CalcularValorMulta();
        }
        private decimal CalcularValorMulta()
        {
            if (Emprestimo.DataDevolucao < DateTime.Today)
            {
                int diasAtraso = (DateTime.Today - Emprestimo.DataDevolucao).Days;
                return diasAtraso * 2.00m;
            }

            return 0;
        }
        public void Quitar()
        {
            Status = "Quitada";
        }
    }
}
