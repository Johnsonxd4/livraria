using Livraria.Dominio.nsLivro;
using Livraria.Interfaces.Repositorios.nsLivro;
using Livraria.Repositorio.Repositorios.Generics;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Repositorio.Repositorios.nsLivro
{
    public class LivroRepository : GenericRepository<Livro>, ILivroRepository
    {
        public LivroRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Livro> ListarEmOrdemAlfabetica()
        {
            return Set.OrderBy(x => x.Titulo);
        }
    }
}
