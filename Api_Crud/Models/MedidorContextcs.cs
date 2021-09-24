using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud.Models
{
    public class MedidorContextcs : DbContext
    {
        public MedidorContextcs(DbContextOptions<MedidorContextcs>options): base(options)
        {

        }
        public DbSet<Medidor>Medidores { get; set; }
    }
}
