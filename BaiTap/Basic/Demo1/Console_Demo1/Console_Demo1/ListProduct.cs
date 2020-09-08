using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Demo1
{
    sealed class ListProduct
    {
        Product[] listProduct1;
        Product[] listProduct2;
        public Product this[int index]
        {
            get
            {
                /* return the specified index here */
                return listProduct1[index];
            }
            set
            {
                /* set the specified index to value here */
                listProduct1[index] = value;
            }
        }
    }
}
