using MainPage.Interface;
using MainPage.Model;
using MainPage.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.Presenter
{
    class ChatBoxPresenter
    {
        //LoginSignUpInterface LoginSignupView;

        ChatBoxInterface ChatBoxPageView;
        ChatBoxModel mod = new ChatBoxModel();
        ChatBoxPageObject obj = new ChatBoxPageObject();

        public ChatBoxPresenter(ChatBoxInterface IChatBoxPageView)
        {
            ChatBoxPageView = IChatBoxPageView;
        }

        public void SubmitChat()
        {
            //ChatBoxPageView.accountID = LoginSignupView.LoginSingupAccountID;
            obj.connectionString = ChatBoxPageView.ViewAllChatPageConnectionString;
            //obj.accountID = mod.getAccountID(ChatBoxPageView.accountID);
            obj.accountID = ChatBoxPageView.accountID;
            obj.datePost = DateTime.Now;
            obj.txtChat = ChatBoxPageView.TxtChat.Text;
         
            ChatBoxPageView.TxtChat.Clear();
            mod.submitChat(obj);
      
        }

        public void LoadAllChats()
        {
            obj.connectionString = ChatBoxPageView.ViewAllChatPageConnectionString;
            ChatBoxPageView.ViewAllChatPageDatatable = mod.ViewAllChat(obj);         
            ChatBoxPageView.ViewAllChatPageGridview.DataSource = ChatBoxPageView.ViewAllChatPageDatatable;
        }

            
    }
}
