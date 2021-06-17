using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM.ViewModels
{
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
        private void openSubject(object sender)
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
            get => new DelegateCommand(openSubject);
        }
    }
}
