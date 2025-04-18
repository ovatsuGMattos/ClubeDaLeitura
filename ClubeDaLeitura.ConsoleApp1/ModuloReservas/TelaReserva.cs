using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ConsoleApp1.Compartilhada;


namespace ClubeDaLeitura.ModuloReserva
{
    public class TelaReserva : TelaBase
    {
        private readonly RepositorioReserva repositorioReserva;
        private readonly RepositorioAmigo repositorioAmigo;
        private readonly RepositorioRevista repositorioRevista;

        public TelaReserva(RepositorioReserva repositorioReserva, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            this.repositorioReserva = repositorioReserva;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        public void CadastrarReserva()
        {
            Console.WriteLine("Cadastro de Reserva:");

            Console.WriteLine("Selecione o amigo:");
            var amigos = repositorioAmigo.ObterTodos();
            for (int i = 0; i < amigos.Count; i++)
                Console.WriteLine($"{i + 1} - {amigos[i].Nome}");

            int idAmigo = int.Parse(Console.ReadLine()!) - 1;
            var amigo = amigos[idAmigo];

            if (amigo.TemMulta)
            {
                Console.WriteLine("O amigo possui multa em aberto. Reserva não permitida.");
                return;
            }

            Console.WriteLine("Selecione a revista:");
            var revistas = repositorioRevista.ObterTodos().Where(r => r.Status == "Disponível").ToList();

            if (revistas.Count == 0)
            {
                Console.WriteLine("Não há revistas disponíveis para reserva.");
                return;
            }

            for (int i = 0; i < revistas.Count; i++)
                Console.WriteLine($"{i + 1} - {revistas[i].Titulo} - Edição {revistas[i].Edicao}");

            int idRevista = int.Parse(Console.ReadLine()!) - 1;
            var revista = revistas[idRevista];

            var reserva = new Reserva(amigo, revista);
            repositorioReserva.Adicionar(reserva);

            revista.Status = "Reservada";

            Console.WriteLine("Reserva cadastrada com sucesso!");
        }

        public void VisualizarAtivas()
        {
            var reservas = repositorioReserva.ObterAtivas();

            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva ativa encontrada.");
                return;
            }

            foreach (var reserva in reservas)
            {
                Console.WriteLine($"ID: {reserva.Id} - Amigo: {reserva.Amigo.Nome} - Revista: {reserva.Revista.Titulo} - Data: {reserva.DataReserva.ToShortDateString()} - Status: {reserva.Status}");
            }
        }

        public void Cancelar()
        {
            Console.Write("Digite o ID da reserva a ser cancelada: ");
            int id = int.Parse(Console.ReadLine()!);

            var reserva = repositorioReserva.ObterPorId(id);
            if (reserva == null || reserva.Status != "Ativa")
            {
                Console.WriteLine("Reserva não encontrada ou já concluída.");
                return;
            }

            reserva.Revista.Status = "Disponível";
            repositorioReserva.CancelarReserva(id);
            Console.WriteLine("Reserva cancelada com sucesso!");
        }

        public override void Cadastrar()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Visualizar()
        {
            throw new NotImplementedException();
        }
    }
}
