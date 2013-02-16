
// MFCApplication1.h: archivo de encabezado principal para la aplicación MFCApplication1
//
#pragma once

#ifndef __AFXWIN_H__
	#error "incluir 'stdafx.h' antes de incluir este archivo para PCH"
#endif

#include "resource.h"       // Símbolos principales


// CMFCApplication1App:
// Consulte la sección MFCApplication1.cpp para obtener información sobre la implementación de esta clase
//

class CMFCApplication1App : public CWinAppEx
{
public:
	CMFCApplication1App();


// Reemplazos
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementación
	UINT  m_nAppLook;
	BOOL  m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMFCApplication1App theApp;
