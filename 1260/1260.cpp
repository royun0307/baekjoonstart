#include <iostream>
#include <vector>
#include <queue>

struct Node
{
	bool visit = false;
	std::vector <bool> adj;
};

class Graph {
public:
	Graph(int _size) {
		size = _size;
		Node tmp;
		for (int i = 0; i < size + 1; i++)
		{
			tmp.adj.push_back(false);
		}
		for (int i = 0; i < size + 1; i++)
		{
			member.push_back(tmp);
		}
	}

	void Connect(int a, int b) {
		member[a].adj[b] = true;
		member[b].adj[a] = true;
	}
	void DSF(int current) {
		if (member[current].visit == true) {
			return;
		}
		member[current].visit = true;
		std::cout << current << " ";
		for (int i = 1; i < size + 1; i++)
		{
			if (member[current].adj[i] == true) {
				DSF(i);
			}
		}
		return;
	}
	void reset() {
		for (int i = 1; i < size + 1; i++)
		{
			member[i].visit = false;
		}
		return;
	}
	void BSF(int current) {
		std::queue <int> q;
		q.push(current);
		member[current].visit = true;
		std::cout << current << " ";
		int tmp;
		while (!q.empty()) {
			tmp = q.front();
			q.pop();

			for (int i = 1; i < size + 1; i++) {
				if (member[tmp].adj[i] == true && member[i].visit == false) {
					q.push(i);
					member[i].visit = true;
					std::cout << i << " ";
				}
			}
		}
	}
private:
	int size;
	std::vector <Node> member;
};

int main() {
	int n, m, v, a, b;
	std::cin >> n >> m >> v;
	Graph graph(n);
	for ( int i = 0; i < m; i++)
	{
		std::cin >> a >> b;
		graph.Connect(a, b);
	}
	graph.DSF(v);
	std::cout << std::endl;
	graph.reset();
	graph.BSF(v);
	return 0;
}
