using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Models
{
    public class NameList : ObservableCollection<NameListItem>
    {
        public string StartingLetter { get; set; }
    }
}
