#include "GenerationMap.h"
#include <stdlib.h>
#include <time.h>

GenerationMap::GenerationMap()
{
	srand (time(NULL));
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

void GenerationMap::genererBiome(int* map, int w, int h, int biome, int length) const
{
	int x = rand() % w;
	int y = rand() % h;
	int deplacement;
	for(int i=0; i< length; i++)
	{
		map[y + x*h] = biome;
		deplacement = rand() % 4;
		//switch case en fonction du deplacement
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
