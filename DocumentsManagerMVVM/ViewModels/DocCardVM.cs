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
        private Document doc;

        public string Name { get => doc.Name; set => doc.Name = value; }

        public uint Identifier { get => doc.Identifier; set => doc.Identifier = value; }

        public string BodyText { get => doc.BodyText; set => doc.BodyText = value; }

        public string Signature
        {
            get
            {
                if (isSignatureEmpty())
                    return "";
                else
                    return doc.DigitalSignature.ToString();
            }
        }

        public DocCardVM()
        {
            doc = new Document();
        }
        public bool IsSignatured
        {
            get
            {
                return !isSignatureEmpty();
            }
        }
        private void SubscribeDocument(object sender)
        {
            doc.Subscribe();

            OnPropertyChanged("Signature");
            OnPropertyChanged("IsSignatured");

            model.AddSubject(doc);
            subjects.Add(new DataRowVM(doc));
        }

        private bool isSignatureEmpty(object sender = null)
        {
            return doc.DigitalSignature == Guid.Parse("00000000-0000-0000-0000-000000000000");
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(
                SubscribeDocument,
                isSignatureEmpty);
        }
    }

}
