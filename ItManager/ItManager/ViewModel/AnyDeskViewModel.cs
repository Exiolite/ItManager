﻿using System;
using System.Diagnostics;
using ItManager.Model;
using ItManager.View.Windows;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class AnyDeskViewModel : ViewModel
    {
        public AnyDeskViewModel()
        {
        }

        public AnyDeskViewModel(AnyDesk anyDesk)
        {
            AnyDesk = anyDesk;
        }


        private AnyDesk _anyDesk;

        public AnyDesk AnyDesk
        {
            get { return _anyDesk; }
            set
            {
                _anyDesk = value;
                NotifyPropertyChanged(nameof(AnyDesk));
            }
        }


        private ICommand _openInNewWindowCommand;

        public ICommand OpenInNewWindowCommand
        {
            get
            {
                if (_openInNewWindowCommand == null)
                    _openInNewWindowCommand = new Command.Command(this.OpenInNewWindowExecute, this.CanOpenInNewWindow, false);
                return _openInNewWindowCommand;
            }
        }

        private void OpenInNewWindowExecute(object obj)
        {
            var anyDeskWindowView = new AnyDeskWindowView();
            anyDeskWindowView.DataContext = this;
            anyDeskWindowView.Show();
        }

        private bool CanOpenInNewWindow(object arg) => true;


        private ICommand _connectViaAnyDeskCommand;

        public ICommand ConnectViaAnyDeskCommand
        {
            get
            {
                if (_connectViaAnyDeskCommand == null)
                    _connectViaAnyDeskCommand = new Command.Command(this.ConnectViaAnyDeskExecute, this.CanConnectViaAnyDesk, false);
                return _connectViaAnyDeskCommand;
            }
        }

        private async void ConnectViaAnyDeskExecute(object obj)
        {
            await System.Threading.Tasks.Task.Delay(1);

            var path = @"C:\AnyDesk.exe";
            var args = $"/C echo {AnyDesk.Password} | {path} {AnyDesk.Id} --with-password";

            var startInfo = new ProcessStartInfo
            {
                FileName = "CMD.exe",
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var processTemp = new Process();
            processTemp.StartInfo = startInfo;
            processTemp.EnableRaisingEvents = true;
            try
            {
                processTemp.Start();
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        private bool CanConnectViaAnyDesk(object arg) => true;
    }
}