using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface ChatBoxInterface
    {
        RichTextBox TxtChat { get; set; }
        DataTable ViewAllChatPageDatatable { get; set; }
        DataGridView ViewAllChatPageGridview { get; set; }


        string ViewAllChatPageConnectionString { get; set; }
        int accountID { get; set; }
    }
}
