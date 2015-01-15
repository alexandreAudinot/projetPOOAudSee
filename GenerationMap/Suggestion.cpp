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

void Suggestion::generer(int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12)
{
	int t[6];
	int hp = i0;
	if (i1 == -1)
	{
		t[0] = 1;
	}
	else
	{
	}
}

void  Suggestion_compute(Suggestion* gm, int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12)
{
	gm->generer(i0, i1, i2, i3, i4, i5,i6,i7,i8,i9,i10,i11,i12);
}
