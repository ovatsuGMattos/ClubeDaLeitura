namespace ClubeDaLeitura.ModuloAmigo
{
    public class Amigo : ClubeDaLeitura.ConsoleApp1.Compartilhada.EntidadeBase
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }

        public Amigo(string nome, string nomeResponsavel, string telefone)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
        }
    }
}
