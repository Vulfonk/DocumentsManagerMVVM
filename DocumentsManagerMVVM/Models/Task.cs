using System;

namespace DocumentsManagerMVVM
{
    /// <summary>
    /// Представляет задачу с состоянием 
    /// </summary>
    public class Task : ISubject
    {
        private uint id;

        private string name;

        private string bodyText;

        public event EventHandler NameChanged;

        /// <summary>
        /// Текущее состояние задачи
        /// </summary>
        public State State { get; set; }
        public uint Identifier 
        {
            get => id; 
            set => id = value; 
        }

        public string Name 
        { 
            get => name;
            set
            {
                name = value;
                NameChanged?.Invoke(this, null);
            }
        }
        public string BodyText 
        { 
            get => bodyText; 
            set => bodyText = value; 
        }
    }
    
    /// <summary>
    /// Указывает на состояние
    /// </summary>
    public enum State
    {
        /// <summary>
        /// В работе
        /// </summary>
        InProcess,
        /// <summary>
        /// Выполнена
        /// </summary>
        Complete,
    }
}
