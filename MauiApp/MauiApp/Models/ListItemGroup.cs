using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Models
{
    public class ListItemGroup : ObservableCollection<ListItem>
    {
        public string Category { get; set; }

        public string Location { get; set; }

        public ListItemGroup Clone()
        {
            var returnValue = new ListItemGroup();
            returnValue.Category = this.Category;
            returnValue.Location = this.Location;
            foreach (var item in this)
            {
                returnValue.Add(item);
            }
            return returnValue;
        }
    }
}
