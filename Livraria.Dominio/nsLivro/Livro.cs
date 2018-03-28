namespace Livraria.Dominio.nsLivro
{
    public class Livro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }

        public void AtualizarTitulo(string titulo)
        {
            this.Titulo = titulo;
        }
    }
}
