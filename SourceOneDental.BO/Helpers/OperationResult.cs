using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceOneDental.BO.Helpers
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public T ResultObject { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
