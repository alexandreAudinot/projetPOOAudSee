#pragma once

#include "../GenerationMap/GenerationMap.h"


using namespace System;

namespace Wrapping{
	public ref class Wrapper
	{
	private:
		GenerationMap* algo;
	public:
		Wrapper(){  algo = GenerationMap_new(); }
		~Wrapper(){ GenerationMap_delete(algo); }
		void compute(){ GenerationMap_compute(algo); }
	};
}
