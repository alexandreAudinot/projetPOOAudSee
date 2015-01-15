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

		List<int>^ computeSug(int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12)
		{
			int* sol = Suggestion_compute(sug,i0, i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12);
			List<int>^ out = gcnew List<int>();
			for (int i = 0; i < 6; i++)
			{
				out->Add(sol[i]);
			}
			return out;
		}
	};
}
