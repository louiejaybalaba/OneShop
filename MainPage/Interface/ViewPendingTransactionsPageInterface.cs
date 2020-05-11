using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface ViewPendingTransactionsPageInterface
    {
        DateTimePicker ViewPendingTransactionsPageShippingDate { get; set; }
        DateTimePicker ViewPendingTransactionsPageDeliveryDate { get; set; }
        ComboBox ViewPendingTransactionsPageFilterByProductStatusCombo { get; set; }
        ComboBox ViewPendingTransactionsPageUpdateProductStatusCombo { get; set; }
        DataRow ViewPendingTransactionsPageSelectedDatarow { get; set; }
        DataTable ViewPendingTransactionsPageDatatableOfTransactions { get; set; }
        DataTable ViewPendingTransactionsPageDatatableOfStatus { get; set; }
        DataTable ViewPendingTransactionsPageDatatableUpdateStatus { get; set; }
        DataGridView ViewPendingTransactionsPageListOfTransactions { get; set; }
        Button ViewPendingTransactionsPageUpdateShippingInfoBtn { get; set; }
        Button ViewPendingTransactionsPageUpdateProductStatusIDBtn { get; set; }
        TextBox ViewPendingTransactionsPageProductManagementIDTxB { get; set; }
        Label ViewPendingTransactionsPageShippingIdentifier { get; set; }
        int ViewPendingTransactionsPageShippingID{ get; set; }
       string ViewPendingTransactionsPageConnectionString { get; set; }
        decimal ViewPendingTransactionsPageProfits { get; set; }
        bool ViewPendingTransactionsPageisRefreshing { get; set; }
        bool ViewPendingTransactionsPageSearchIsCLicked { get; set; }
        int ViewPendingTransactionsPageSelectedProductStatusID { get; set; }
        int ViewPendingTransactionsPageUpdateProductStatusID { get; set; }
        int ViewPendingTransactionsPageRetailerID { get; set; }
    }
}
