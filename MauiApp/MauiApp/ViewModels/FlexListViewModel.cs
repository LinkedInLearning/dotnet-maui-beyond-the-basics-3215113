using MauiBeyond.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.ViewModels
{
    public class FlexListViewModel
    {
        public FlexListViewModel()
        {
            LoadList();
        }

        private ObservableCollection<FlexListItem> _flexList;

        public ObservableCollection<FlexListItem> FlexList
        {
            get { return _flexList; }
        }

        private void LoadList()
        {
            _flexList = new ObservableCollection<FlexListItem>
            {
                new FlexListItem
                {
                    Name = "Marlee Moore",
                    Title = "SCRUM Master"
                },
                new FlexListItem
                {
                    Name = "Zoe Callahan",
                    Title = "Product Owner"
                },
                new FlexListItem
                {
                    Name = "Bianca Trejo",
                    Title = "UX Designer"
                },
                new FlexListItem
                {
                    Name = "Penny Weiss",
                    Title = "Developer"
                },
                new FlexListItem
                {
                    Name = "Madeleine Brock",
                    Title = "Developer"
                },
                new FlexListItem
                {
                    Name = "Karina Williamson",
                    Title = "QA Analyst"
                },
            };
        }
    }
}
