using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    public class Query
    {
        public String queryId { get; set; }
        public String queryText { get; set; }
        
        public override string ToString()
        {
            return queryText;
        }
    }
}
