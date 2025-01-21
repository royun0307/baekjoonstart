#include <iostream>
#include <vector>
#include <algorithm>

int main() {
	int n;
	std::cin >> n;
	std::vector <int> make1(n + 1);
	make1[1] = 0;
	for (int i = 2; i < n + 1; i++)
	{
		make1[i] = make1[i - 1] + 1;
		if (i % 2 == 0) {
			make1[i] = std::min(make1[i], make1[i / 2] + 1);
		}
		if (i % 3 == 0) {
			make1[i] = std::min(make1[i], make1[i / 3] + 1);
		}
	}
	std::cout << make1[n] << std::endl;
	return 0;
}
