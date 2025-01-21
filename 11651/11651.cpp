#include <iostream>
#include <algorithm>
#include <vector>

bool cmp(std::pair <int, int> a, std::pair <int, int> b) {
	if (a.second == b.second) {
		return a.first < b.first;
	}
	else {
		return a.second < b.second;
	}
}


int main() {
	int n;
	std::pair <int, int> temp;
	std::vector <std::pair <int, int>> ordinate;
	std::cin >> n;
	for (int i = 0; i < n; i++)
	{
		std::cin >> temp.first >> temp.second;
		ordinate.push_back(temp);
	}
	std::sort(ordinate.begin(), ordinate.end(), cmp);

	for (int i = 0; i < n; i++)
	{
		std::cout << ordinate[i].first << " " << ordinate[i].second << "\n";
	}
	return 0;
}
