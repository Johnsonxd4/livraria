using Livraria.Dominio.nsLivro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Repositorio.Mappings
{
    class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(x => x.Codigo).HasName("CD_LIVRO");
            builder.Property(x => x.Codigo).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).HasColumnName("NM_LIVRO");
        }
    }
}
