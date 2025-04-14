using System.Collections.Generic;
using System.Linq;

namespace ClubeDaLeitura.ModuloRevista
{
    public class RepositorioRevista
    {
        private List<Revista> revistas;

        public RepositorioRevista()
        {
            revistas = new List<Revista>();
        }

        public void Adicionar(Revista revista)
        {
            revistas.Add(revista);
        }

        public void Editar(int id, Revista revistaAtualizada)
        {
            var revista = revistas.FirstOrDefault(r => r.Id == id);
            if (revista != null)
            {
                revista.Titulo = revistaAtualizada.Titulo;
                revista.Edicao = revistaAtualizada.Edicao;
                revista.AnoPublicacao = revistaAtualizada.AnoPublicacao;
                revista.Caixa = revistaAtualizada.Caixa;
            }
        }

        public void Excluir(int id)
        {
            var revista = revistas.FirstOrDefault(r => r.Id == id);
            if (revista != null)
                revistas.Remove(revista);
        }

        public List<Revista> ObterTodos()
        {
            return revistas;
        }

        public Revista ObterPorId(int id)
        {
            return revistas.FirstOrDefault(r => r.Id == id)!;
        }

        public bool VerificarTituloEdicaoDuplicado(string titulo, int edicao)
        {
            return revistas.Any(r => r.Titulo == titulo && r.Edicao == edicao);
        }
    }
}
