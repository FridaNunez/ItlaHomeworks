

namespace PlantStore.model
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public List<PedidoPlanta> Items { get; set; } = new();
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}