using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MVVM_study.ViewModel;


namespace MVVM_study
{
    public class StudentFactory
    {
        ObservableCollection<Student> students = new ObservableCollection<Student>();
        public ObservableCollection<Student> GetAllStudent()
        {
            students.Add(new Student() { Grade = "1", Cclass = "3", Name = "홍XX", No = "1010", Score = "A" });
            students.Add(new Student() { Grade = "2", Cclass = "2", Name = "이XX", No = "1020", Score = "B" });
            students.Add(new Student() { Grade = "1", Cclass = "1", Name = "이XX", No = "1030", Score = "A" });
            students.Add(new Student() { Grade = "3", Cclass = "4", Name = "김XX", No = "1040", Score = "D" });
            students.Add(new Student() { Grade = "1", Cclass = "5", Name = "김XX", No = "1050", Score = "B" });
            students.Add(new Student() { Grade = "2", Cclass = "2", Name = "주XX", No = "1060", Score = "C" });

            return students;
        }
    }

    public class Student : Notifier
    {
        private string grade;
        private string cclass;
        private string no;
        private string name;
        private string score;

        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value;
                OnPropertyChanged("Grade");
            }
        }
        public string Cclass
        {
            get { return cclass; }
            set
            {
                cclass = value;
                OnPropertyChanged("Cclass");
            }
        }
        public string No
        {
            get { return no; }
            set
            {
                no = value;
                OnPropertyChanged("No");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }
    }

}
