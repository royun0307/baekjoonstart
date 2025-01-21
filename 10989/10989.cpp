#include <iostream>
#include <algorithm>


int main() {
	std::ios_base::sync_with_stdio(false);
	std::cin.tie(NULL);
	std::cout.tie(NULL);

	int n;
	int temp;
	int arr[10001] = { 0 };
	std::cin >> n;
	for (int i = 0; i < n; i++)
	{
		std::cin >> temp;
		arr[temp]++;
	}

	for (int i = 1; i < 10001; i++)
	{
		for (int j = 0; j < arr[i]; j++)
		{
			std::cout << i << "\n";
		}
	}

	return 0;
}
