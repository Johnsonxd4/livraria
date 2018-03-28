using Livraria.Interfaces.Repositorios.nsLivro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Interfaces
{
    public interface IUnityOfWork
    {
        ILivroRepository LivroRepository { get; }
        void SaveChanges();
    }
}
