#include <iostream>
#include <queue>

using namespace std;

int main() {
	const int max = 100;
	int n, m;
	int load[max][max];
	int time[max][max];
	string row;
	pair <int, int> current;
	pair <int, int> next;
	queue <pair<int, int>> find;

	cin >> n >> m;
	
	for (int i = 0; i < n ; i++)
	{
		cin >> row;
		for (int j = 0; j < m; j++)
		{
			load[i][j] = row[j] - '0';
			time[i][j] = 99999999;
		}
	}

	time[0][0] = 1;
	find.push(make_pair(0, 0));

	while (true)
	{	
		current = find.front();
		find.pop();
		int current_time = time[current.first][current.second];
		if (current.first == n - 1 && current.second == m - 1) {
			break;
		}
		//up
		if (current.second > 0 && load[current.first][current.second - 1] == 1 && current_time + 1 < time[current.first][current.second - 1]) {
			time[current.first][current.second - 1] = current_time + 1;
			find.push(make_pair(current.first, current.second - 1));
		}
		//down
		if (current.second < 99 && load[current.first][current.second + 1] == 1 && current_time + 1 < time[current.first][current.second + 1]) {
			time[current.first][current.second + 1] = current_time + 1;
			find.push(make_pair(current.first, current.second + 1));
		}
		//right
		if (current.first > 0 && load[current.first - 1][current.second] == 1 && current_time + 1 < time[current.first - 1][current.second]) {
			time[current.first - 1][current.second] = current_time + 1;
			find.push(make_pair(current.first - 1, current.second));
		}
		//left
		if (current.first < 99 && load[current.first + 1][current.second] == 1 && current_time + 1 < time[current.first + 1][current.second]) {
			time[current.first + 1][current.second] = current_time + 1;
			find.push(make_pair(current.first + 1, current.second));
		}
	}
	cout << time[n - 1][m - 1] << endl;

	return 0;
}
