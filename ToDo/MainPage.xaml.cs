using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo;
using Xamarin.Forms;

namespace ToDo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            List<Job> list = App.MyDB.GetItems().ToList();

            if (list.Count() != 0)
                JobInformation.Text = "Все задачи";
            else
                JobInformation.Text = "Нет никаких задач";
            listOfJobs.ItemsSource = list;
            base.OnAppearing();
        }
        // выбрать задание
        private async void SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            Job pickedJob = (Job)e.SelectedItem;
            UpdateJob updateJob = new UpdateJob();
            updateJob.BindingContext = pickedJob;
            await Navigation.PushAsync(updateJob);
        }
        // добавить задание
        private async void AddJob(object sender, EventArgs e)
        {
            Job job = new Job();
            AddJob addJob = new AddJob();
            addJob.BindingContext = job;
            await Navigation.PushAsync(addJob);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            var button = (Button)sender;

            List<Job> plannedJobs = new List<Job>();
            List<Job> doneJobs = new List<Job>();
            List<Job> todaysJobs = new List<Job>();

            List<Job> Jobs = App.dataBase.GetItems().ToList();

            foreach (var job in Jobs)
            {
                if (job.Done)
                    doneJobs.Add(job);
                else
                    plannedJobs.Add(job);
                if (job.Date_Time.Date == DateTime.Now.Date)
                {
                    todaysJobs.Add(job);
                }
            }


            if (button.ClassId == "Done")
            {
                if (doneJobs.Count() != 0)
                    JobInformation.Text = "Список завершенных задач";
                else
                    JobInformation.Text = "Нет завершенных задач";
                listOfJobs.ItemsSource = doneJobs;
            }
            else if (button.ClassId == "Added")
            {
                if (plannedJobs.Count() != 0)
                    JobInformation.Text = "Список текущих задач";
                else
                    JobInformation.Text = "Нет текущих задач";
                listOfJobs.ItemsSource = plannedJobs;
            }
            else if (button.ClassId == "All")
            {
                if (Jobs.Count() != 0)
                    JobInformation.Text = "Список всех задач";
                else
                    JobInformation.Text = "Нет никаких задач";
                listOfJobs.ItemsSource = Jobs;
            }
            else if (button.ClassId == "Today")
            {
                if (Jobs.Count() != 0)
                    JobInformation.Text = "Список задач на сегодня";
                else
                    JobInformation.Text = "Нет задач на сегодня! Вы свободны!";
                listOfJobs.ItemsSource = todaysJobs;
            }
        }
    }
}