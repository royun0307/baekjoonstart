#include <iostream>
#include <deque>
#include <string>
#include <algorithm>

using namespace std;

int main() {
	int t;
	

	cin >> t;
	while (t--)
	{
		string p, arr, tmp = "";
		int size;
		bool front = true;
		bool isFlag = true;
		deque<int> deque;

		cin >> p;
		cin >> size;
		cin >> arr;
		
		for (int i = 1; i < arr.size(); i++)
		{
			if (arr[i] == ',' || arr[i] == ']') {
				if (tmp != "") {
					deque.push_back(stoi(tmp));
					tmp = "";
				}
			}
			else {
				tmp += arr[i];
			}
		}
		for (int i = 0; i < p.size(); i++)
		{
			if (p[i] == 'R') {
				front = !front;
			}
			else if (p[i] == 'D') {
				if (deque.empty()) {
					isFlag = false;
					i = p.size();
					break;
				}
				if (front) {
					deque.pop_front();
				}
				else {
					deque.pop_back();
				}
			}
		}
		if (!isFlag) {
			cout << "error" << endl;
		}
		else {
			if (!front) {
				reverse(deque.begin(), deque.end());
			}
			cout << "[";
			if (!deque.empty()) {
				cout << deque[0];
			}
			for (int i = 1; i < deque.size(); i++)
			{
				cout << "," << deque[i];
			}
			cout << "]" << endl;
		}
	} 
	return 0;
}
