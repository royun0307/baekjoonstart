#include <iostream>

int main() {
	int n, m, b, time, min_time, height;
	int min = 256;
	int max = 0;
	int use, get;
	int map[500][500];
	bool flag = true;
	std::cin >> n >> m >> b;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			std::cin >> map[i][j];
			if (map[i][j] < min) {
				min = map[i][j];
			}
			if (map[i][j] > max) {
				max = map[i][j];
			}
		}
	}
	min_time = 0;
	height = 0;
	for (int k = min; k < max + 1; k++)
	{
		time = 0;
		get = 0;
		use = 0;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				if (map[i][j] > k) {
					get += map[i][j] - k;
				}
				else if (map[i][j] < k) {
					use += k - map[i][j];
				}
			}
		}
		if (get - use + b >= 0) {
			time = get * 2 + use;		
			if (flag == true || min_time >= time) {
				height = k;
				min_time = time;
				flag = false;
				std::cout << max;
				std::cout << min_time << " " << height << std::endl;
			}
		}
	}
	std::cout << min_time << " " << height << std::endl;
	return 0;
}
