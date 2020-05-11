using MainPage.Interface;
using MainPage.Model;
using MainPage.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Presenter
{
    class SellProductsPresenter
    {
        SellProductsPageInterface SellProductsPageView;
        SellProductsModel mod = new SellProductsModel();
        SellProductsPageObject obj = new SellProductsPageObject();
        public SellProductsPresenter(SellProductsPageInterface ISellProductsPageView)
        {
            SellProductsPageView = ISellProductsPageView;
        }

        public void LoadProductType()
        {
            obj.SellProductsPageConnectionString = SellProductsPageView.SellProductsPageConnectionString;
            
            SellProductsPageView.SellProductsPageProductTypeComb.DataSource = mod.LoadProductTypes(obj);
            SellProductsPageView.SellProductsPageProductTypeComb.DisplayMember = "Description";
            SellProductsPageView.SellProductsPageProductTypeComb.ValueMember = "ProductTypeID";
            SellProductsPageView.SellProductsPageProductTypeComb.SelectedIndex = -1;
        }

        public void BrowsePicture()
        {
            string imgloc = "";
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG FILES (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";
                dlg.Title = "Select Picture for the Product";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc = dlg.FileName.ToString();
                    SellProductsPageView.SellProductsPageProductPicturePictureB.ImageLocation = dlg.FileName.ToString();
                    SellProductsPageView.SellProductsPageProductPicturePictureB.SizeMode = PictureBoxSizeMode.StretchImage;
                    SellProductsPageView.SellProductsPageProductPictureLocation = dlg.FileName.ToString();
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());

            }

        }

        public void PostItem()
        {
            if (SellProductsPageView.SellProductsPageProductTypeComb.SelectedIndex == -1)
            {
                MessageBox.Show("Please Seclted ProductType");
            }
            else
            {
                try
                {
                    obj.SellProductsPageConnectionString = SellProductsPageView.SellProductsPageConnectionString;
                    obj.SellProductsPageProductName = SellProductsPageView.SellProductsPageProductNameTxB.Text;
                    obj.SellProductsPageProductDiscription = SellProductsPageView.SellProductsPageProductDescriptionRichTxB.Text;
                    obj.SellProductsPageProductStock = Int32.Parse( SellProductsPageView.SellProductsPageProductStockTxB.Text.ToString());
                    obj.SellProductsPageProductPrice = Int32.Parse(SellProductsPageView.SellProductsPageProductPriceTxB.Text.ToString());
                    obj.SellProductsPageImageLocation = SellProductsPageView.SellProductsPageProductPictureLocation;
                    obj.SellProductsPageProductTypeID = int.Parse( SellProductsPageView.SellProductsPageProductTypeComb.SelectedValue.ToString());
                    obj.SellProductsPageRetailerID = SellProductsPageView.SellProductsPageRetailerID;
                    mod.PostItem(obj);
                }
                catch (Exception e)       
                {
                    MessageBox.Show(e.Message + "Please Enter Correctly")
;                }

            }

        }


    }
}
