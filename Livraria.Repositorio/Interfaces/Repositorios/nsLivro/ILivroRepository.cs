using System.Collections.Generic;
using Livraria.Dominio.nsLivro;
using Livraria.Interfaces.Repositorios.Generics;


namespace Livraria.Interfaces.Repositorios.nsLivro
{
    public interface ILivroRepository : IGenericRepository<Livro>
    {
        IEnumerable<Livro> ListarEmOrdemAlfabetica();
    }
}
