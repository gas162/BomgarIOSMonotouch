using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("BomgarSession.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, LinkerFlags = "-lstdc++ -ObjC", ForceLoad = true, Frameworks = "CFNetwork Accelerate", IsCxx = true)]
