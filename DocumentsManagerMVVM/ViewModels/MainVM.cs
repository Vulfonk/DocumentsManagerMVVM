using System.Collections.ObjectModel;

namespace DocumentsManagerMVVM.ViewModels
{
    /// <summary>
    /// ViewModel основного окна
    /// </summary>
    public class MainVM : BaseViewModel
    {
        /// <summary>
        /// Создает окно карточки документа
        /// </summary>
        /// <param name="sender"></param>
        private void CreateDocumentCard(object sender)
        {
            new DocumentCardWindow() 
            { 
                DataContext = new DocumentCardVM()
            }.Show();
        }

        /// <summary>
        /// Создает окно карточки задачи
        /// </summary>
        /// <param name="sender"></param>
        private void CreateTaskCard(object sender)
        {
            new TaskCardWindow() 
            { 
                DataContext=new TaskCardVM() 
            }.Show();
        }

        /// <summary>
        /// Команда добавления документа
        /// </summary>
        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(CreateDocumentCard);
        }

        /// <summary>
        /// Команда добавления задачи
        /// </summary>
        public DelegateCommand ClickAddTask
        {
            get => new DelegateCommand(CreateTaskCard);
        }

        /// <summary>
        /// Коллекция отображаемых объектов
        /// </summary>
        public ObservableCollection<DataRowVM> Subjects 
        { 
            get => dataRowSubjects;
            set => dataRowSubjects = value;
        }
    }
}
