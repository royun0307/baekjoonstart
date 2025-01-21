#include <iostream>

int distance[101][101];


int main() {
	int n, m, a, b, tmp, result;
	int min = 999999;
	std::cin >> n >> m;
	std::fill(&distance[0][0], &distance[100][100], 999999);
	for (int i = 1; i < n + 1; i++)
	{
		distance[i][i] = 0;
	}
	for (int i = 0; i < m; i++)
	{
		int a, b;
		std::cin >> a >> b;
		distance[a][b] = 1;
		distance[b][a] = 1;
	}
	for (int k = 1; k < n + 1; k++)
	{
		for (int i = 1; i < n + 1; i++)
		{
			for (int j = 1; j < n + 1; j++)
			{
				if (distance[i][k] + distance[k][j] < distance[i][j]) {
					distance[i][j] = distance[i][k] + distance[k][j];
				}
			}
		}
	}
	for (int i = 1; i < n + 1; i++)
	{
		tmp = 0;
		for (int j = 1; j < n + 1; j++)
		{
			//std::cout << distance[i][j] << " ";
			tmp += distance[i][j];
		}
		//std::cout << std::endl;
		if (tmp < min) {
			min = tmp;
			result = i;
		}
	}
	std::cout << result << std::endl;
	return 0;
}
