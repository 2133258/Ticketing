﻿using AdministratorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketingDatabase.Data;
using TicketingDatabase.Models;

namespace AdministratorApp.Views.Transactions
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : UserControl
    {
        private TicketingContext _context;
        private NavigationVM _nav;
        public List(TicketingContext context, NavigationVM nav)
        {
            _context = context;
            _nav = nav;
            InitializeComponent();
            this.DataContext = new TransactionVM(context, nav);
        }
    }
}
