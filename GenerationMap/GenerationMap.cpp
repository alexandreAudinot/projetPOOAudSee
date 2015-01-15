#include "GenerationMap.h"
#include <stdlib.h>
#include <time.h>

GenerationMap::GenerationMap()
{
	srand((unsigned int)time(NULL));
}

GenerationMap::~GenerationMap()
{
}

int* GenerationMap::generer(int w, int h) const
{
	// Algo de génération de map

	int* out = new int[w*h]();
	
	initialiser(out, w, h);

	for (int i = 0; i < w; i++)
	{
		for (int j = 0; j < h; j++)
		{
			out[j + i*h] = 42;
		}
	}

	return out;
}

void GenerationMap::initialiser(int* map, int w, int h) const
{
	for (int i = 0; i < w; i++)
	{
		for (int j = 0; j < h; j++)
		{
			map[j + i*h] = -1;
		}
	}
}





GenerationMap* GenerationMap_new()
{
	return new GenerationMap();
}

void GenerationMap_delete(GenerationMap* gm)
{
	delete gm;
}

int*  GenerationMap_compute(GenerationMap* gm, int w, int h)
{
	return gm->generer(w, h);
}
