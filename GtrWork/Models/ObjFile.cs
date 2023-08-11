using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtrWork.Models
{
    public class ObjFile
    {
        public IEnumerable<IFormFile> files { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}
