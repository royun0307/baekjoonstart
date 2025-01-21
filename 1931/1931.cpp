#include <iostream>
#include <queue>

int main() {
	std::ios_base::sync_with_stdio(false);
	std::cin.tie(NULL);
	std::cout.tie(NULL);

	int n;
	int num;
	std::priority_queue <int, std::vector <int>, std::greater<int>> heap;

	std::cin >> n;
	for (int i = 0; i < n; i++)
	{
		std::cin >> num;
		if (num == 0) {
			if (heap.empty()) {
				std::cout << 0 << "\n";
			}
			else {
				std::cout << heap.top() << "\n";
				heap.pop();
			}
		}
		else {
			heap.push(num);
		}
	}
	return 0;
}
