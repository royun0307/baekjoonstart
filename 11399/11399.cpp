#include <iostream>
#include <queue>

using namespace std;

int main() {
	int n, res = 0, last = 0;
	priority_queue <int, vector<int>, greater<int>> pq;

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		int tmp;
		cin >> tmp;
		pq.push(tmp);
	}

	while (!pq.empty())
	{
		last += pq.top();
		res += last;
		pq.pop();
	}

	cout << res << endl;

	return 0;
}
