#pragma once
// class ImNotAClassOne{};

const int globalInteger = 1; // class ImNotAClassTwo{};
const char globalString[] = " class ImNotAClassThree{}; ";

class ImTheFirstClass
{
public:
	ImTheFirstClass();
	~ImTheFirstClass();

	class ThisShouldNotBeReportedOne
	{
		ThisShouldNotBeReported();
		~ThisShouldNotBeReported();
	};
};
