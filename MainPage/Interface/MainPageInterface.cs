using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Interface
{
    interface MainPageInterface
    {
         TabPage LoginSignupPage { get; set; }
         TabPage MyAccountPage { get; set; }
         TabPage SellItemsPage { get; set; }
         TabPage ViewAvailableItemsPage { get; set; }
         TabPage BuyItemsPage{ get; set; }
         TabPage ViewPendingTransactionsPage { get; set; }
         TabPage ChatBoxPage { get; set; }
         TabPage ViewOrdersPage { get; set; }
      

        TabControl TabControls { get; set; }
      
        bool DatagridViewMouseLeave { get; set; }
        bool isRefreshing { get; set; }
        bool isLoggedIn { get; set; }

}
}
