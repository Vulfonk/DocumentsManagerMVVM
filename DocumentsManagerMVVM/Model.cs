using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM
{
    public class Model
    {
        public List<ISubject> Subjects { get; }

        public void AddSubject(ISubject sub)
        {
            if (Subjects.Where(o => o.Identifier == sub.Identifier).Count() != 0)
                throw new Exception();
            else
                Subjects.Add(sub);
        }
    }
}
