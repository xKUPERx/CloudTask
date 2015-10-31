using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//https://login.live.com/oauth20_authorize.srf?client_id=YOUR_CLIENT_ID&scope=YOUR_SCOPE_STRING&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf

namespace CloudTask_GUI.Controllers
{
    class OneDriveController
    {
        private OneDriveAuthorizationFrom m_webBrowserForm;
        private const string CLIEND_ID = "0000000040170F15";
        private const string SECRET_STRING = "is3eL0uxp9TEZkKTPgbfav6sqPTLkuVx";
        private const string SCOPE_STRING = "wl.basic"; //scope = "wl.basic"; //onedrive.appfolder
        public OneDriveController() //https://login.live.com/oauth20_authorize.srf?client_id=0000000040170F15&scope=wl.basic&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf
        {
            m_webBrowserForm = new OneDriveAuthorizationFrom();
            m_webBrowserForm.simpleButtonOk.Click += new EventHandler(this.ButtonOkClick);
            m_webBrowserForm.simpleButtonCancel.Click += new EventHandler(this.ButtonCancelClick);
            string url = string.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", CLIEND_ID, SCOPE_STRING);
            m_webBrowserForm.webBrowser.Navigate(url);
        }

        public void Show()
        {            
            m_webBrowserForm.ShowDialog(CaseKeeper.AppMainForm);          
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            string url = string.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", CLIEND_ID, SCOPE_STRING);
            m_webBrowserForm.webBrowser.Navigate(url);
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            m_webBrowserForm.webBrowser.Navigate("https://login.live.com");
            //m_webBrowserForm.Close();
        }
    }
}
