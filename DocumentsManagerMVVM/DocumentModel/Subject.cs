using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM.DocumentModel
{

    public abstract class Subject
    {
        static protected uint subId = 0;
        protected string name;
        protected string bodyText;
        protected uint id;

        public Subject(string name, string text)
        {
            this.Identifier = subId++;
            this.name = name;
            this.bodyText = text;
        }
        public uint Identifier
        {
            get => id;
            protected set => id = value;
        }

    }

}
