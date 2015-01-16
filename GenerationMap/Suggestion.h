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
	int* Suggestion_compute(Suggestion* gm, int* t);
	int* Suggestion::generer(int* t);
};

EXTERNC DLL Suggestion* Suggestion_new();
EXTERNC DLL void Suggestion_delete(Suggestion* gm);
EXTERNC DLL int* Suggestion_compute(Suggestion* gm, int* t);

