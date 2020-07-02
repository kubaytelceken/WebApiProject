using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.DAL.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        //bir kategorinin birden fazla bloğu olabilir. bir blogunda bir kategorisi vardır.
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
