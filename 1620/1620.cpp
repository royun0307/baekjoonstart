#include <iostream>
#include <vector>
#include <string>
#include <map>

int main() {
	std::ios::sync_with_stdio(false);
	std::cin.tie(NULL);
	int n, m;
	std::vector <std::string> poketmon_name;
	std::map <std::string, int> poketmon_number;
	std::string tmp;
	std::string result;

	std::cin >> n >> m;
	for (int i = 0; i < n; i++)
	{
		std::cin >> tmp;
		poketmon_name.push_back(tmp);
		poketmon_number.insert(std::make_pair(tmp, i + 1));
	}

	for (int i = 0; i < m; i++)
	{
		std::cin >> tmp;
		if (tmp[0] >= 65 && tmp[0] <= 90) {
			result = std::to_string(poketmon_number[tmp]);
		}
		else {
			result = poketmon_name[std::stoi(tmp) - 1];
		}
		std::cout << result << "\n";
	}
	return 0;
}
