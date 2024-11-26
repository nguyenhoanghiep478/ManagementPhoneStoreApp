using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    
        public class CheckListItem
        {
        public string Label { get; set; }
        public bool IsSelected { get; set; }

        public CheckListItem(string label)
        {
            Label = label;
            IsSelected = false; // Default to not selected
        }

        public override string ToString()
        {
            return Label;
        }
    }
    
}
