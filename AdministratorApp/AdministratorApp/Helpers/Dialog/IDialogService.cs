using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApp.Helpers.Dialog
{
    public interface IDialogService
    {
        string OpenFileDialog(string filter);
    }
}
