using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.CollectionQuery
{
    public class SortColumn
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value.ToLower();
        }

        public Directions Direction { get; set; }

        public enum Directions
        {
            Ascending,
            Descending,
        }
    }
}
