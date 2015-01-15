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
	int forest = h*h / 4;
	int mountain = h * h / 4;
	int desert = h * h / 4;
	int plain = h * h / 4;
	bool accept = false;
	int cpt = 0;
	int rn;
	while (cpt < w*h)
	{
		do {
			rn = rand() % 4;
			switch (rn)
			{
			case 0:
				if (mountain > 0)
				{
					mountain--;
					accept = true;
					out[cpt] = 0;
					cpt++;
				}
				break;
			case 1:
				if (desert > 0)
				{
					desert--;
					accept = true;
					out[cpt] = 1;
					cpt++;
				}
				break;
			case 2:
				if (forest > 0)
				{
					forest--;
					accept = true;
					out[cpt] = 2;
					cpt++;
				}
				break;
			case 3:
				if (plain > 0)
				{
					plain--;
					accept = true;
					out[cpt] = 3;
					cpt++;
				}
				break;
			}
		} while (!accept);
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
