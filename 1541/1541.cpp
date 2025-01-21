#include <iostream>
#include <string>

int main() {
	std::string input;
	int num;
	int count = 0;
	int result = 0;
	bool minus = false;
	std::cin >> input;

	for (int i = 0; i < input.size() + 1; i++)
	{
		if (input[i] == '-' || input[i] == '+' || i == input.size()) {
			num = std::stoi(input.substr(i - count, count));
			if (minus == true) {
				result -= num;
			}
			else {
				result += num;
			}
			count = 0;
		}
		else {
			count++;
		}
		if (minus == false && input[i] == '-') {
			minus = true;
		}
	}
	std::cout << result << std::endl;
	return 0;
}
