#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

bool cmp(int a, int b) {
	return a > b;
}

int main() {
	long long n, m;

	cin >> n >> m;

	vector<long long> tree;

	for (int i = 0; i < n; i++)
	{
		long long tmp;
		cin >> tmp;
		tree.push_back(tmp);
	}

	sort(tree.begin(), tree.end(), cmp);

	long long low = 0;
	long long high = tree[0];
	long long result = 0;

	while (low <= high) {
		long long mid = (high + low) / 2;
		long long total = 0;

		for (int i = 0; i < n; i++)
		{
			if (tree[i] <= mid) {
				break;
			}
			total += tree[i] - mid;
		}

		if (total >= m) {
			result = mid;
			low = mid + 1;
		}
		else{
			high = mid - 1;
		}
	}
	
	cout << result << endl;

	return 0;
}
