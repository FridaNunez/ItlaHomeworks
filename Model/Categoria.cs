namespace PlantStore.model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Planta> Plantas { get; set; } = new();
    }
}
