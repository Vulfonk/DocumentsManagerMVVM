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
        private bool isSignature = false;

        public void Subscribe()
        {
            digitalSignature = Guid.NewGuid();
            isSignature = true;
        }

        public string Name
        {
            get => name;
            set
            {
                if (isSignature)
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
                if (isSignature)
                    throw new Exception();
                else
                    bodyText = value;
            }
        }

        public Guid DigitalSignature
        {
            get => digitalSignature;
        }

        public uint Identifier
        {
            get => id;
            set
            {
                if (isSignature)
                    throw new Exception();
                else
                    id = value;
            }
        }
    }
}
