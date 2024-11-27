using System;
using System.Windows.Forms;

namespace GUI.Component
{
    public class CheckListRenderer : CheckBox, IItemRenderer
    {
        // Implement the render method to handle rendering of each item in the CheckedListBox
        public object GetListCellRendererComponent(CheckedListBox list, object value, int index, bool isSelected, bool hasFocus)
        {
            // Set enabled state based on the list's enabled property
            this.Enabled = list.Enabled;

            // Cast the value to CheckListItem (make sure CheckListItem is defined)
            CheckListItem item = (CheckListItem)value;

            // Set the selection state
            this.Checked = item.IsSelected;

            // Set the font, background, and foreground color to match the list
            this.Font = list.Font;
            this.BackColor = list.BackColor;
            this.ForeColor = list.ForeColor;

            // Set the text of the CheckBox (the string representation of the item)
            this.Text = value.ToString();

            // Return the CheckBox for rendering
            return this;
        }
    }

    // You might have a CheckListItem class like this:
    public class CheckListItem
    {
        public string Text { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    // Assuming you need a custom item renderer interface
    public interface IItemRenderer
    {
        object GetListCellRendererComponent(CheckedListBox list, object value, int index, bool isSelected, bool hasFocus);
    }
}

