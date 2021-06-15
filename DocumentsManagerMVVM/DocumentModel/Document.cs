using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM.DocumentModel
{
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
}
