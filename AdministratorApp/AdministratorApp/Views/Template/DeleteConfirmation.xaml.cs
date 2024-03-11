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
using System.Windows.Shapes;

namespace AdministratorApp.Views.Template
{
    /// <summary>
    /// Interaction logic for DeleteConfirmation.xaml
    /// </summary>
    public partial class DeleteConfirmation : Window
    {
        public bool result;

        public DeleteConfirmation(object vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            this.result = true;
            this.Close();
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            this.result = false;
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
