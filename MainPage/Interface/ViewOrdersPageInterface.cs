using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface ViewOrdersPageInterface
    {
        ComboBox ViewOrdersPageFilterByProductStatus { get; set; }
        TextBox ViewPOrdersPageProductManagement { get; set; }
        DataGridView ViewOrdersPageListOfOrders { get; set; }
        DataRow ViewOrdersPageSelectedDatarow { get; set; }
        DataTable ViewOrdersPageDatatableOfProductStatus { get; set; }
        DataTable ViewOrdersPageDatatableOfOrders{ get; set; }
        string ViewOrdersPageConnectionString { get; set; }
        int ViewOrdersPageCustomerID { get; set; }
        TimeSpan ViewOrdersPageGetTimeDifference { get; set; }
        bool ViewOrdersPageSearchIsClicked { get; set; }

    }
}
