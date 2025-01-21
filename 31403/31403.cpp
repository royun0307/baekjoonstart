#include <iostream>
#include <string>

int main() {
	int result;
	std::string a, b, c;
	std::cin >> a >> b >> c;

	result = std::stoi(a) + std::stoi(b) - std::stoi(c);
	std::cout << result << std::endl;

	result = std::stoi(a + b) - std::stoi(c);
	std::cout << result << std::endl;

	return 0;
}
