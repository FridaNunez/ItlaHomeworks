using PlantStore.dbcontext;
using PlantStore.model;
using Microsoft.EntityFrameworkCore;

namespace PlantStore.services
{
    public static class PedidoService
    {
        // Crear un pedido con un item
        public static void CreateOrder(int clienteId, int plantaId, int cantidad)
        {
            using var db = new TiendaContext();

            var pedido = new Pedido
            {
                ClienteId = clienteId,
                Fecha = DateTime.Now,
                Items = new List<PedidoPlanta>
                {
                    new PedidoPlanta
                    {
                        PlantaId = plantaId,
                        Cantidad = cantidad
                    }
                }
            };

            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }

        // Obtener todos los pedidos
        public static List<Pedido> GetOrders()
        {
            using var db = new TiendaContext();
            return db.Pedidos
                     .Include(p => p.Items)
                     .ThenInclude(i => i.Planta)
                     .Include(p => p.Cliente)
                     .ToList();
        }

        // Obtener pedido por Id
        public static Pedido? GetOrderById(int id)
        {
            using var db = new TiendaContext();
            return db.Pedidos
                     .Include(p => p.Items)
                     .ThenInclude(i => i.Planta)
                     .Include(p => p.Cliente)
                     .FirstOrDefault(p => p.Id == id);
        }

        // Actualizar cantidad de un item
        public static void UpdateOrderItem(int pedidoId, int plantaId, int nuevaCantidad)
        {
            using var db = new TiendaContext();
            var pedido = db.Pedidos
                           .Include(p => p.Items)
                           .FirstOrDefault(p => p.Id == pedidoId);

            if (pedido != null)
            {
                var item = pedido.Items.FirstOrDefault(i => i.PlantaId == plantaId);
                if (item != null)
                {
                    item.Cantidad = nuevaCantidad;
                    db.SaveChanges();
                }
            }
        }

        // Eliminar pedido completo
        public static void DeleteOrder(int pedidoId)
        {
            using var db = new TiendaContext();
            var pedido = db.Pedidos
                           .Include(p => p.Items)
                           .FirstOrDefault(p => p.Id == pedidoId);
            if (pedido != null)
            {
                db.Pedidos.Remove(pedido);
                db.SaveChanges();
            }
        }
    }
}
