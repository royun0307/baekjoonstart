#include <iostream>
#include <vector>

using namespace std;

void solve(vector<vector<int>>& paper, int result[], int x, int y, int size) {
	int color = paper[x][y];
	for (int i = x; i < size + x; i++)
	{
		for (int j = y; j < size + y; j++)
		{
			if (paper[i][j] != color) {
				solve(paper, result, x, y, size / 2);
				solve(paper, result, x + size / 2, y, size / 2);
				solve(paper, result, x, y + size / 2, size / 2);
				solve(paper, result, x + size / 2, y + size / 2, size / 2);
				return;
			}
		}
	}
	result[color]++;
	return;
}

int main() {
	int n, tmp;
	int res[2] = {0, 0};
	cin >> n;

	vector <vector<int>> paper(n, vector<int>(n));

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cin >> tmp;
			paper[i][j] = tmp;
		}
	}
	solve(paper, res, 0, 0, n);
	cout << res[0] << "\n" << res[1] << "\n";
	return 0;
}
