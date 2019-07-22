using System;

namespace WPFKeyboardNative
{
    public class KeyboardLayoutHelper
    {
        public static KeyboardLayout GetLayout(string keyboardLayoutDll)
        {
            KeyboardLayout layout = null;
            CKLL kll = null;
            try
            {
                kll = new CKLL();
                bool result = kll.LoadDLL(keyboardLayoutDll);
                if (!result)
                {
                    throw new Exception($"Unabled to load keyboard layout dll {keyboardLayoutDll}.");
                }

                layout = new KeyboardLayout(keyboardLayoutDll);
                for (int i = 0; i < kll.GetModifiersCount(); i++)
                {
                    layout.CharModifiers.Add(
                        new CharModifier(
                            kll.GetModifierAtIndex(i).ModifierBits,
                            kll.GetModifierAtIndex(i).VirtualKey
                            )
                        );
                }
                
                for (int i = 0; i < kll.GetVKCount(); i++)
                {
                    CKLL.VK_STRUCT vk = kll.GetVKAtIndex(i);

                    int[] characters = new int[vk.Characters.Length];

                    for (int y = 0; y < vk.Characters.Length; y++)
                    {
                        characters[y] = (int)vk.Characters[y];
                    }

                    layout.VirtualKeys.Add(
                        new VirtualKey(vk.VirtualKey, vk.Attributes, characters)
                        );
                }


                for (int i = 0; i < kll.GetScanCodesCount(); i++)
                {
                    layout.ScanCodes.Add(
                        new ScanCode(
                        kll.GetScanCodeAtIndex(i).VirtualKey,
                        kll.GetScanCodeAtIndex(i).ScanCode,
                        kll.GetScanCodeAtIndex(i).E0Set,
                        kll.GetScanCodeAtIndex(i).E1Set)
                    );
                }

                for (int i = 0; i < kll.GetScanCodeTextCount(); i++)
                {
                    layout.CodeText.Add(
                        new ScanCodeText(
                            kll.GetScanCodeTextAtIndex(i).ScanCode,
                            //new String(kll.GetScanCodeTextAtIndex(i).Text))
                            kll.GetScanCodeTextAtIndex(i).Text
                            )
                        );
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //kll?.Dispose();
            }
            return layout;
        }
    }
}
