#pragma once

#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#ifdef WANTDLLIMP	
#define DLL _declspec(dllimport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
#endif

class Suggestion
{
public:
	Suggestion();
	~Suggestion();
	void Suggestion_compute(Suggestion* gm, int w, int h);
};

EXTERNC DLL Suggestion* Suggestion_new();
EXTERNC DLL void Suggestion_delete(Suggestion* gm);
EXTERNC DLL void Suggestion_compute(Suggestion* gm, int w, int h);

