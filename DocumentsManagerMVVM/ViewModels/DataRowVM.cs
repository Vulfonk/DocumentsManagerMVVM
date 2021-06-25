using System;

namespace DocumentsManagerMVVM.ViewModels
{
    /// <summary>
    /// ViewModel для объектов приложения 
    /// </summary>
    public class DataRowVM : BaseViewModel
    {
        /// <summary>
        /// Объект приложения
        /// </summary>
        private ISubject subject;

        public DataRowVM(ISubject sub)
        {
            subject = sub;
            model.AddSubject(subject);
            sub.NameChanged += SubjectNameChangedHandler;
        }

        private void SubjectNameChangedHandler(object sender, EventArgs e)
        {
            OnPropertyChanged("Name");
        }

        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name 
        { 
            get => subject.Name; 
        }

        /// <summary>
        /// Тип объекта 
        /// </summary>
        public string Type
        {
            get
            {
                if (subject is Document)
                    return "Документ";
                else if (subject is Task)
                    return "Задача";
                else
                    throw new Exception();
            }
        }

        private void ClickOpenSubjectHandler(object sender)
        {
            if (subject is Document)
            {
                new DocumentCardWindow()
                {
                    DataContext = new DocumentCardVM(subject as Document)
                }.Show();
            }
            else if (subject is Task)
            {
                new TaskCardWindow()
                {
                    DataContext = new TaskCardVM(subject as Task)
                }.Show();
            }
        }

        /// <summary>
        /// Команда открытия объекта
        /// </summary>
        public DelegateCommand ClickOpenSubject
        {
            get => new DelegateCommand(ClickOpenSubjectHandler);
        }
    }
}
