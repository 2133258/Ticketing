﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdministratorApp.ViewModels;
using TicketingDatabase.Data;

namespace AdministratorApp.Views.Template
{
    /// <summary>
    /// Interaction logic for Base.xaml
    /// </summary>
    public partial class Base : Window
    {
        private TicketingContext _context;
        public Base()
        {
            _context = new TicketingContext();
            DbInitializer.Initialize(_context);
            InitializeComponent();
            this.DataContext = new NavigationVM(_context);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //private void Logout_Click(object sender, RoutedEventArgs e)
        //{
        //    LoginView login = new LoginView();
        //    login.Show();
        //    this.Close();
        //}

        bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {

                    BorderWindow.CornerRadius = new CornerRadius(25);
                    BorderWindow.Margin = new Thickness(5);
                    this.WindowState = System.Windows.WindowState.Normal;
                    this.Width = 1300;
                    this.Height = 880;

                    IsMaximized = false;
                }
                else
                {
                    BorderWindow.CornerRadius = new CornerRadius(0);
                    BorderWindow.Margin = new Thickness(0);
                    this.WindowState = System.Windows.WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }
    }
}
