#include <iostream>

using namespace std;

int main() {
	long long array[101] = { 0, 1, 1, };
	int index = 2, t;

	cin >> t;

	while (t--) {
		int n;

		cin >> n;

		if(n > index) {
			for (int i = index + 1; i < n + 1; i++)
			{
				array[i] = array[i - 2] + array[i - 3];
			}
			index = n;
		}
		cout << array[n] << endl;
	}
}
