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


class GenerationMap
{
public:
	GenerationMap();
	~GenerationMap();
	void generer() const;
};

EXTERNC DLL GenerationMap* GenerationMap_new();
EXTERNC DLL void GenerationMap_delete(GenerationMap* gm);
EXTERNC DLL void GenerationMap_compute(GenerationMap* gm);

