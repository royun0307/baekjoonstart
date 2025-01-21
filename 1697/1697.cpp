#include <iostream>
#include <queue>

void bfs(int n, int k) {
	int visited[100001] = { 0, };
	std::queue <int> q;

	q.push(n);

	while (visited[k] == 0)
	{
		int x = q.front();
		q.pop();
		if (x > 0 && (visited[x - 1] == 0 || visited[x - 1] > visited[x] + 1)) {
			visited[x - 1] = visited[x] + 1;
			q.push(x - 1);
		}
		if (x + 1 < 100001 && (visited[x + 1] == 0 || visited[x + 1] > visited[x] + 1)) {
			visited[x + 1] = visited[x] + 1;
			q.push(x + 1);
		}
		if (x * 2 < 100001 && (visited[x * 2] == 0 || visited[x * 2] > visited[x] + 1)) {
			visited[x * 2] = visited[x] + 1;
			q.push(x * 2);
		}
	}

	std::cout << visited[k] << std::endl;
}

int main() {
	int N, K;
	std::cin >> N >> K;
	if (N != K) {
		bfs(N, K);
	}
	else {
		std::cout << 0 << std::endl;
	}
	return 0;
}
