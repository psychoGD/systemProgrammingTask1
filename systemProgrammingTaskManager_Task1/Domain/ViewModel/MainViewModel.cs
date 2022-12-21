using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using systemProgrammingTaskManager_Task1.Domain.RelayCommands;

namespace systemProgrammingTaskManager_Task1.Domain.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        //public Process[] AllProcess { get; set; }

        private Process[] allprocess;

        public Process[] AllProcess
        {
            get { return allprocess; }
            set { allprocess = value;OnPropertyChanged(); }
        }


        private Process currentProcess;

        public Process CurrentProcess
        {
            get { return currentProcess; }
            set { currentProcess = value; }
        }

        public MainViewModel()
        {
            
            AllProcess = Process.GetProcesses();
            Process process= new Process();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();;
            dispatcherTimer.Tick += new EventHandler(OnTimerEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            AllProcess= Process.GetProcesses();
        }

        
    }
}
