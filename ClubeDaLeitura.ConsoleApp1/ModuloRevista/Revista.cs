using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    public class Revista : ClubeDaLeitura.ConsoleApp1.Compartilhada.EntidadeBase
    {
        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public Caixa Caixa { get; set; } 
        public string Status { get; set; } 
        public object NumeroEdicao { get; internal set; }
        public int Ano { get; internal set; }

        public Revista(string titulo, int edicao, int anoPublicacao, Caixa caixa)
        {
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            Caixa = caixa;
            Status = "Disponível"; 
        }
    }
}
