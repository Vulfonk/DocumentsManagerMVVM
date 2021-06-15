using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DocumentsManagerMVVM
{
    /// <summary>
    /// Логика взаимодействия для DocumentCardWindow.xaml
    /// </summary>
    public partial class DocumentCardWindow : Window
    {
        public DocumentCardWindow()
        {
            InitializeComponent();
        }
    }

    public class DocCardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private uint id;
        public uint Identifier { get => id; set => id = value; }

    }

}
