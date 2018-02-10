using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleMVVMExample
{
    public class TestViewModel : ObservableObject
    {
        private ObservableCollection<SharedModel> _List;
        public ObservableCollection<SharedModel> List
        {
            get { return _List; }
            set { _List = value; OnChanged(); }
        }

        private ICommand _GetSelectedCheckBoxesCommand;
        public ICommand GetSelectedCheckBoxesCommand
        {
            get
            {
                if (_GetSelectedCheckBoxesCommand == null)
                    _GetSelectedCheckBoxesCommand = new ExecutePath(param => GetSelectedCheckBoxes());

                return _GetSelectedCheckBoxesCommand;
            }
        }

        public TestViewModel()
        {
            List = new ObservableCollection<SharedModel>()
            {
                new SharedModel()
                {
                    Name = "A1",
                    IsSelected = false
                },

                new SharedModel()
                {
                    Name = "A2",
                    IsSelected = false
                }

            };
        }

        public List<string> GetSelectedCheckBoxes()
        {
            return List.Where(x => x.IsSelected == true).Select(x => x.Name).ToList();
        }
    }
}
