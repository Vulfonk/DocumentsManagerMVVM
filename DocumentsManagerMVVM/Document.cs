using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM
{
    public class Document : ISubject
    {
        private Guid digitalSignature;
        private uint id;
        private string name;
        private string bodyText;

        public Document(string name, string text, uint id, Guid guid)
        {
            this.Identifier = id;
            this.name = name;
            this.bodyText = text;
            this.DigitalSignature = guid;
        }

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

        public uint Identifier
        {
            get => id;
            set
            {
                if (digitalSignature != null)
                    throw new Exception();
                else
                    id = value;
            }
        }
    }
}
