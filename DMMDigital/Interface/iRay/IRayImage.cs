/**
* File: IRayVariant.h
*
* Purpose: Definit interface data types
*
*
* @author Haitao.Ning
* @version 1.0 2015/02/02
*
* Copyright (C) 2009, 2015, iRay Technology (Shanghai) Ltd.
*
*/
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DMMDigital.Interface.iRay
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IRayImage
    {
        public int nWidth;
        public int nHeight;
        public int nBytesPerPixel;
        public IntPtr pData; // ushort*
        public IRayVariantMap propList;

        public static implicit operator Image(IRayImage v)
        {
            throw new NotImplementedException();
        }
    }
}