#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <map>

int main() {
	int n, m;
	std::map <std::string, int> list;
	std::vector <std::string> result;

	std::cin >> n >> m;
	for (int i = 0; i < n + m; i++)
	{
		std::string tmp;
		std::cin >> tmp;
		list[tmp]++;
		if (list[tmp] > 1) {
			result.push_back(tmp);
		}
	}
	std::sort(result.begin(), result.end());
	std::cout << result.size() << std::endl;
	for (int i = 0; i < result.size(); i++)
	{
		std::cout << result[i] << std::endl;
	}
	return 0;
}
