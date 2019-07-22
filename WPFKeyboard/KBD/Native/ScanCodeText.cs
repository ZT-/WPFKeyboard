using System;

namespace WPFKeyboardNative
{
	public class ScanCodeText
	{
		private int _scanCode;

		private string _text;

		public string Text
		{
			get
			{
				return this._text;
			}
		}

		public int ScanCode
		{
			get
			{
				return this._scanCode;
			}
		}

		public ScanCodeText(int scanCode, string text)
		{
			this._scanCode = scanCode;
			this._text = text;
		}
	}
}
