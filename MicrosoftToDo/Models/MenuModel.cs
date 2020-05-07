using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftToDo.Models
{
    public class MenuModel: ViewModelBase
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public bool Display { get; set; } = true;
        public bool InitChecked { get; set; } = false;
        private ObservableCollection<TaskInfo> _TaskInfos;
        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return _TaskInfos; }
            set { _TaskInfos = value; RaisePropertyChanged(); }
        }


    }

    public class TaskInfo
    {
        public string Detail { get; set; }
    }
}
