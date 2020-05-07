using GalaSoft.MvvmLight;
using MicrosoftToDo.Models;
using System.Collections.ObjectModel;

namespace MicrosoftToDo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<MenuModel> MenuModels { get; set; }
        

        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            MenuModels.Add(new MenuModel() { Title="我的一天",Icon= "\xe619",Color= "#218868",Display=false});
            MenuModels.Add(new MenuModel() { Title="重要",Icon= "\xe61d",Color= "#CD0000" });
            MenuModels.Add(new MenuModel() { Title= "计划日程", Icon= "\xe61e",Color= "#218868" });
            MenuModels.Add(new MenuModel() { Title="已分配",Icon= "\xe622",Color= "#CD0000" });
            MenuModels.Add(new MenuModel() { Title="任务",Icon= "\xe61c",Color= "#218868" });
            menuModel = MenuModels[0];
            SlectedCommand = new GalaSoft.MvvmLight.Command.RelayCommand<MenuModel>(t=>Select(t));
            SelectedTask = new GalaSoft.MvvmLight.Command.RelayCommand<TaskInfo>(t => TaskSelected(t));
        }

        public GalaSoft.MvvmLight.Command.RelayCommand<MenuModel> SlectedCommand { get; set; }
        public GalaSoft.MvvmLight.Command.RelayCommand<TaskInfo> SelectedTask { get; set; }

        private MenuModel _menuModel;
        public MenuModel menuModel
        {
            get { return _menuModel; }
            set { _menuModel = value;RaisePropertyChanged(); }
        }

        private TaskInfo info;
        public TaskInfo Info
        {
            get { return info; }
            set { info = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<TaskInfo> _TaskInfos=new ObservableCollection<TaskInfo>();
        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return _TaskInfos; }
            set { _TaskInfos = value; RaisePropertyChanged(); }
        }

        public void TaskInfoAdd(string Details)
        {
            TaskInfos.Add(new TaskInfo(){Detail = Details});
        }

        public void Select(MenuModel model)
        {
            menuModel = model;
        }

        public void TaskSelected(TaskInfo task)
        {
            Info = task;
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(task,"Expand");
        }
    }
}