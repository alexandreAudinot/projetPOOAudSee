#pragma once

#include "../GenerationMap/GenerationMap.h"

using namespace System::Collections::Generic;
using namespace System;

namespace Wrapping{
	public ref class Wrapper
	{
	private:
		GenerationMap* algo;
	public:
		Wrapper(){  algo = GenerationMap_new(); }
		~Wrapper(){ GenerationMap_delete(algo); }

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
	};
}
