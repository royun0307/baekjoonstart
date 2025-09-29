#include <iostream>

using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(nullptr);

	int n, m, result = 0, cnt = 0;
	string s;

	cin >> n >> m >> s;
	
	for (int i = 1; i + 1 < m;)
	{
		if (s[i - 1] == 'I' && s[i] == 'O' && s[i + 1] == 'I') 
		{
			cnt++;
			if (cnt == n) 
			{
				result++;
				cnt--;
			}
			i += 2;
		}
		else 
		{
			cnt = 0;
			i += 1;
		}
	}
	cout << result << '\n';
}
