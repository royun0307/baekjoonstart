#include <iostream>
#include <vector>

using namespace std;

int main() {
	int t;

	cin >> t;

	vector <int> base = { 0, 1, 2, 4};

	while (t--) {
		int n;
		
		cin >> n;

		vector <int> dp = base;
		if (n <= 3) {
			cout << dp[n] << endl;
		}
		else {
			for (int i = 4; i < n + 1; i++)
			{
				dp.push_back(dp[i - 3] + dp[i - 2] + dp[i - 1]);
			}

			cout << dp[n] << endl;
		}
	}
	return 0;
}
