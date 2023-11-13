using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.Objects
{
    public class Product
    {
        /// <summary>
        ///  int id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// String Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// String Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Float Price
        /// </summary>
        public float Price { get; set; }
    }
}
