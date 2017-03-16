using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public abstract class AbsModel
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
