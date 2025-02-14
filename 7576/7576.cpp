#include <iostream>
#include <vector>
#include <queue>

using namespace std;

vector <vector<int>> tomato;

int main() {
	int m, n, tmp;
	int unripe_tomato = 0;
	queue <pair<int, int>> queue;
	cin >> m >> n;

	tomato.resize(n, vector<int>(m, 0));

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			cin >> tmp;
			tomato[i][j] = tmp;
			if (tmp == 1) 
			{
				queue.emplace(i, j);
			}
			else if (tmp == 0) {
				unripe_tomato++;
			}
		}
	}

	int dx[4] = { -1, 0, 1, 0 };
	int dy[4] = { 0, 1, 0, -1 };

	int result = -1;

	while (!queue.empty()) {
		int size = queue.size();
		result++;

		for (int i = 0; i < size; i++)
		{
			pair<int, int> node = queue.front();
			queue.pop();

			for (int j = 0; j < 4; j++)
			{
				int nx = node.first + dx[j];
				int ny = node.second + dy[j];

				if (nx >= 0 && nx < n && ny >= 0 && ny < m && tomato[nx][ny] == 0) {
					tomato[nx][ny] = 1;
					unripe_tomato--;
					queue.emplace(nx, ny);
				}
			}
		}
	}

	if (unripe_tomato > 0) {
		cout << -1 << endl;
	}
	else {
		cout << max(0, result) << endl;
	}

	return 0;
}
