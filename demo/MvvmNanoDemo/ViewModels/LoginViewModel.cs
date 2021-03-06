﻿using MvvmNano;

namespace MvvmNanoDemo
{
    public class LoginViewModel : MvvmNanoViewModel
    {
        private string _username;
        public string Username 
        {
            get { return _username; }
            set 
            { 
                _username = value; 
                NotifyPropertyChanged(); 
                NotifyPropertyChanged("IsFormValid"); 
            }
        }

        private string _password;
        public string Password 
        {
            get { return _password; }
            set 
            { 
                _password = value; 
                NotifyPropertyChanged(); 
                NotifyPropertyChanged("IsFormValid"); 
            }
        }

        public bool IsFormValid
        {
            get { return !string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password); }
        }

        public MvvmNanoCommand LogInCommand
        {
            get { return new MvvmNanoCommand(LogIn); }
        }

        public MvvmNanoCommand ShowAboutCommand
        {
            get { return new MvvmNanoCommand(NavigateTo<AboutViewModel>); }
        }

        private async void LogIn()
        {
            if (!IsFormValid)
                return;

            await NavigateToAsync<WelcomeViewModel, User>(new User(Username));
        }
    }
}

