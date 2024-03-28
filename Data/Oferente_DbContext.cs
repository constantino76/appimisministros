using Microsoft.EntityFrameworkCore;

namespace AppiMinistros.Data
{
    public class Oferente_DbContext:DbContext
    {

        public Oferente_DbContext(DbContextOptions<Oferente_DbContext> options)
            : base(options)
        {
        }


        public DbSet<AppiMinistros.Models.Titulo> Tbtitulos { get; set; }
        public DbSet<AppiMinistros.Models.Oferente> TbOferente { get; set; } = default!;
        public DbSet<AppiMinistros.Models.Experiencia_trabajo> TbExpLaboral { get; set; }

    }
}
