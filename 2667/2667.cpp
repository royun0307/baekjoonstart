#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

void solve(vector<vector<int>> &apt, vector<int> &result, int x, int y, int n) {
	if (x < 0 || y < 0 || x >= apt[0].size() || y >= apt[0].size() || apt[x][y] == 0) {
		return;
	}
	result[n]++;
	apt[x][y] = 0;
	solve(apt, result, x + 1, y, n);
	solve(apt, result, x, y + 1, n);
	solve(apt, result, x - 1, y, n);
	solve(apt, result, x, y - 1, n);
	return;
}

int main() {
	int size, tmp, n;
	string str;
	n = 0;
	cin >> size;

	vector<vector<int>> apartment(size, vector<int>(size));
	vector<int> result;


	for (int i = 0; i < size; i++)
	{
		cin >> str;
		for (int j = 0; j < size; j++)
		{
			apartment[i][j] = str[j]-'0';
		}
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (apartment[i][j] == 1){
				result.push_back(0);
				solve(apartment, result, i, j, n++);
			}
		}
	}
	cout << result.size() << "\n";
	sort(result.begin(), result.end());
	for (int i = 0; i < result.size(); i++)
	{
		cout << result[i] << '\n';
	}
	return 0;
}
