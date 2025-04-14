using System.Collections.Generic;
using System.Linq;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class RepositorioAmigo
    {
        private List<Amigo> amigos;

        public RepositorioAmigo()
        {
            amigos = new List<Amigo>();
        }

        public void Adicionar(Amigo amigo)
        {
            amigos.Add(amigo);
        }

        public void Editar(int id, Amigo amigoAtualizado)
        {
            var amigo = amigos.FirstOrDefault(a => a.Id == id);
            if (amigo != null)
            {
                amigo.Nome = amigoAtualizado.Nome;
                amigo.NomeResponsavel = amigoAtualizado.NomeResponsavel;
                amigo.Telefone = amigoAtualizado.Telefone;
            }
        }

        public void Excluir(int id)
        {
            var amigo = amigos.FirstOrDefault(a => a.Id == id);
            if (amigo != null)
                amigos.Remove(amigo);
        }

        public List<Amigo> ObterTodos()
        {
            return amigos;
        }

        public Amigo ObterPorId(int id)
        {
            return amigos.FirstOrDefault(a => a.Id == id)!;
        }

        public bool VerificarSeExiste(string nome, string telefone)
        {
            return amigos.Any(a => a.Nome == nome && a.Telefone == telefone);
        }
    }
}
