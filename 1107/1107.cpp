#include <iostream>
#include <string>

bool button[10];

bool button_con(int n) {
	std::string but = std::to_string(n);
	for (int i = 0; i < but.length(); i++)
	{
		if (button[but[i] - '0'] == false) {
			return false;
		}
	}
	return true;
}

int main() {
	int m, n, wrong_button, result, num, min, max;
	int k = 0;
	int current_chanel = 100;

	std::fill_n(button, 10, true);
	std::cin >> n >> m;
	for (int i = 0; i < m; i++)
	{
		std::cin >> wrong_button;
		button[wrong_button] = false;
	}
	
	result = std::abs(n - current_chanel);

	for (int i = 0; i <= 1000000; i++)
	{
		if (button_con(i)) {
			num = std::abs(n - i) + std::to_string(i).length();
			result = std::min(result, num);
		}
	}
	std::cout << result << std::endl;
	return 0;
}
