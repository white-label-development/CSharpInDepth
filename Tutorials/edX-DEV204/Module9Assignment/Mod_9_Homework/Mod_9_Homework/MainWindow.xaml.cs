using System.Collections.Generic;
using System.Windows;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }
        public int CurrentPosition { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new List<Student>();
            CurrentPosition = 0;
            EnablePagingButtons();
        }

        private void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            Students.Add(new Student{Forename = txtFirstName.Text, Surname = txtLastName.Text, City = txtCity.Text});
            EnablePagingButtons();
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
        }

        private void PopForm()
        {
            var studentAtPosition = Students[CurrentPosition];
            txtFirstName.Text = studentAtPosition.Forename;
            txtLastName.Text = studentAtPosition.Surname;
            txtCity.Text = studentAtPosition.City;
        }

        private void EnablePagingButtons()
        {
            if (Students.Count > 1)
            {
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
            }
            else
            {
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = false;
            }            
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            CurrentPosition--;
            if (CurrentPosition < 0)
            {
                CurrentPosition = Students.Count-1;
            }           
            PopForm();
           
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            CurrentPosition++;
            if (CurrentPosition >= Students.Count)
            {
                CurrentPosition = 0;
            }            
            PopForm();
        }
    }
}
