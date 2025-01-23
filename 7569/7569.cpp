#include <iostream>
#include <vector>
#include <queue>

using namespace std;

struct Position
{
	int x, y, z, day;
};

int riped_day_max = 0;
int unripe_num = 0;
int dz[6] = { 0, 0, 0, 0, 1, -1 };
int dx[6] = { -1, 1, 0, 0, 0, 0 };
int dy[6] = { 0, 0, -1, 1, 0, 0 };
queue<Position> que;

void solve(vector<vector<vector<int>>> &tomato) {
	while (!que.empty()) {
		Position p = que.front();
		que.pop();
		int x = p.x;
		int y = p.y;
		int z = p.z;
		int day = p.day;

		for (int i = 0; i < 6; i++) {
			int nx = p.x + dx[i];
			int ny = p.y + dy[i];
			int nz = p.z + dz[i];

			if (nx >= 0 && nx < tomato.size() && ny >= 0 && ny < tomato[0].size() && nz >= 0 && nz < tomato[0][0].size()) {
				if (tomato[nx][ny][nz] == 0) {  
					tomato[nx][ny][nz] = 1;
					unripe_num--;
					if (riped_day_max < day + 1) {
						riped_day_max = day + 1;
					}
					que.push({ nx, ny, nz, day + 1 });
				}
			}
		}
	}
	return;
}

int main() {
	int m, n, h, tmp;

	cin >> m >> n >> h;

	vector<vector<vector<int>>> tomato(m, vector<vector<int>>(n, vector<int>(h)));

	for (int z = 0; z < h; z++)
	{
		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < m; x++)
			{
				cin >> tmp;
				tomato[x][y][z] = tmp;
				if (tmp == 0) {
					unripe_num++;
				}
				else if (tmp == 1) {
					Position p;
					p.x = x;
					p.y = y;
					p.z = z;
					p.day = 0;
					que.push(p);
				}
			}
		}
	}
	if (unripe_num == 0) {
		cout << 0 << endl;
		return 0;
	}
	solve(tomato);
	if (unripe_num != 0) {
		cout << -1 << endl;
	}
	else {
		cout << riped_day_max << endl;
	}
	return 0;
}
