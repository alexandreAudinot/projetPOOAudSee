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

int* Suggestion::generer(int i0, int i1, int i2, int i3, int i4, int i5,
	int i6, int i7, int i8, int i9, int i10, int i11, int i12)
{
	int t[6];
	int hp = i0;
	//première case
	if (i1 == -1)
	{
		t[0] = 1;
	}
	else
	{
		if (i1 == 1)
		{
			t[0] = 0;
		}
		else
		{
			if (i0 >= i2)
			{
				t[0] = 1;
			}
		}
	}
	//deuxième case
	if (i3 == -1)
	{
		t[1] = 1;
	}
	else
	{
		if (i3 == 1)
		{
			t[1] = 0;
		}
		else
		{
			if (i0 >= i4)
			{
				t[1] = 1;
			}
		}
	}
	//troisième case
	if (i5 == -1)
	{
		t[2] = 1;
	}
	else
	{
		if (i5 == 1)
		{
			t[2] = 0;
		}
		else
		{
			if (i0 >= i6)
			{
				t[2] = 1;
			}
		}
	}
		//quatrième case
		if (i7 == -1)
		{
			t[3] = 1;
		}
		else
		{
			if (i7 == 1)
			{
				t[3] = 0;
			}
			else
			{
				if (i0 >= i8)
				{
					t[3] = 1;
				}
			}
		}
			//cinquième case
			if (i9 == -1)
			{
				t[4] = 1;
			}
			else
			{
				if (i9 == 1)
				{
					t[4] = 0;
				}
				else
				{
					if (i0 >= i10)
					{
						t[4] = 1;
					}
				}
			}

			//sixième case
			if (i11 == -1)
			{
				t[5] = 1;
			}
			else
			{
				if (i11 == 1)
				{
					t[5] = 0;
				}
				else
				{
					if (i0 >= i12)
					{
						t[5] = 1;
					}
				}
			}
			
				return t;
	}

int*  Suggestion_compute(Suggestion* gm, int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12)
{
	return gm->generer(i0, i1, i2, i3, i4, i5,i6,i7,i8,i9,i10,i11,i12);
}
