using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Object
{
    class ViewOrdersPageObject
    {
        public int ViewOrdersPageCustomerID { get; set; }
        public int ViewOrdersPageSelectedStatus { get; set; }
        public int ViewOrdersPageProductManagementID { get; set; }
        public int ViewOrdersPagerNumberOfPurchased { get; set; }
        public int ViewOrdersPageProductID { get; set; }
        public string ViewOrdersPageConnectionString{ get; set; }
        public bool ViewOrdersPageSearchButtonIsClicked { get; set; }
    }
}
