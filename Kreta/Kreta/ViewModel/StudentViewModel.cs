using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace Kreta.ViewModel
{
    public partial class StudentViewModel : ObservableObject
    {
        [ObservableProperty]
        private Student _student = new Student();

        [ObservableProperty]
        private List<String> _educationLevels = new List<String>() { "érettségi", "szakmai érettségi", "szakmai vizsga" };

        [ObservableProperty]
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();

        public StudentViewModel()
        {
            _student.BirthsDay = DateTime.Now.AddYears(-14);
        }

        [RelayCommand]
        public void DoAddNewStudent(Student newStudent)
        {
            Students.Add(newStudent);
        }

        [RelayCommand]
        public void DoRemoveStudent(Student studentToDelete)
        {
            Students.Remove(studentToDelete);
        }

        [RelayCommand]
        public void DoNewStudent()
        {
            Student = new Student();
            Student.BirthsDay = DateTime.Now.AddYears(-14);
            OnPropertyChanged(nameof(Student));
            // az onpropertychanged nem engedi, hogy visszaugorjon a dátum 0001.01.01-re
        }
    }
}
