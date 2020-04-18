using System;
using System.Collections.Generic;
using System.Text;

namespace mocks.domain.Settings
{
    public class AppSettings
    {
        public string BlobConnectionString { get; set; }
        public string ContainerTemp { get; set; }
        public string Container { get; set; }
    }
}
