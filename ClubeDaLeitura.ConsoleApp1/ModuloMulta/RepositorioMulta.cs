using System.Collections.Generic;
using System.Linq;

namespace ClubeDaLeitura.ConsoleApp.ModuloMulta
{
    public class RepositorioMulta
    {
        private List<Multa> multas = new List<Multa>();

        public void Adicionar(Multa multa)
        {
            multas.Add(multa);
        }

        public List<Multa> Listar()
        {
            return multas;
        }

        public List<Multa> ListarPendentes()
        {
            return multas.Where(m => m.Status == "Pendente").ToList();
        }

        public Multa BuscarPorId(int id)
        {
            return multas.FirstOrDefault(m => m.Id == id)!;
        }

        public List<Multa> BuscarPorAmigo(string nomeAmigo)
        {
            return multas
                .Where(m => m.Emprestimo.Amigo.Nome.Equals(nomeAmigo, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool MultasPendentes(string nomeAmigo)
        {
            return multas.Any(m =>
                m.Emprestimo.Amigo.Nome.Equals(nomeAmigo, StringComparison.OrdinalIgnoreCase)
                && m.Status == "Pendente");
        }

        public void Quitar(int idMulta)
        {
            Multa multa = BuscarPorId(idMulta);
            if (multa != null)
                multa.Quitar();
        }
    }
}
