#pragma once

#include "../GenerationMap/GenerationMap.h"
#include "../GenerationMap/Suggestion.h"

using namespace System::Collections::Generic;
using namespace System;

namespace Wrapping{
	public ref class Wrapper
	{
	private:
		GenerationMap* algo;
		Suggestion* sug;
	public:
		Wrapper(){ algo = GenerationMap_new(); sug = Suggestion_new(); }
		~Wrapper(){ GenerationMap_delete(algo); Suggestion_delete(sug); }

		List<int>^ compute(int w, int h)
		{
			int* in = GenerationMap_compute(algo, w, h);
			List<int>^ out = gcnew List<int>();

			for (int i = 0; i < w*h; i++)
			{
					out->Add(in[i]);
			}
			return out;
		}

		List<int>^ computeSug(List<int>^ t)
		{
			int tableau[13];
			int i = 0;
			for each(int a in t)
			{
				tableau[i] = a;
				i++;
			}
			int* sol = Suggestion_compute(sug, tableau);
			List<int>^ out = gcnew List<int>();
			for (int i = 0; i < 6; i++)
			{
				out->Add(sol[i]);
			}
			return out;
		}
	};
}
