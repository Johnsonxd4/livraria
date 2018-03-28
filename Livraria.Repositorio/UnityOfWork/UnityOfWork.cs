using Livraria.Repositorio.Repositorios.nsLivro;
using Livraria.Interfaces;
using Livraria.Interfaces.Repositorios.nsLivro;

namespace Livraria.Repositorio
{
    public class UnityOfWork : IUnityOfWork
    {
        private DataContext DataContext;
        private ILivroRepository _instance;

        public UnityOfWork(DataContext context)
        {
            DataContext = context;
        }

        public ILivroRepository LivroRepository
        {
            get
            {
                if (_instance == null)
                    _instance = new LivroRepository(DataContext);
                return _instance;
            }
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}
