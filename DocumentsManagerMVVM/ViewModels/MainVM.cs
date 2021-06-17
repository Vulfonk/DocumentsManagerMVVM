using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DocumentsManagerMVVM.ViewModels
{
    public class MainVM : BaseViewModel
    {
        public MainVM()
        {
            model = new Model();
            sourceData = new ObservableCollection<DataRowVM>();
        }

        private DelegateCommand clickAddDoc;

        private void DocumentAddHandler(object sender, EventArgs e)
        {
            sourceData.Add(new DataRowVM(sender as ISubject));
        }

        private void CreateDocumentCard(object sender)
        {
            var docVm = new DocCardVM();
            docVm.DocumentIsAdded += DocumentAddHandler;
            var docCard = new DocumentCardWindow()
            {
                DataContext = docVm
            };
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
}
