#include <iostream>
#include <string>
using namespace std;

int main() {
    ios::sync_with_stdio(false);
    cin.tie(nullptr);

    int M;
    cin >> M;
    int bitmask = 0;

    while (M--) {
        int x;
        string tmp;

        cin >> tmp;

        if (tmp == "add") {
            cin >> x;
            bitmask |= (1 << (x - 1));
        }
        else if (tmp == "remove") {
            cin >> x;
            bitmask &= ~(1 << (x - 1));
        }
        else if (tmp == "check") {
            cin >> x;
            cout << ((bitmask & (1 << (x - 1))) ? 1 : 0) << "\n";
        }
        else if (tmp == "toggle") {
            cin >> x;
            bitmask ^= (1 << (x - 1));
        }
        else if (tmp == "all") {
            bitmask = (1 << 20) - 1;
        }
        else if (tmp == "empty") {
            bitmask = 0;
        }
    }
    return 0;
}
