#include <iostream>

int main() {
	int t_count = 0;
	int t, p, n, p_count, p_single;
	int size[6] = { 0 , };

	std::cin >> n;
	for (int i = 0; i < 6; i++)
	{
		std::cin >> size[i];
	}
	std::cin >> t >> p;
	
	for (int i = 0; i < 6; i++)
	{
		t_count += size[i] / t;
		if (size[i] % t != 0) {
			t_count++;
		}
	}
	p_count = n / p;
	p_single = n % p;

	std::cout << t_count << "\n" << p_count << " " << p_single << std::endl;

	return 0;
}
