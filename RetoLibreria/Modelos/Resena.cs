namespace RetoLibreria.Modelos
{
    public class Resena
    {
        public Resena() { }

        public int Id { get; set; }
        public string ContenidoResena { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
