using System.ComponentModel;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Input;

namespace DocumentsManagerMVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class DelegateCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute = null;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

    public class MainVM : INotifyPropertyChanged
    {
        public Model MainModel { get; set; }
        public MainVM()
        {
            MainModel = new Model();
            sourceData = new ObservableCollection<DataRowVM>();
        }
        public ObservableCollection<DataRowVM> sourceData { get; set; }

        private DelegateCommand clickAddDoc;

        private void CreateDocumentCard(object sender)
        {
            var docCard = new DocumentCardWindow();
            docCard.Show();
        }

        private void CreateTaskCard(object sender)
        {
            new TaskCardWindow().Show();
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(CreateDocumentCard);
        }

        public DelegateCommand ClickAddTask
        {
            get => new DelegateCommand(CreateTaskCard);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }

    public class DataRowVM
    {
        private ISubject subject;
        public DataRowVM(ISubject sub)
        {
            subject = sub;

        }
        public string Name { get => subject.Name; }
        public string Type
        {
            get
            {
                if (subject is Document)
                    return "Документ";
                else if (subject is Task)
                    return "Задача";
                else
                    throw new Exception();
            }
        }
    }
}
