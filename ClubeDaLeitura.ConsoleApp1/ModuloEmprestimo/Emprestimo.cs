using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ConsoleApp1.Compartilhada;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase
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
