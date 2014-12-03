#include "GenerationMap.h"

GenerationMap::GenerationMap()
{
}

GenerationMap::~GenerationMap()
{
}

int* GenerationMap::generer(int w, int h) const
{
	// Algo de génération de map

	int* out = new int[w*h]();

	for (int i = 0; i < w; i++)
	{
		for (int j = 0; j < h; j++)
		{
			out[j + i*h] = 42;
		}
	}

	return out;
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
