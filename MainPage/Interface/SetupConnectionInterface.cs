using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface SetupConnectionInterface
    {
        TextBox SetupConnectionServer { get; set; }
        TextBox SetupConnectionPort { get; set; }
        TextBox SetupConnectionId {  get; set;  }
        TextBox SetupConnectionPassword { get; set; }
        TextBox SetupConnectionDatabase { get; set; }
        Button SetupConnectionSaveConnection { get; set; }
        Button SetupConnectionOk { get; set; }
    }
}
