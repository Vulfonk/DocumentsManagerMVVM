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

        private Document Doc
        {
            get
            {
                DocumentChanged?.Invoke(this, null);
                return doc;
            }
        }

        public string Name { get => Doc.Name; set => Doc.Name = value; }

        public uint Identifier { get => Doc.Identifier; set => Doc.Identifier = value; }

        public string BodyText { get => Doc.BodyText; set => Doc.BodyText = value; }

        public string Signature
        {
            get
            {
                if (isSignatureEmpty())
                    return "";
                else
                    return Doc.DigitalSignature.ToString();
            }
        }

        event EventHandler DocumentChanged;

        public DocCardVM()
        {
            this.doc = new Document();
        }

        public DocCardVM(Document doc)
        {
            this.doc = doc;
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
