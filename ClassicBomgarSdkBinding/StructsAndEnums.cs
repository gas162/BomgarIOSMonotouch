using System;
using MonoTouch.ObjCRuntime;

namespace ClassicBomgarSdkBinding
{
    public enum SessionFeature
    {
        ScreenSharing = (1 << 0),
        ScreenSharingWithControl = (1 << 1),
        FileTransfer = (1 << 2),
        SystemInfo = (1 << 3),
        SystemInfoNoDefault = (1 << 4),
        Clipboard = (1 << 5)
    }
            
    public enum SystemInfoCategoryType
    {
        List = 0,
        Table,
        Text
    }

    public enum BomgarSessionErrorType
    {
        KeyError = 0,
        IssueError,
        StartError,
        SocketError,
        OtherError
    }
}

