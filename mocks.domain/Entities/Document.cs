using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mocks.domain.Entities
{
   public class Document
    {
        public Stream File { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Guid { get; set; }
    }
}
