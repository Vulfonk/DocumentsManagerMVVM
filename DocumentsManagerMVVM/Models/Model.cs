using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM
{
    public class Model
    {
        private List<ISubject> subjects = new List<ISubject>();
        public List<ISubject> Subjects { get => subjects;}
        public void AddSubject(ISubject sub)
        {
            if (subjects.Where(o => o.Identifier == sub.Identifier).Count() != 0)
                throw new Exception();
            else
                subjects.Add(sub);
        }
        public void EditSubject(ISubject sub)
        {
            var index = subjects.FindIndex(o => o.Identifier == sub.Identifier);
            subjects[index] = sub;
        }
    }
}
