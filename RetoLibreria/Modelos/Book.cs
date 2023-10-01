namespace RetoLibreria.Modelos
{
    public class Book
    {
        public Book() { }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string APublicacion { get; set; }
        
        public User User { get; set; }

        public List<Calificacion> Calificaciones { get; set;}
        public List<Resena> Resenas { get; set; }



    }
}
