using MicrosoftToDo.Models;
using MicrosoftToDo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicrosoftToDo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ExpandFunc();
            this.DataContext = new MainViewModel();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<TaskInfo>(this,"Expand",ExpandFunc);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (this.NewTaskInput.Text == null) return;
                var Detail = this.NewTaskInput.Text;
                MainViewModel model = (MainViewModel)this.DataContext;
                model.TaskInfoAdd(Detail);
                this.NewTaskInput.Text = string.Empty;
            }
        }

        private void ExpandFunc(TaskInfo task)
        {
            var GridCol = this.RightGridCol.ColumnDefinitions;
            if (GridCol[1].Width==new GridLength(0))
            {
                GridCol[1].Width = new GridLength(240);
                this.ButtonNo1.Foreground = this.ButtonNo2.Foreground = this.ButtonNo3.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                GridCol[1].Width = new GridLength(0);
                this.ButtonNo1.Foreground = this.ButtonNo2.Foreground = this.ButtonNo3.Foreground = new SolidColorBrush(Colors.White);
            }
        }
    }
}
