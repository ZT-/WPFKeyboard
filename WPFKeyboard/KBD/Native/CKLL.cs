using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WPFKeyboardNative
{
    class CKLL : IDisposable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct VK_STRUCT
        {
            public int VirtualKey;
            public int Attributes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.SysInt)]
            public int[] Characters;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct VK_MODIFIER
        {
            public int VirtualKey;
            public int ModifierBits;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct VK_SCANCODE
        {
            public int VirtualKey;
            public int ScanCode;
            [MarshalAsAttribute(UnmanagedType.U1)]
            public bool E0Set;
            [MarshalAsAttribute(UnmanagedType.U1)]
            public bool E1Set;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
        public struct SC_TEXT
        {
            public int ScanCode;
            [MarshalAs(UnmanagedType.LPWStr)]
            public String Text;
        };

        public const string Dll = "WPFKeyboard.Native.dll";

        [DllImport(Dll, EntryPoint = "GetInstance", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetInstance();

        [DllImport(Dll, EntryPoint = "Free", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Free(IntPtr ptr);

        [DllImport(Dll, EntryPoint = "LoadDLL", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LoadDLL(IntPtr ptr, string sKeyboardDll);

        [DllImport(Dll, EntryPoint = "GetVKCount", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVKCount(IntPtr ptr);

        [DllImport(Dll, EntryPoint = "GetVKAtIndex", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetVKAtIndex(IntPtr ptr, int index);

        [DllImport(Dll, EntryPoint = "GetModifiersCount", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetModifiersCount(IntPtr ptr);

        [DllImport(Dll, EntryPoint = "GetModifierAtIndex", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetModifierAtIndex(IntPtr ptr, int index);

        [DllImport(Dll, EntryPoint = "GetScanCodesCount", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScanCodesCount(IntPtr ptr);

        [DllImport(Dll, EntryPoint = "GetScanCodeAtIndex", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetScanCodeAtIndex(IntPtr ptr, int index);

        [DllImport(Dll, EntryPoint = "GetScanCodeTextCount", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScanCodeTextCount(IntPtr ptr);

        [DllImport(Dll, EntryPoint = "GetScanCodeTextAtIndex", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetScanCodeTextAtIndex(IntPtr ptr, int index);

        private readonly IntPtr _instance;

        public CKLL()
        {
            _instance = GetInstance();
        }

        public void Dispose()
        {
            Free(_instance);
        }

        public bool LoadDLL(string keyboardLayoutDll)
        {
            return LoadDLL(_instance, keyboardLayoutDll);
        }

        public int GetModifiersCount()
        {
            return GetModifiersCount(_instance);
        }

        public VK_MODIFIER GetModifierAtIndex(int i)
        {
            IntPtr ptr = GetModifierAtIndex(_instance, i);
            VK_MODIFIER s = (VK_MODIFIER)Marshal.PtrToStructure(ptr, typeof(VK_MODIFIER));
            return s;
        }


        public VK_STRUCT GetVKAtIndex(int i)
        {
            IntPtr ptr = GetVKAtIndex(_instance, i);
            VK_STRUCT s = (VK_STRUCT)Marshal.PtrToStructure(ptr, typeof(VK_STRUCT));
            return s;
        }

        public int GetVKCount()
        {
            return GetVKCount(_instance);
        }

        public VK_SCANCODE GetScanCodeAtIndex(int i)
        {
            IntPtr ptr = GetScanCodeAtIndex(_instance, i);
            VK_SCANCODE s = (VK_SCANCODE)Marshal.PtrToStructure(ptr, typeof(VK_SCANCODE));
            return s;
        }

        public int GetScanCodeTextCount()
        {
            return GetScanCodeTextCount(_instance);
        }

        public SC_TEXT GetScanCodeTextAtIndex(int i)
        {
            IntPtr ptr = GetScanCodeTextAtIndex(_instance, i);
            SC_TEXT s = (SC_TEXT)Marshal.PtrToStructure(ptr, typeof(SC_TEXT));
            return s;
        }

        public int GetScanCodesCount()
        {
            return GetScanCodesCount(_instance);
        }
    }
}
