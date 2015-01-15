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
	void Suggestion_compute(Suggestion* gm, int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12);
	void Suggestion::generer(int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12);
};

EXTERNC DLL Suggestion* Suggestion_new();
EXTERNC DLL void Suggestion_delete(Suggestion* gm);
EXTERNC DLL void Suggestion_compute(Suggestion* gm, int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12);

