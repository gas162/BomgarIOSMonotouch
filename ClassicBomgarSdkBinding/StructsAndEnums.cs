using System;
using MonoTouch.ObjCRuntime;

namespace ClassicBomgarSdkBinding
{
    public enum SessionFeature : uint
    {
        ScreenSharing = (1 << 0),
        ScreenSharingWithControl = (1 << 1),
        FileTransfer = (1 << 2),
        SystemInfo = (1 << 3),
        SystemInfoNoDefault = (1 << 4),
        Clipboard = (1 << 5)
    }

    [Native]
    public enum SystemInfoCategoryType : ulong
    {
        List = 0,
        Table,
        Text
    }

    public enum BomgarSessionErrorType : uint
    {
        KeyError = 0,
        IssueError,
        StartError,
        SocketError,
        OtherError
    }
}

