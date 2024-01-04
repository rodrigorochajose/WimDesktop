using System;

namespace DMMDigital.Models
{
    interface EventReceiver
    {
        void SdkCallbackHandler(int nDetectorID, int nEventID, int nEventLevel, IntPtr pszMsg, int nParam1, int nParam2, int nPtrParamLen, IntPtr pParam);
    }
}
