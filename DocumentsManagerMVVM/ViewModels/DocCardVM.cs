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
        private Document document;

        public string Name 
        { 
            get => document.Name; 
            set => document.Name = value; 
        }

        public uint Identifier 
        { 
            get => document.Identifier; 
            set => document.Identifier = value; 
        }

        public string BodyText 
        { 
            get => document.BodyText; 
            set => document.BodyText = value; 
        }

        public string Signature
        {
            get
            {
                if (isSignatureEmpty())
                    return "";
                else
                    return document.DigitalSignature.ToString();
            }
        }

        public DocCardVM()
        {
            this.document = new Document();

            subjects.Add(new DataRowVM(document));

        }

        public DocCardVM(Document doc)
        {
            this.document = doc;
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
            document.Subscribe();

            OnPropertyChanged("Signature");
            OnPropertyChanged("IsSignatured");

            model.AddSubject(document);
        }

        private bool isSignatureEmpty(object sender = null)
        {
            return document.DigitalSignature == Guid.Parse("00000000-0000-0000-0000-000000000000");
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(
                SubscribeDocument,
                isSignatureEmpty);
        }
    }

}
