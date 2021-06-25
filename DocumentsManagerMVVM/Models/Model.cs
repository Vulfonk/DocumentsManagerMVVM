using System.Collections.Generic;
using System.Linq;
namespace DocumentsManagerMVVM
{
    /// <summary>
    /// Предсавляет модель работы с коллекцией объектов приложения
    /// </summary>
    public class Model
    {
        private List<ISubject> subjects = new List<ISubject>();

        private uint currentId;

        /// <summary>
        /// Добавляет объект приложения в коллекцию модели
        /// </summary>
        /// <param name="subject"> Объект </param>
        public void AddSubject(ISubject subject)
        {
            subject.Identifier = currentId++;
            subjects.Add(subject);
        }
    }
}
