using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Crud.Models
{
    public class Medidor
    {
        [Key]
        public int MedidorId { get; set; }

        [Column (TypeName ="nvarchar(50)")]
        public string MedidorTipo { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string MedidorStatus { get; set; }

        public int SerialNumber { get; set;}

        public string MedidorConsumo { get; set; }
    }
}
