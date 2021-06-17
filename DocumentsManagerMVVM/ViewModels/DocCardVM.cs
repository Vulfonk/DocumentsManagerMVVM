using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM.ViewModels
{

    public class DocCardVM : INotifyPropertyChanged
    {
        private Model model;
        public DocCardVM(Model model)
        {
            this.model = model;
        }
        private EventHandler documentIsAdded;

        public event EventHandler DocumentIsAdded
        {
            add
            {
                documentIsAdded += value;
            }
            remove
            {
                documentIsAdded -= value;
            }
        }

        private DelegateCommand clickButtonSubscribe;

        public event PropertyChangedEventHandler PropertyChanged;
        private void SubscribeDocument(object sender)
        {
            Document createdDoc = new Document("asd", "sadasd", 123, Guid.NewGuid());
            model.AddSubject(createdDoc);
            documentIsAdded?.Invoke(createdDoc, null);
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(SubscribeDocument);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private uint id;
        public uint Identifier { get => id; set => id = value; }

    }

}
