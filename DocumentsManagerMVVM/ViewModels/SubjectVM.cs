using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DocumentsManagerMVVM.ViewModels
{
    public class SubjectVM : INotifyPropertyChanged
    {
        private ISubject subject;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SubjectVM(ISubject subject)
        {
            this.subject = subject;
            subject.NameChanged += SubjectNameChangedHandler;
        }

        private void SubjectNameChangedHandler(object sender, EventArgs e)
        {
            OnPropertyChanged("Name");
        }

        public uint Identifier 
        { 
            get => subject.Identifier;
            set => subject.Identifier = value; 
        }

        public string BodyText 
        { 
            get => subject.BodyText; 
            set => subject.BodyText = value; 
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
                    DataContext = new DocCardVM(this)
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
