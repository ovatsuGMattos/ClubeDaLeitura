using System.Collections.Generic;
using System.Linq;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        private List<Emprestimo> emprestimos;

        public RepositorioEmprestimo()
        {
            emprestimos = new List<Emprestimo>();
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            emprestimos.Add(emprestimo);
        }

        public void Devolver(int id)
        {
            var emprestimo = emprestimos.FirstOrDefault(e => e.Id == id);
            if (emprestimo != null)
            {
                emprestimo.Status = "Concluído";
            }
        }

        public List<Emprestimo> ObterTodos()
        {
            return emprestimos;
        }

        public List<Emprestimo> ObterEmprestimosPorAmigo(int idAmigo)
        {
            return emprestimos.Where(e => e.Amigo.Id == idAmigo).ToList();
        }

        public Emprestimo ObterPorId(int id)
        {
            return emprestimos.FirstOrDefault(e => e.Id == id)!;
        }

        public bool VerificarEmprestimoAtivo(int idAmigo)
        {
            return emprestimos.Any(e => e.Amigo.Id == idAmigo && e.Status == "Aberto");
        }
    }
}
