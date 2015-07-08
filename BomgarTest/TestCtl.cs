using System;
using MonoTouch.Dialog;
using UIKit;
using BomgarSdkBinding;
using Foundation;

namespace BomgarTest
{
    public class TestCtl : DialogViewController
    {
        private BomgarSession _session;
        private MyBomgarDelegate _delegate;
        private EntryElement _sessionKey;
        public TestCtl() : base(UITableViewStyle.Grouped, null)
        {
            _session = new BomgarSession("level_10", "supportlevel10.bomgar.com", 443);
            _delegate = new MyBomgarDelegate(_session);
            _session.Delegate = _delegate;

            _sessionKey = new EntryElement("SessionKey","SessionKey","");
            Root = new RootElement("")
                { 
                    new Section("")
                    {
                        _sessionKey,
                        new StringElement("StartWithSessionKey", ()=> StartWithSessionKey()),
                        new StringElement("EndSession", ()=> EndSession()),

                    }
                };
        }

        void EndSession()
        {
            _session.EndSession();
        }

        void StartWithSessionKey()
        {
            _session.StartWithSessionKey(_sessionKey.Value, "test", (int)SessionFeature.ScreenSharing);
        }
    }

    public class MyBomgarDelegate : BomgarSessionDelegate
    {
        BomgarSession _session;
        public MyBomgarDelegate(BomgarSession session)
        {
            _session = session;
        }

        #region implemented abstract members of BomgarSessionDelegate
        public override void SessionDidConnect()
        {
            Console.WriteLine("SessionDidConnect");
        }
        public override void SessionDidDisconnect()
        {
            Console.WriteLine("SessionDidDisconnect");
        }
        public override void SessionDidDisconnectWithError(Foundation.NSError error)
        {
            Console.WriteLine("SessionDidDisconnectWithError");
        }
        public override void SessionStartDidFailWithError(Foundation.NSError error)
        {
            Console.WriteLine("SessionStartDidFailWithError {0}", error.Description);
        }

        public override void ShowPromptWithId(int promptId, string message, double timeout, NSObject[] buttonTitles)
        {
            for (int i = 0; i < buttonTitles.Length; i++)
            {
                Console.WriteLine("ShowPromptWithId buttonTitles {0}", buttonTitles[i]);
            }
            Console.WriteLine("ShowPromptWithId Message {0}", message);
            Console.WriteLine("ShowPromptWithId timeout {0}", timeout);
            Console.WriteLine("ShowPromptWithId promptId {0}", promptId);
            var alert = new UIAlertView("Message",message, null, buttonTitles[0].ToString(), buttonTitles[1].ToString());
            alert.Tag = promptId;
            alert.Clicked += Alert_Clicked;
            alert.Show();
        }

        void Alert_Clicked (object sender, UIButtonEventArgs e)
        {
            var promtId = ((UIAlertView)sender).Tag;
            _session.SendResponse((int)e.ButtonIndex, (int)promtId);
        }
        #endregion
        
    }
}

