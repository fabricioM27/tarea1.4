using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea1._4.Models
{
    public class Fotos
    {
        [PrimaryKey, AutoIncrement]
        public int IdFoto { get; set; }

        public byte[] Imagen { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Descripcion { get; set; }
    }
}
