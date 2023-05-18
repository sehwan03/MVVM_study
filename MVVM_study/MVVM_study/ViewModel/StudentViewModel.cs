using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVM_study.ViewModel
{
    public class StudentViewModel : Notifier
    {
        private ObservableCollection<Student> foundStudents;
        public ObservableCollection<Student> FoundStudents
        {
            get { return foundStudents; }
            set
            {
                foundStudents = value;
                OnPropertyChanged("FoundStudents");
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        public StudentViewModel()
        {
        }

        StudentFactory factory = new StudentFactory();

        private ICommand readCommand;
        public ICommand ReadCommand
        {
            get
            {
                if (readCommand == null)
                {
                    readCommand = new DelegateCommand(Read);
                }
                return readCommand;
            }
        }

        private void Read()
        {
            FoundStudents = factory.GetAllStudent();
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;

        public DelegateCommand(Action execute) : this(execute, null) { }    // 인자 1개 전용 -> 두 번째 값을 버리고 첫 번째 값만 사용
        public DelegateCommand(Action execute, Func<bool> canExecute)       // 인자 2개 전용 -> 두 값 모두 사용
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        public void Execute(object parameter)
        {
            this.execute();
        }

        public void RaiseCanExcuteChange()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
