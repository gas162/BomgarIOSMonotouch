using System;
using MonoTouch.Dialog;
using UIKit;
using BomgarSdkBinding;

namespace BomgarTest
{
    public class TestCtl : DialogViewController
    {
        private BomgarSession _session;
        private MyBomgarDelegate _delegate;

        public TestCtl() : base(UITableViewStyle.Grouped, null)
        {
            _session = new BomgarSession("Level10", "supportlevel10.bomgar.com", 443);
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
            _session.StartWithSessionKey("7408330", "test", (int)SessionFeature.ScreenSharing);
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
        public override void SessionDidDisconnectWithError(Foundation.NSError error)
        {
            Console.WriteLine("SessionDidDisconnectWithError");
        }
        public override void SessionStartDidFailWithError(Foundation.NSError error)
        {
            Console.WriteLine("SessionStartDidFailWithError {0}", error.Description);
        }
        #endregion
        
    }
}

