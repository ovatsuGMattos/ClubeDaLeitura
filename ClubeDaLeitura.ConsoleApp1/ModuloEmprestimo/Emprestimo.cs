using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class Emprestimo : ClubeDaLeitura.ConsoleApp1.Compartilhada.EntidadeBase
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public string Status { get; set; } 
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, int diasEmprestimo)
        {
            Amigo = amigo;
            Revista = revista;
            Status = "Aberto"; 
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataEmprestimo.AddDays(diasEmprestimo); 
        }
    }
}
