using Livraria.Dominio.nsLivro;
using Livraria.Servicos.Generics;
using System.Collections.Generic;
using Livraria.DTO.Livro;
using Livraria.Interfaces;

namespace Livraria.Servicos.nsLivro
{
    public class LivroServico : GenericService<Livro>, ILivroServico
    {
        public LivroServico(IUnityOfWork uow) : base(uow) { }

        public void Apagar(int id)
        {
            var livro = UnityOfWork.LivroRepository.FindById(id) 
                ?? throw new System.Exception("Livro não encontrado");
            UnityOfWork.LivroRepository.Delete(livro);
            UnityOfWork.SaveChanges();
        }

        public void Atualizar(LivroDTO.Atualizar livroDto)
        {
          
            var livro = UnityOfWork.LivroRepository.FindById(livroDto.Codigo) ?? 
                throw new System.Exception("Livro não encontrado");
            livro.AtualizarTitulo(livroDto.Titulo);

            UnityOfWork.SaveChanges();
        }

        public Livro Consultar(int id)
        {
            return UnityOfWork.LivroRepository.FindById(id);
        }

        public IEnumerable<Livro> ListarEmOrdemAlfabetica()
        {
            return UnityOfWork.LivroRepository.ListarEmOrdemAlfabetica();
        }

        public void Salvar(LivroDTO.Salvar livroDto)
        {
            var livro = new Livro { Titulo = livroDto.Titulo };
            UnityOfWork.LivroRepository.Add(livro);

            UnityOfWork.SaveChanges();
        }

        
    }
}
