using System;

namespace WPFKeyboardNative
{
	public class VirtualKey
	{
		private int _virtualkey;

		private int _attributes;

		private int[] _characters;

		public int Attributes
		{
			get
			{
				return this._attributes;
			}
		}

		public int[] Characters
		{
			get
			{
				return this._characters;
			}
		}

		public int Key
		{
			get
			{
				return this._virtualkey;
			}
		}

		public VirtualKey(int virtualKey, int attributes, int[] characters)
		{
			this._attributes = attributes;
			this._virtualkey = virtualKey;
			this._characters = characters;
		}
	}
}
