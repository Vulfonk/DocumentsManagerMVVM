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
        private void NewWindow(object sender)
        {
            new DocumentCardWindow().Show();
        }
        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(NewWindow);
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

    public abstract class Subject
    {
        static protected uint subId = 0;
        protected string name;
        protected string bodyText;
        protected uint id;

        public Subject(string name, string text)
        {
            this.Identifier = subId++;
            this.name = name;
            this.bodyText = text;
        }
        public uint Identifier
        {
            get => id;
            protected set => id = value;
        }

    }

    public class Document : Subject
    {
        private Guid digitalSignature;

        public Document(string name, string text) : base(name, text) { }

        public string Name
        {
            get => name;
            set
            {
                if (digitalSignature != null)
                    throw new Exception();
                else
                    name = value;
            }
        }

        public string BodyText
        {
            get => bodyText;
            set
            {
                if (digitalSignature != null)
                    throw new Exception();
                else
                    bodyText = value;
            }
        }

        public Guid DigitalSignature
        {
            get => digitalSignature;
            set
            {
                if (digitalSignature != null)
                    throw new Exception();
                else
                    digitalSignature = value;
            }
        }
    }

    public enum State
    {
        InProcess,
        Complete,
    }

    public class Task : Subject
    {
        public Task(string name, string text) : base(name, text) { }

        public string Name { get => name; set => name = value; }
        public string BodyText { get => bodyText; set => bodyText = value; }
        public State State { get; set; }
    }

    public class Model
    {
        public List<Subject> Objects { get; }

        public void AddEntity(Subject obj)
        {
            if (Objects.Where(o => o.Identifier == obj.Identifier).Count() != 0)
                throw new Exception();
            else
                Objects.Add(obj);
        }
    }
}
