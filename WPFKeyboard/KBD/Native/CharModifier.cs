using System;

namespace WPFKeyboardNative
{
	public class CharModifier
	{
		private int _virtualKey;

		private int _modifierBits;

		public int ModifierBits
		{
			get
			{
				return this._modifierBits;
			}
		}

		public int VirtualKey
		{
			get
			{
				return this._virtualKey;
			}
		}

		public CharModifier(int virtualKey, int modifierBits)
		{
			this._virtualKey = virtualKey;
			this._modifierBits = modifierBits;
		}
	}
}
