#include "GenerationMap.h"

GenerationMap::GenerationMap()
{
}

GenerationMap::~GenerationMap()
{
}

void GenerationMap::generer() const
{
	// Algo de génération de map


}

GenerationMap* GenerationMap_new()
{
	return new GenerationMap();
}

void GenerationMap_delete(GenerationMap* gm)
{
	delete gm;
}

void  GenerationMap_compute(GenerationMap* gm)
{
	gm->generer();
}
