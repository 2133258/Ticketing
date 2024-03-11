using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApp.Helpers.Dialog
{
    public class DialogService : IDialogService
    {
        public string OpenFileDialog(string filter)
        {
        //    OpenFileDialog dialog = new OpenFileDialog
        //    {
        //        Filter = filter
        //    };

        //    return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? dialog.FileName : null;
            return "";
        }
    }
}