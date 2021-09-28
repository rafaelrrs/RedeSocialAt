using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }
    }
}
