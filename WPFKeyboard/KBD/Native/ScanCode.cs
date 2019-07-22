using System;
using System.Runtime.InteropServices;

namespace WPFKeyboardNative
{
    public class ScanCode
    {
        private int _virtualKey;

        private int _scanCode;

        private bool _e0Set;

        private bool _e1Set;

        public bool E1Set
        {
            get
            {
                return this._e1Set;
            }
        }

        public bool E0Set
        {
            get
            {
                return this._e0Set;
            }
        }

        public int Code
        {
            get
            {
                return this._scanCode;
            }
        }

        public int VirtualKey
        {
            get
            {
                return this._virtualKey;
            }
        }

        public ScanCode(int virtualKey, int scanCode, bool e0Set, bool e1Set)
        {
            this._virtualKey = virtualKey;
            this._scanCode = scanCode;
            this._e0Set = e0Set;
            this._e1Set = e1Set;
        }
    }
}
