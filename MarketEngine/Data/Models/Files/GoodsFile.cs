using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models.Files
{
    [Table("GoodsFiles")]
    public class GoodsFile : File
    {
        public GoodsFile() { }

        public GoodsFile(IFormFile file): base(file) { }

        public long GoodsId { get; set; }

        public Goods Goods { get; set; }
    }
}
