using Livraria.Dominio.nsLivro;
using Livraria.DTO.Livro;
using System.Collections.Generic;
//using Livraria.DTO.Livro;

namespace Livraria.Servicos.nsLivro
{
    public interface ILivroServico
    {
        IEnumerable<Livro> ListarEmOrdemAlfabetica();
        Livro Consultar(int id);
        void Salvar(LivroDTO.Salvar livro);
        void Atualizar(LivroDTO.Atualizar livroDto);
        void Apagar(int id);
    }
}
