#include <iostream>
#include <sstream>
#include <vector>
#include <unordered_map>

using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(nullptr);

	int t;

	cin >> t;

	while (t--) {
		int n;
		int result = 0;
		unordered_map<string, int> map;
		vector<string> keys;

		cin >> n;

		for (int i = 0; i < n; i++)
		{
			string key;
			string cloth;

			cin >> cloth >> key;

			if (map.find(key) == map.end())
			{
				map.insert(make_pair(key, 1));
				keys.push_back(key);
			}
			else 
			{
				map[key]++;
			}
		}

		for(string key : keys)
		{
			if (result == 0) {
				result = map[key] + 1;
				continue;
			}
			result *= (map[key] + 1);
		}

		result = result == 0 ? 0 : result - 1;

		cout << result << '\n';
	}

	return 0;
}
