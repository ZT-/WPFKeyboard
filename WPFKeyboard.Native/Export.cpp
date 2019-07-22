#include  "KLL.h"

extern "C" {

	__declspec(dllexport) CKLL* GetInstance()
	{
		return new CKLL();
	}

	__declspec(dllexport) void Free(CKLL* ptr)
	{
		delete ptr;
	}

	__declspec(dllexport) bool	LoadDLL(CKLL* ptr, wchar_t* sKeyboardDll)
	{
		return ptr->LoadDLL(sKeyboardDll);
	}

	__declspec(dllexport) 	bool	Is64BitWindows(CKLL* ptr)
	{
		return ptr->Is64BitWindows();
	}

	__declspec(dllexport)  int GetVKCount(CKLL* ptr)
	{
		return ptr->GetVKCount();
	}

	__declspec(dllexport)  CKLL::VK_STRUCT* GetVKAtIndex(CKLL* ptr, int index)
	{
		return ptr->GetVKAtIndex(index);
	}

	__declspec(dllexport)  int GetModifiersCount(CKLL* ptr)
	{
		return ptr->GetModifiersCount();
	}

	__declspec(dllexport)  	CKLL::VK_MODIFIER* GetModifierAtIndex(CKLL* ptr, int index)
	{
		return ptr->GetModifierAtIndex(index);
	}

	__declspec(dllexport) 	int GetScanCodesCount(CKLL* ptr)
	{
		return ptr->GetScanCodesCount();
	}

	__declspec(dllexport) 	CKLL::VK_SCANCODE* GetScanCodeAtIndex(CKLL* ptr, int index)
	{
		auto p = ptr->GetScanCodeAtIndex(index);
		return p;
	}

	__declspec(dllexport) 	int GetScanCodeTextCount(CKLL* ptr)
	{
		return ptr->GetScanCodeTextCount();
	}

	__declspec(dllexport) 	CKLL::SC_TEXT* GetScanCodeTextAtIndex(CKLL* ptr, int index)
	{
		auto p = ptr->GetScanCodeTextAtIndex(index);
		return p;
	}

}

