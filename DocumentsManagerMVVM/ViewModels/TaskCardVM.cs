using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocumentsManagerMVVM.ViewModels
{
    /// <summary>
    /// ViewModel карточки задачи
    /// </summary>
    class TaskCardVM : BaseViewModel
    {
        /// <summary>
        /// Словарь для отображения состояния задачи в строку, выводящуюся пользователю
        /// </summary>
        private static Dictionary<State, string> stateToString = new Dictionary<State, string>()
        {
            [DocumentsManagerMVVM.State.Complete] = "Complete",
            [DocumentsManagerMVVM.State.InProcess] = "InProcess",
        };

        /// <summary>
        /// Словарь для отображения состояния строки, введенной/выбранной пользователем, в задачу
        /// </summary>
        private static Dictionary<string, State> stringToState = new Dictionary<string, State>()
        {
            ["Complete"] = DocumentsManagerMVVM.State.Complete,
            ["InProcess"] = DocumentsManagerMVVM.State.InProcess,
        };

        /// <summary>
        /// Задача
        /// </summary>
        private Task task;

        /// <summary>
        /// Имя задачи
        /// </summary>
        public string Name
        {
            get => task.Name;
            set => task.Name = value;
        }

        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public uint Identifier
        {
            get => task.Identifier;
        }

        /// <summary>
        /// Текст задачи
        /// </summary>
        public string BodyText
        {
            get => task.BodyText;
            set => task.BodyText = value;
        }

        /// <summary>
        /// Текущее состояние задачи
        /// </summary>
        public string State
        {
            //get=> task.State.ToString();
            get => stateToString[task.State];

            //set => task.State = (State)Enum.Parse(typeof(State), value, true);
            set => task.State = stringToState[value];
        }


        public ObservableCollection<string> States { get; }

        public TaskCardVM()
        {
            this.States = new ObservableCollection<string>();

            //foreach (var state in Enum.GetValues(typeof(State)))
            //{
            //    this.States.Add(state.ToString());
            //}

            foreach (var state in stateToString.Values)
            {
                this.States.Add(state);
            }

            this.task = new Task();
            dataRowSubjects.Add(new DataRowVM(task));
        }

        public TaskCardVM(Task doc)
        {
            this.task = doc;
            this.States = new ObservableCollection<string>();

            //foreach (var state in Enum.GetValues(typeof(State)))
            //{
            //    this.States.Add(state.ToString());
            //}

            foreach (var state in stateToString.Values)
            {
                this.States.Add(state);
            }
        }

    }
}
