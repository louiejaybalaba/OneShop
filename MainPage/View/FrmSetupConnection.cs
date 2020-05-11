using MainPage.Interface;
using MainPage.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPage.View
{
    public partial class FrmSetupConnection : Form,SetupConnectionInterface
    {

        SeptupConnectionPresenter SetupConPresenter;
        public FrmSetupConnection()
        {
            InitializeComponent();
            SetupConPresenter = new SeptupConnectionPresenter(this);
        }

        public TextBox SetupConnectionServer
        {
            get { return textBox1; }
            set { textBox1 = value; }
        }
        public TextBox SetupConnectionPort
        {
            get { return textBox2; }
            set { textBox2 = value; }
        }
        public TextBox SetupConnectionId
        {
            get { return textBox3; }
            set { textBox3 = value; }
        }
        public TextBox SetupConnectionPassword
        {
            get { return textBox4; }
            set { textBox4 = value; }
        }
        public TextBox SetupConnectionDatabase
        {
            get { return textBox5; }
            set { textBox5 = value; }
        }
        public Button SetupConnectionSaveConnection
        {
            get { return button1; }
            set { button1 = value; }
        }
        public Button SetupConnectionOk
        {
            get { return button2; }
            set { button2 = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetupConPresenter.SaveConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetupConPresenter.BrowseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
