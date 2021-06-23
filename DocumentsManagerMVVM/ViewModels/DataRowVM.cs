using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DocumentsManagerMVVM.ViewModels
{
    public class DataRowVM :INotifyPropertyChanged
    {
        private ISubject subject;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataRowVM(ISubject sub)
        {
            subject = sub;
            sub.NameChanged += SubjectNameChangedHandler;
        }

        private void SubjectNameChangedHandler(object sender, EventArgs e)
        {
            OnPropertyChanged("Name");
        }

        public string Name 
        { 
            get => subject.Name; 
        }

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
        private void OpenSubject(object sender)
        {
            if (subject is Document)
            {
                var docCard = new DocumentCardWindow()
                {
                    DataContext = new DocCardVM(subject as Document)
                };
                docCard.Show();
            }
        }
        public DelegateCommand ClickOpenSubject
        {
            get => new DelegateCommand(OpenSubject);
        }
    }
}
