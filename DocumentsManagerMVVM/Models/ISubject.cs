using System;

namespace DocumentsManagerMVVM
{
    /// <summary>
    /// Представляет объекты, хранящиеся в памяти приложения
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        uint Identifier { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Тело
        /// </summary>
        string BodyText { get; set; }

        /// <summary>
        /// Происходит при изменении имени
        /// </summary>
        event EventHandler NameChanged;

    }

    public class ObservableSubject : ISubject
    {
        private ISubject subject;

        public ISubject Subject 
        { 
            get => subject; 
            set => subject = value; 
        }

        public event EventHandler NameChanged;

        public ObservableSubject(ISubject subject)
        {
            this.subject = subject;
        }

        public uint Identifier
        {
            get => this.subject.Identifier;
            set => this.subject.Identifier = value;
        }
        public string Name
        {
            get => this.subject.Name;
            set
            {
                this.NameChanged?.Invoke(this, null);
                this.subject.Name = value;
            }
        }
        public string BodyText
        {
            get => this.subject.BodyText;
            set => this.subject.BodyText = value;
        }

    }

}
