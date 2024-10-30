using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Extensions
{
    public class JewelryStoreException:ApplicationException
    {
        public JewelryStoreException(string message) : base($"JewelryStore exception { message}")
        {
        
        }
    }
}
