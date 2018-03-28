using Livraria.Interfaces;

namespace Livraria.Servicos.Generics
{
    public abstract class GenericService<T> where T : class
    {
        internal IUnityOfWork UnityOfWork;
        public GenericService(IUnityOfWork uow)
        {
            UnityOfWork = uow;
        }
    }
}
