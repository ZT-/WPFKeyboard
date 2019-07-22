using System;
using System.Collections.Generic;

namespace WPFKeyboardNative
{
	public class KeyboardLayout
	{
		private List<CharModifier> _charModifiers;

		private List<VirtualKey> _virtualKeys;

		private List<ScanCode> _scanCodes;

		private List<ScanCodeText> _scanCodeText;

		public List<ScanCodeText> CodeText
		{
			get
			{
				return this._scanCodeText;
			}
		}

		public List<ScanCode> ScanCodes
		{
			get
			{
				return this._scanCodes;
			}
		}

		public List<VirtualKey> VirtualKeys
		{
			get
			{
				return this._virtualKeys;
			}
		}

		public List<CharModifier> CharModifiers
		{
			get
			{
				return this._charModifiers;
			}
		}

		public KeyboardLayout(string keyboardLayoutDllPath)
		{
			this._charModifiers = new List<CharModifier>();
			this._virtualKeys = new List<VirtualKey>();
			this._scanCodes = new List<ScanCode>();
			this._scanCodeText = new List<ScanCodeText>();
		}
	}
}
