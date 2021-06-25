
namespace DocumentsManagerMVVM.ViewModels
{
    /// <summary>
    /// ViewModel карточки документа
    /// </summary>
    public class DocumentCardVM : BaseViewModel
    {
        /// <summary>
        /// Документ
        /// </summary>
        private Document document;

        /// <summary>
        /// Имя документа
        /// </summary>
        public string Name
        {
            get => this.document.Name;
            set => this.document.Name = value;
        }

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public uint Identifier
        {
            get => this.document.Identifier;
        }

        /// <summary>
        /// Текст документа
        /// </summary>
        public string BodyText
        {
            get => this.document.BodyText;
            set => this.document.BodyText = value;
        }

        /// <summary>
        /// Цифровая подпись документа
        /// </summary>
        public string Signature
        {
            get
            {
                if (isNotSignatureDocument())
                    return "";
                else
                    return document.DigitalSignature.ToString();
            }
        }

        public DocumentCardVM()
        {
            this.document = new Document();
            dataRowSubjects.Add(new DataRowVM(document));
        }

        public DocumentCardVM(Document document) => this.document = document;

        /// <summary>
        /// Возвращает true, если документ подписан
        /// </summary>
        public bool IsSignatured { get => !isNotSignatureDocument(); }

        // Требуется для инициализации команды
        private bool isNotSignatureDocument(object sender = null) => !this.document.IsSignature;

        private void ClickSubscribeDocumentHandler(object sender)
        {
            this.document.Subscribe();
            OnPropertyChanged("Signature");
            OnPropertyChanged("IsSignatured");
        }

        /// <summary>
        /// Команда подписи документа
        /// </summary>
        public DelegateCommand ClickSubscribeDocument 
        { 
            get => new DelegateCommand(ClickSubscribeDocumentHandler, isNotSignatureDocument); 
        }
    }
}