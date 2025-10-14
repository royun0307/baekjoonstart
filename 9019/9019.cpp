#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

inline int opD(int x) {
	return (x * 2) % 10000;
}

inline int opS(int x) {
	return (x == 0 ? 9999 : x - 1);
}

inline int opL(int x) {
	return (x % 1000) * 10 + x / 1000;
}

inline int opR(int x) {
	return (x / 10) + (x % 10) * 1000;
}

int main() {
	ios::sync_with_stdio(false);
	cin.tie(nullptr);

	int t;
	
	cin >> t;

	while (t--) {
		int a, b;
		vector<bool> visit(10000, false);
		vector<int> prev(10000, -1);
		vector<char> how(10000, 0);

		cin >> a >> b;

		queue<int> queue;
		queue.push(a);
		visit[a] = true;

		while (!queue.empty() && !visit[b]) {
			int cur = queue.front();
			const int nexts[4] = { opD(cur), opS(cur), opL(cur), opR(cur) };
			const char commands[4] = { 'D', 'S', 'L', 'R' };

			queue.pop();

			for (int i = 0; i < 4; i++) {
				int next = nexts[i];

				if (!visit[next]) {
					visit[next] = true;
					prev[next] = cur;
					how[next] = commands[i];
					queue.push(next);
					if (next == b) {
						break;
					}
				}
			}
		}

		string result;
		
		for (int v = b; v != a; v = prev[v]) {
			result.push_back(how[v]);
		}

		reverse(result.begin(), result.end());
		cout << result << '\n';
	}
	return 0;
}
