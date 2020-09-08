using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionarySpeaking
{
    public class SpeakText
    {
        private WebBrowser web;

        public WebBrowser Web
        {
            get
            {
                return web;
            }

            set
            {
                web = value;
            }
        }

        public SpeakText(WebBrowser web)
        {
            this.Web = web;
        }

        public void Speak(string data)
        {
            SetText(data);
            HtmlElement element = Web.Document.GetElementById("playbutton");
            element.InvokeMember("click");
        }

        private void SetText(string data)
        {
            HtmlElement element = Web.Document.GetElementById("text");
            element.SetAttribute("value", data);
        }
    }
}
