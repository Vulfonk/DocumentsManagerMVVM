using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerMVVM
{

    public interface ISubject
    {
        uint Identifier { get; set; }
        string Name { get; set; }
        string BodyText { get; set; }
        
        event EventHandler NameChanged;

    }

}
