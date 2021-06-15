using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM
{
    public class Task : ISubject
    {
        private uint id;
        private string name;
        private string bodyText;

        public Task(string name, string text, uint id)
        {
            this.Identifier = id;
            this.name = name;
            this.bodyText = text;
        }

        public State State { get; set; }
        public uint Identifier { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string BodyText { get => bodyText; set => bodyText = value; }
    }
    public enum State
    {
        InProcess,
        Complete,
    }
}
