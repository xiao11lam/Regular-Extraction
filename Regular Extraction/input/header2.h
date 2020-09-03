#pragma once
#include ";class ImNotAClassSeven{};.h";

/*

    class ImNotAClassFour{};

*/

class ThisShouldNotBeReportedTwo;

template <class ImNotAClassFive>
class ImTheSecondClass
{
public:
	ImTheSecondClass();
	~ImTheSecondClass();

	ImNotAClassFive anotherMethod(const char someString[] = " class ImNotAClassSix{}; ");
};
