#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(nullptr);

	int n;
	cin >> n;

	vector<string> grid(n);
	for (int i = 0; i < n; ++i) {
		cin >> grid[i];
	}

	auto inb = [&](int r, int c) { return 0 <= r && r < n && 0 <= c && c < n; };
	const int dir_r[4] = { -1, 1, 0, 0 };
	const int dir_c[4] = { 0, 0, -1, 1 };

	auto count_regions = [&](bool color_blind) {
		vector<vector<bool>> vis(n, vector<bool>(n, false));

		auto same = [&](char a, char b) {
			if (!color_blind) {
				return a == b;
			}
			bool aRG = (a == 'R' || a == 'G');
			bool bRG = (b == 'R' || b == 'G');
			return (aRG && bRG) || (a == b);
			};

		int regions = 0;
		queue<pair<int, int>> q;

		for (int r = 0; r < n; ++r) {
			for (int c = 0; c < n; ++c) {
				if (vis[r][c]) continue;
				regions++;
				vis[r][c] = true;
				q.push({ r,c });
				char base = grid[r][c];

				while (!q.empty()) {
					auto cur = q.front();
					int cr = cur.first;
					int cc = cur.second;
					q.pop();

					for (int k = 0; k < 4; ++k) {
						int nr = cr + dir_r[k], nc = cc + dir_c[k];
						if (!inb(nr, nc) || vis[nr][nc]) continue;
						if (!same(base, grid[nr][nc])) continue;
						vis[nr][nc] = true;
						q.push({ nr, nc });
					}
				}
			}
		}
			return regions;
		};

	int normal = count_regions(false);
	int cb = count_regions(true);

	cout << normal << ' ' << cb << '\n';
	return 0;
}
