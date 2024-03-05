using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; }
        public float Cost { get; set; }

        public string PrintItem
        {
            get
            {
                return $"{ItemName} {Cost}";
            }
        }
    }
}
