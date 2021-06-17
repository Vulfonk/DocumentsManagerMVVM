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
        public DocCardVM()
        {

        }
        
        private DelegateCommand clickButtonSubscribe;

        private void SubscribeDocument(object sender)
        {
            Document createdDoc = new Document("asd", "sadasd", 123, Guid.NewGuid());
            model.AddSubject(createdDoc);
            this.sourceData.Add(new DataRowVM(createdDoc));
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(SubscribeDocument);
        }
     
        private uint id;
        public uint Identifier { get => id; set => id = value; }

    }

}
