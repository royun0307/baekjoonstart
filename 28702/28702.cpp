#include <iostream>
#include <array>
#include <string>
#include <cctype>

int main() {
	int next;
	std::array <std::string, 3> FizzBuzz;

	std::cin >> FizzBuzz[0] >> FizzBuzz[1] >> FizzBuzz[2];

	for (int i = 0; i < 3; i++)
	{
		if (std::isdigit(FizzBuzz[i][0])) {
			next = std::stoi(FizzBuzz[i]) + 3 - i;
			break;
		}
	}
	if (next % 3 == 0) {
		if (next % 5 == 0) {
			std::cout << "FizzBuzz" << std::endl;
		}
		else {
			std::cout << "Fizz" << std::endl;
		}
	}
	else if (next % 5 == 0) {
		std::cout << "Buzz" << std::endl;
	}
	else {
		std::cout << next << std::endl;
	}

	return 0;
}
