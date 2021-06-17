﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DocumentsManagerMVVM.ViewModels
{
    public class MainVM : BaseViewModel
    {
        public MainVM()
        {
            model = new Model();
            subjects = new ObservableCollection<DataRowVM>();
        }

        private DelegateCommand clickAddDoc;

        private void CreateDocumentCard(object sender)
        {
            var docCard = new DocumentCardWindow();
            docCard.Show();
        }

        private void CreateTaskCard(object sender)
        {
            new TaskCardWindow().Show();
        }

        public DelegateCommand ClickAddDoc
        {
            get => new DelegateCommand(CreateDocumentCard);
        }

        public DelegateCommand ClickAddTask
        {
            get => new DelegateCommand(CreateTaskCard);
        }

        public ObservableCollection<DataRowVM> Subjects { get => subjects; set => subjects = value; }
    }


}
