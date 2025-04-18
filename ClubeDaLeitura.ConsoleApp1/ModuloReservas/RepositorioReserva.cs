namespace ClubeDaLeitura.ModuloReserva
{
    public class RepositorioReserva
    {
        private List<Reserva> reservas;

        public RepositorioReserva()
        {
            reservas = new List<Reserva>();
        }

        public void Adicionar(Reserva reserva)
        {
            reservas.Add(reserva);
        }

        public void ConcluirReserva(Reserva reserva)
        {
            reserva.Status = "Concluída";
        }

        public void CancelarReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
                reservas.Remove(reserva);
        }

        public List<Reserva> ObterTodas()
        {
            return reservas;
        }

        public List<Reserva> ObterAtivas()
        {
            return reservas.Where(r => r.Status == "Ativa").ToList();
        }

        public Reserva ObterPorId(int id)
        {
            return reservas.FirstOrDefault(r => r.Id == id)!;
        }
    }
}
