using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Store_Managements
{
    internal class LoaiThanhToan
    {
        public string Ten { get; set; }
        public string Ma { get; set; }

        public override string ToString()
        {
            return Ten;
        }
    }
}
