using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurementTool.Utility
{
    public class ComboBoxItem
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ComboBoxItem()
        {

        }
        public ComboBoxItem(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }


    }
}
