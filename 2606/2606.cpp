#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
	int stair_num, score;

	cin >> stair_num;

	vector <int> stair_score(stair_num);
	vector <vector<int>> dp(stair_num, vector<int>(2));

	for (int i = 0; i < stair_num; i++)
	{
		cin >> score;
		stair_score[i] = score;
	}
	if (stair_num < 2) {
		cout << stair_score[0] << endl;
		return 0;
	}

	dp[0][0] = stair_score[0];
	dp[0][1] = 0;
	dp[1][0] = dp[0][0] + stair_score[1];
	dp[1][1] = stair_score[1];

	for (int i = 2; i < stair_num; i++)
	{
		dp[i][0] = dp[i - 1][1] + stair_score[i];
		dp[i][1] = max(dp[i - 2][0], dp[i - 2][1]) + stair_score[i];
	}

	cout << max(dp[stair_num - 1][0], dp[stair_num - 1][1]) << endl;

	return 0;
}
