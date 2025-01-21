#include <iostream>


int main() {
	long long m = 1234567891;
	long long r = 31;
	long long pow_r;
	long long hash = 0;
	int num = 0;
	int l;
	std::string s;
	std::cin >> l;
	std::cin >> s;
	for (int i = 0; i < l; i++)
	{
		pow_r = 1;
		num = s[i] - 96;
		for (int j = 0; j < i; j++)
		{
			pow_r = (pow_r * r) % m;
		}
		hash += ((long long)num * pow_r) % m;
		hash = hash % m;
	}
	std::cout << hash << std::endl;
}
