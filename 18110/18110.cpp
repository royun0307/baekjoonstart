#include <iostream>
#include <algorithm>
#include <vector>
#include <cmath>

int main() {
	int n;
	int cut;
	int result = 0;
	double temp;
	double sum = 0;
	std::vector <double> vector;
	std::cin >> n;
	if (n == 0) {
		std::cout << 0 << std::endl;
		return 0;
	}

	cut = (int)std::round((double)n * 0.15);
	for (int i = 0; i < n; i++)
	{
		std::cin >> temp;
		vector.push_back(temp);
	}
	std::sort(vector.begin(), vector.end());
	for (int i = cut; i < n - cut; i++)
	{
		sum += vector[i];
	}
	result = (int)std::round(sum / (n - cut * 2));
	std::cout << result << std::endl;
	return 0;
}
