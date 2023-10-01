namespace RetoLibreria.Modelos
{
    public class Calificacion
    {
        public Calificacion() { }

        public int Id { get; set; }
        public int Valor { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
