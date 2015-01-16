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

int* Suggestion::generer(int* tab)
{
	int t[6];
	int hp = tab[0];
	//première case
	if (tab[1] == -1)
	{
		t[0] = 1;
	}
	else
	{
		if (tab[1] == 1)
		{
			t[0] = 0;
		}
		else
		{
			if (tab[0] >= tab[2])
			{
				t[0] = 1;
			}
		}
	}
	//deuxième case
	if (tab[3] == -1)
	{
		t[1] = 1;
	}
	else
	{
		if (tab[3] == 1)
		{
			t[1] = 0;
		}
		else
		{
			if (tab[0] >= tab[4])
			{
				t[1] = 1;
			}
		}
	}
	//troisième case
	if (tab[5] == -1)
	{
		t[2] = 1;
	}
	else
	{
		if (tab[5] == 1)
		{
			t[2] = 0;
		}
		else
		{
			if (tab[0] >= tab[6])
			{
				t[2] = 1;
			}
		}
	}
		//quatrième case
	if (tab[7] == -1)
		{
			t[3] = 1;
		}
		else
		{
			if (tab[7] == 1)
			{
				t[3] = 0;
			}
			else
			{
				if (tab[0] >= tab[8])
				{
					t[3] = 1;
				}
			}
		}
			//cinquième case
			if (tab[9] == -1)
			{
				t[4] = 1;
			}
			else
			{
				if (tab[9] == 1)
				{
					t[4] = 0;
				}
				else
				{
					if (tab[0] >= tab[10])
					{
						t[4] = 1;
					}
				}
			}

			//sixième case
			if (tab[11] == -1)
			{
				t[5] = 1;
			}
			else
			{
				if (tab[11]== 1)
				{
					t[5] = 0;
				}
				else
				{
					if (tab[0] >= tab[12])
					{
						t[5] = 1;
					}
				}
			}
			
				return t;
	}

int*  Suggestion_compute(Suggestion* gm, int* t)
{
	return gm->generer(t);
}
