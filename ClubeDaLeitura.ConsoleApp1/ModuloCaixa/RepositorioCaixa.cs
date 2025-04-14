using System.Collections.Generic;
using System.Linq;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class RepositorioCaixa
    {
        private List<Caixa> caixas;

        public RepositorioCaixa()
        {
            caixas = new List<Caixa>();
        }

        public void Adicionar(Caixa caixa)
        {
            caixas.Add(caixa);
        }

        public void Editar(int id, Caixa caixaAtualizada)
        {
            var caixa = caixas.FirstOrDefault(c => c.Id == id);
            if (caixa != null)
            {
                caixa.Etiqueta = caixaAtualizada.Etiqueta;
                caixa.Cor = caixaAtualizada.Cor;
                caixa.DiasEmprestimo = caixaAtualizada.DiasEmprestimo;
            }
        }

        public void Excluir(int id)
        {
            var caixa = caixas.FirstOrDefault(c => c.Id == id);
            if (caixa != null)
                caixas.Remove(caixa);
        }

        public List<Caixa> ObterTodos()
        {
            return caixas;
        }

        public Caixa ObterPorId(int id)
        {
            return caixas.FirstOrDefault(c => c.Id == id)!;
        }

        public bool VerificarEtiquetaDuplicada(string etiqueta)
        {
            return caixas.Any(c => c.Etiqueta == etiqueta);
        }
    }
}
