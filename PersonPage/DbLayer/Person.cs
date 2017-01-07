using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPage.DbLayer
{
    [Table("persons")]
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public SexType Sex { get; set; }
        public string ImageLink { get; set; }
        public int Id { get; set; }
    }
}
