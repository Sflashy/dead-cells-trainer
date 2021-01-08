using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Memory;

namespace DeadCells_Trainer
{
    public partial class MainWindow : Window
    {

        public Mem memory = new Mem();
        int procID;
        bool IsGameRunning;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            procID = memory.getProcIDFromName("deadcells");
            if(procID > 0)
            {
                memory.OpenProcess(procID);
                Status.Content = $"DeadCells.exe ({procID})";
                IsGameRunning = true;
            }

        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void InfHealth_Checked(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Dispatcher.Invoke((Action)async delegate
            {
                if(IsGameRunning)
                {
                    while (InfHealth.IsChecked == true)
                    {
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.iHealth}", "int", "99999");
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.iMAX_Health}", "int", "99999");
                        await Task.Delay(1);
                    }
                }

            });

        }

        private void InfCoin_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)async delegate
            {
                if(IsGameRunning)
                {
                    while (InfCoin.IsChecked == true)
                    {
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.iCoin}", "int", "99999");
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.ibCoin}", "int", "99999");
                        await Task.Delay(1);
                    }
                }

            });

        }

        private void NCooldown_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)async delegate
            {
                if(IsGameRunning)
                {
                    while (NCooldown.IsChecked == true)
                    {
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.iNCooldown}", "int", "0");
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.iNCooldown2}", "int", "0");
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.iNCooldown3}", "int", "0");
                        await Task.Delay(1);
                    }
                }

            });
        }

        private void OneShot_Checked(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Dispatcher.Invoke((Action)async delegate
            {
                if(IsGameRunning)
                {
                    while (OneShot.IsChecked == true)
                    {
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.OneShot}", "int", "100");
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.OneShot2}", "int", "100");
                        memory.writeMemory($"libhl.dll+00049184, {Offsets.OneShot3}", "int", "100");
                        await Task.Delay(1);
                    }
                }

            });
        }

        private void CloseButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
