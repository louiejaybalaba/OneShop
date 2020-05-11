using MainPage.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Presenter
{
    class SeptupConnectionPresenter
    {
        SetupConnectionInterface view;
        public SeptupConnectionPresenter(SetupConnectionInterface iview)
        {
            view = iview;

        }

        public void SaveConnection()
        {
            string str;            
            str = "" + view.SetupConnectionServer.Text + ";" + view.SetupConnectionPort.Text + ";" + view.SetupConnectionId.Text
                + ";" + view.SetupConnectionPassword.Text + ";" + view.SetupConnectionDatabase.Text + ";";
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
              
                File.WriteAllText(save.FileName, str);
            }
        }


        public void BrowseConnection()
        {

            string CatchString;
            int CountArray = 0;
            int Temp = 0;
            int CountArrayOfGetSubString = 0;
            string GetSubString;

            string[] ArrayOfGetSubString = new string[5];
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = " Text File(*.txt)|*.txt|Group2 File|*.Group2";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader ReadText = new StreamReader(dlg.FileName);
                CatchString = ReadText.ReadLine();
             
             
                foreach (char c in CatchString)
                {
                    if (c.ToString() == ";")
                     {                     
                         GetSubString = CatchString.Substring(Temp, CountArray - Temp);
                         ArrayOfGetSubString[CountArrayOfGetSubString] = GetSubString;                      
                         CountArrayOfGetSubString += 1;
                         Temp = CountArray+1;
                    }
                    CountArray += 1;
                }
                view.SetupConnectionServer.Text = ArrayOfGetSubString[0];
                view.SetupConnectionPort.Text= ArrayOfGetSubString[1];
                view.SetupConnectionId.Text= ArrayOfGetSubString[2];
                view.SetupConnectionPassword.Text= ArrayOfGetSubString[3];
                view.SetupConnectionDatabase.Text= ArrayOfGetSubString[4];
            }
        }

    }
}
