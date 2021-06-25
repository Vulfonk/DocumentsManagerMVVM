using System.Collections.ObjectModel;
using System.ComponentModel;


namespace DocumentsManagerMVVM.ViewModels
{
    /// <summary>
    /// Представляет базовую ViewModel приложения, содержащую в себе Модель
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Модель приложения
        /// </summary>
        protected static Model model = new Model();

        /// <summary>
        /// Коллекция отображаемых объектов
        /// </summary>
        protected static ObservableCollection<DataRowVM> dataRowSubjects = new ObservableCollection<DataRowVM>();

        /// <summary>
        /// Генерирует событие изменения свойства
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Происходит при изменении свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
