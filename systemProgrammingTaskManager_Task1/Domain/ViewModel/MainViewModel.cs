using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using systemProgrammingTaskManager_Task1.Domain.RelayCommands;

namespace systemProgrammingTaskManager_Task1.Domain.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        //public Process[] AllProcess { get; set; }
        private ListView ListView { get; set; }
        private string word;

        public string Word
        {
            get { return word; }
            set { word = value;OnPropertyChanged(); }
        }
        private int index;

        public int Index
        {
            get { return index; }
            set { index = value;OnPropertyChanged(); }
        }


        private List<Process> allprocess;

        public List<Process> AllProcess
        {
            get { return allprocess; }
            set { allprocess = value;OnPropertyChanged(); }
        }


        private Process currentProcess;

        public Process CurrentProcess
        {
            get { return currentProcess; }
            set { currentProcess = value;OnPropertyChanged(); }
        }

       
        

        public RelayCommand AddProcess { get; set; }
        public RelayCommand EndProcess { get; set; }
        public RelayCommand FindProcess { get; set; }
        public MainViewModel(ListView listView)
        {
            ListView = listView;
            AllProcess = Process.GetProcesses().ToList();
            Process process = new Process();

            DispatcherTimer dispatcherTimer = new DispatcherTimer(); ;
            dispatcherTimer.Tick += OnTimerEvent;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 4);
            dispatcherTimer.Start();


            AddProcess = new RelayCommand(o =>
            {
                Process.Start(Word);
                Word = string.Empty;
            });
            EndProcess = new RelayCommand(o =>
            {
                CurrentProcess.Kill();
            });
            FindProcess = new RelayCommand(o =>
            {
                var process1 = AllProcess.FirstOrDefault((p) => p.ProcessName == Word);
                if (process1 != null)
                {
                    MessageBox.Show(process1.Id.ToString());
                    CurrentProcess = process1;
                    ListView.ScrollIntoView(process1);
                }
                else
                {
                    MessageBox.Show("This Process Isnt Exist");
                }
            });
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            int index2 = Index;


            AllProcess= Process.GetProcesses().ToList();
            
            Index= index2;
        }

        
    }
}
