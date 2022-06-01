namespace ApiAutoresPruebas.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Autorid { get; set; }
        public Autor Autor { get; set; }

    }
}
