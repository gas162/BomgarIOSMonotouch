using System;
using Foundation;
using ObjCRuntime;
using Security;

namespace BomgarSdkBinding
{
    partial interface Constants
    {
        // extern NSString *const BGSessionErrorDomain;
        [Field ("BGSessionErrorDomain")]
        NSString BGSessionErrorDomain { get; }
    }

    // @interface BomgarSession : NSObject
    [BaseType (typeof(NSObject))]
    interface BomgarSession
    {
        [Wrap ("WeakDelegate")]
        BomgarSessionDelegate Delegate { get; set; }

        // @property (weak) id<BomgarSessionDelegate> delegate;
        [NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) BOOL screenSharingStarted;
        [Export ("screenSharingStarted")]
        bool ScreenSharingStarted { get; }

        // @property (readonly, nonatomic) BOOL repIsPresent;
        [Export ("repIsPresent")]
        bool RepIsPresent { get; }

        // @property (readonly, nonatomic, strong) NSMutableDictionary * tlsSettings;
        [Export ("tlsSettings", ArgumentSemantic.Strong)]
        NSMutableDictionary TlsSettings { get; }

        // -(id)initWithCompanyId:(NSString *)companyId siteAddress:(NSString *)siteAddress port:(NSUInteger)port;
        [Export ("initWithCompanyId:siteAddress:port:")]
        IntPtr Constructor (string companyId, string siteAddress, nuint port);

        // -(void)startWithSessionKey:(NSString *)sessionKey sessionName:(NSString *)sessionName features:(SessionFeatures)features;
        [Export ("startWithSessionKey:sessionName:features:")]
        void StartWithSessionKey (string sessionKey, string sessionName, nuint features);

        // -(void)startWithIssue:(NSString *)issueCodeName sessionName:(NSString *)sessionName features:(SessionFeatures)features;
        [Export ("startWithIssue:sessionName:features:")]
        void StartWithIssue (string issueCodeName, string sessionName, nuint features);

        // -(void)defineSystemInfoCategory:(NSString *)categoryName withType:(SystemInfoCategoryType)categoryType;
        [Export ("defineSystemInfoCategory:withType:")]
        void DefineSystemInfoCategory (string categoryName, SystemInfoCategoryType categoryType);

        // -(void)defineSpecialActionWithId:(NSString *)identifier name:(NSString *)name confirmation:(BOOL)confirm;
        [Export ("defineSpecialActionWithId:name:confirmation:")]
        void DefineSpecialActionWithId (string identifier, string name, bool confirm);

        // -(void)sendChat:(NSString *)chatMessage asStatus:(BOOL)status;
        [Export ("sendChat:asStatus:")]
        void SendChat (string chatMessage, bool status);

        // -(void)sendResponse:(NSUInteger)buttonIndex forPrompt:(NSUInteger)promptId;
        [Export ("sendResponse:forPrompt:")]
        void SendResponse (nuint buttonIndex, nuint promptId);

        // -(void)sendTimeoutForPrompt:(NSUInteger)promptId;
        [Export ("sendTimeoutForPrompt:")]
        void SendTimeoutForPrompt (nuint promptId);

        // -(void)endSession;
        [Export ("endSession")]
        void EndSession ();
    }

    // @protocol BomgarSessionDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface BomgarSessionDelegate
    {
        // @required -(void)sessionStartDidFailWithError:(NSError *)error;
        [Abstract]
        [Export ("sessionStartDidFailWithError:")]
        void SessionStartDidFailWithError (NSError error);

        // @required -(void)sessionDidConnect;
        [Abstract]
        [Export ("sessionDidConnect")]
        void SessionDidConnect ();

        // @required -(void)sessionDidDisconnect;
        [Abstract]
        [Export ("sessionDidDisconnect")]
        void SessionDidDisconnect ();

        // @required -(void)sessionDidDisconnectWithError:(NSError *)error;
        [Abstract]
        [Export ("sessionDidDisconnectWithError:")]
        void SessionDidDisconnectWithError (NSError error);

        // @optional -(void)didReceiveChatMessage:(NSString *)chatMessage;
        [Export ("didReceiveChatMessage:")]
        void DidReceiveChatMessage (string chatMessage);

        // @optional -(void)didReceiveChatLink:(NSURL *)url;
        [Export ("didReceiveChatLink:")]
        void DidReceiveChatLink (NSUrl url);

        // @optional -(void)didReceivePushURL:(NSURL *)url;
        [Export ("didReceivePushURL:")]
        void DidReceivePushURL (NSUrl url);

        // @optional -(void)showPromptWithId:(NSUInteger)promptId message:(NSString *)message timeout:(NSTimeInterval)timeout buttonTitles:(NSArray *)buttonTitles;
        [Export ("showPromptWithId:message:timeout:buttonTitles:")]
        void ShowPromptWithId (nuint promptId, string message, double timeout, NSObject[] buttonTitles);

        // @optional -(void)repPresenceChanged:(BOOL)inSession;
        [Export ("repPresenceChanged:")]
        void RepPresenceChanged (bool inSession);

        // @optional -(void)screenSharingStateChanged:(BOOL)started;
        [Export ("screenSharingStateChanged:")]
        void ScreenSharingStateChanged (bool started);

        // @optional -(void)didReceiveSpecialActionRequest:(NSString *)identifier;
        [Export ("didReceiveSpecialActionRequest:")]
        void DidReceiveSpecialActionRequest (string identifier);

        // @optional -(SystemInfoTableData *)tableDataForCategory:(NSString *)categoryName;
        [Export ("tableDataForCategory:")]
        SystemInfoTableData TableDataForCategory (string categoryName);

        // @optional -(SystemInfoListData *)listDataForCategory:(NSString *)categoryName;
        [Export ("listDataForCategory:")]
        SystemInfoListData ListDataForCategory (string categoryName);

        // @optional -(SystemInfoTextData *)textDataForCategory:(NSString *)categoryName;
        [Export ("textDataForCategory:")]
        SystemInfoTextData TextDataForCategory (string categoryName);

        // @optional -(BOOL)shouldTrustPeerCertificates:(NSArray *)peerCertificates secTrustRef:(SecTrustRef)trustRef;
        [Export ("shouldTrustPeerCertificates:secTrustRef:")]
        unsafe bool ShouldTrustPeerCertificates (NSObject[] peerCertificates, SecTrust trustRef);
    }

    // @interface SystemInfoTableRow : NSObject
    [BaseType (typeof(NSObject))]
    interface SystemInfoTableRow
    {
        // -(void)addString:(NSString *)str;
        [Export ("addString:")]
        void AddString (string str);

        // +(SystemInfoTableRow *)rowWithStrings:(NSArray *)stringArray;
        [Static]
        [Export ("rowWithStrings:")]
        SystemInfoTableRow RowWithStrings (NSObject[] stringArray);
    }

    // @interface SystemInfoTableData : NSObject
    [BaseType (typeof(NSObject))]
    interface SystemInfoTableData
    {
        // -(void)setHeaderRow:(SystemInfoTableRow *)headerRow;
        [Export ("setHeaderRow:")]
        void SetHeaderRow (SystemInfoTableRow headerRow);

        // -(void)addDataRow:(SystemInfoTableRow *)row;
        [Export ("addDataRow:")]
        void AddDataRow (SystemInfoTableRow row);
    }

    // @interface SystemInfoListItem : NSObject
    [BaseType (typeof(NSObject))]
    interface SystemInfoListItem
    {
        // -(id)initWithName:(NSString *)name value:(NSString *)value;
        [Export ("initWithName:value:")]
        IntPtr Constructor (string name, string value);
    }

    // @interface SystemInfoListData : NSObject
    [BaseType (typeof(NSObject))]
    interface SystemInfoListData
    {
        // -(void)addListItem:(SystemInfoListItem *)item;
        [Export ("addListItem:")]
        void AddListItem (SystemInfoListItem item);
    }

    // @interface SystemInfoTextData : NSObject
    [BaseType (typeof(NSObject))]
    interface SystemInfoTextData
    {
        // -(id)initWithText:(NSString *)text;
        [Export ("initWithText:")]
        IntPtr Constructor (string text);
    }
}

