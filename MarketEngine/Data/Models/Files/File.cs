using MarketEngine.Core.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models.Files
{
    public abstract class File
    {
        public File() { }

        public File(IFormFile file)
        {
            FileStream stream;
            var fileName = Randomizer.GetString() + System.IO.Path.GetExtension(file.FileName);
            using (stream = new FileStream($"wwwroot/files/{fileName}", FileMode.Create))
                file.CopyTo(stream);

            Path = stream.Name;
        }

        public long Id { get; set; }

        public string Path { get; set; }
    }
}
