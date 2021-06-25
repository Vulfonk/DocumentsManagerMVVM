using System;

namespace DocumentsManagerMVVM
{
    /// <summary>
    /// Представляет документ с цифровой подписью
    /// </summary>
    public class Document : ISubject
    {
        private Guid digitalSignature;

        /// <summary>
        /// Цифровая подпись
        /// </summary>
        public Guid DigitalSignature { get => digitalSignature; }


        private uint identifier;
        
        public uint Identifier
        {
            get => identifier;
            set
            {
                if (isSignature)
                    throw new Exception();
                else
                    identifier = value;
            }
        }

        private string name;

        private string bodyText;

        private bool isSignature = false;

        /// <summary>
        /// Возвращает true, если документ подписан
        /// </summary>
        public bool IsSignature { get => isSignature; }

        public event EventHandler NameChanged;

        /// <summary>
        /// Подписывает документ
        /// </summary>
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
                {
                    throw new Exception();
                }
                else
                {
                    name = value;
                    NameChanged?.Invoke(this, null);
                }
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


    }
}
