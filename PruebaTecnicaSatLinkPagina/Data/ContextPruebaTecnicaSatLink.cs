using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSatlinkDescargaApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatLinkPagina.Data
{
    public partial class ContextPruebaTecnicaSatLink: DbContext
    {
        public ContextPruebaTecnicaSatLink()
        {

        }

        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public ContextPruebaTecnicaSatLink(DbContextOptions<ContextPruebaTecnicaSatLink> options) : base(options) { }
        public virtual DbSet<Usuario> Users { get; set; }
    }
}
