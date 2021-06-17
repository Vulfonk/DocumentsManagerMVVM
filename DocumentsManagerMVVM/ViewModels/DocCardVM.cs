using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM.ViewModels
{

    public class DocCardVM : BaseViewModel
    {
        private string name;
        private string bodyText;
        private uint id;
        private Guid signature;

        public string Name { get => name; set => name = value; }

        public uint Identifier { get => id; set => id = value; }

        public string BodyText { get => bodyText; set => bodyText = value; }

        public string Signature
        {
            get
            {
                if (isSignatureEmpty())
                    return "";
                else
                    return signature.ToString();
            }
        }

        public DocCardVM()
        {

        }
      
        private void SubscribeDocument(object sender)
        {
            signature = Guid.NewGuid();
            OnPropertyChanged("Signature");
            Document createdDoc = new Document(name, bodyText, id, signature);
            model.AddSubject(createdDoc);
            subjects.Add(new DataRowVM(createdDoc));
        }

        private bool isSignatureEmpty(object sender = null)
        {
            return signature == Guid.Parse("00000000-0000-0000-0000-000000000000");
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(
                SubscribeDocument,
                isSignatureEmpty);
        }
    }

}
