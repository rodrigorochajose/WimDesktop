using System;

namespace WimDesktop.Interface.iRay
{
    interface IEventReceiver
    {
        void SdkCallbackHandler(int nDetectorID, int nEventID, int nEventLevel, IntPtr pszMsg, int nParam1, int nParam2, int nPtrParamLen, IntPtr pParam);
    }
}
