using System;
using MonoTouch.Dialog;
using ClassicBomgarSdkBinding;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace BomgarTest
{
    public class TestCtl : DialogViewController
    {
        private BomgarSession _session;
        private MyBomgarDelegate _delegate;

        public TestCtl() : base(UITableViewStyle.Grouped, null)
        {
            _session = new BomgarSession("supportlevel10", "http://supportlevel10.bomgar.com/?ak=03f43b255e25015a5a113a680bcfae7c", 80);
            _delegate = new MyBomgarDelegate();
            _session.Delegate = _delegate;


            Root = new RootElement("")
                { 
                    new Section("")
                    {
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
            _session.StartWithSessionKey("5844606", "test", (int)SessionFeature.ScreenSharing);
        }
    }

    public class MyBomgarDelegate : BomgarSessionDelegate
    {
        #region implemented abstract members of BomgarSessionDelegate
        public override void SessionDidConnect()
        {
            Console.WriteLine("SessionDidConnect");
        }
        public override void SessionDidDisconnect()
        {
            Console.WriteLine("SessionDidDisconnect");
        }
        public override void SessionDidDisconnectWithError(NSError error)
        {
            Console.WriteLine("SessionDidDisconnectWithError");
        }
        public override void SessionStartDidFailWithError(NSError error)
        {
            Console.WriteLine("SessionStartDidFailWithError");
        }
        #endregion
        
    }
}

