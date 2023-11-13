using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.Objects
{
   public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Name 
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
