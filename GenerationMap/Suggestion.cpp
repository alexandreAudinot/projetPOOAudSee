#include "Suggestion.h"
#include <stdlib.h>
#include <time.h>

Suggestion::Suggestion()
{
	srand((unsigned int)time(NULL));
}

Suggestion::~Suggestion()
{
}

Suggestion* Suggestion_new()
{
	return new Suggestion();
}

void Suggestion_delete(Suggestion* gm)
{
	delete gm;
}

void  Suggestion_compute(Suggestion* gm, int w, int h)
{
	
}
