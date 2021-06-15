using System.ComponentModel;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Input;
using DocumentsManagerMVVM.DocumentModel;


namespace DocumentsManagerMVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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
        public MainVM()
        {
            sourceData = new ObservableCollection<DataRowVM>();
        }
        public ObservableCollection<DataRowVM> sourceData { get; set; }

        private DelegateCommand clickAddDoc;

        private void CreateDocumentCard(object sender)
        {
            new DocumentCardWindow().Show();
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
        public DataRowVM(Subject sub)
        {
            if (sub is Document)
                Type = "Документ";
            else if (sub is Task)
                Type = "Задача";
            else
                throw new Exception();
        }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
