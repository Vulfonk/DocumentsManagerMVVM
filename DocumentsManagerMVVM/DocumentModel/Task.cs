using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM.DocumentModel
{
    public class Task : Subject
    {
        public Task(string name, string text) : base(name, text) { }

        public string Name { get => name; set => name = value; }
        public string BodyText { get => bodyText; set => bodyText = value; }
        public State State { get; set; }
    }
    public enum State
    {
        InProcess,
        Complete,
    }
}
