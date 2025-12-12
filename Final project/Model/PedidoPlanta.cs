namespace PlantStore.model
{
    public class PedidoPlanta
    {
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public int PlantaId { get; set; }
        public Planta? Planta { get; set; }

        public int Cantidad { get; set; }
    }
}
