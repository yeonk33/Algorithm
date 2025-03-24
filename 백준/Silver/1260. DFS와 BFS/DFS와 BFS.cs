using System.Linq;
using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StringBuilder sb = new StringBuilder();

List<string> inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
List<Node> nodes = new List<Node>();
string[] info = inputs[0].Split(' ');
int startNumber = Convert.ToInt32(info[2]);
nodes.Add(new Node { number = startNumber, near = new List<int>() });
inputs.RemoveAt(0);

// DFS
foreach (var s in inputs) {
	string[] e = s.Split(' ');
	int a = Convert.ToInt32(e[0]);
	int b = Convert.ToInt32(e[1]);
	
	if (!nodes.Exists(x => x.number == a)) {
		Node n = new Node { number = a, near = new List<int> { b } };
		nodes.Add(n);
	} else {
		nodes[nodes.FindIndex(x => x.number == a)].near.Add(b);
	}

	if (!nodes.Exists(x => x.number == b)) {
		Node n = new Node { number = b, near = new List<int> { a } };
		nodes.Add(n);
	} else {
		nodes[nodes.FindIndex(x => x.number == b)].near.Add(a);
	}
}

Search(nodes.Find(x => x.number == startNumber));
sb.Append("\n");

// Visited reset
foreach (Node n in nodes) {
	n.visited = false;
}

// BFS
Queue<Node> nodes_q = new Queue<Node>();
Node startNode = nodes.Find(x => x.number == startNumber);
//if (startNode != null) {
	nodes_q.Enqueue(startNode);
	//startNode.visited = true;
	sb.Append(startNode.number + " ");
//}

while (nodes_q.Count > 0) {
	Node node = nodes_q.Dequeue();
	node.visited = true;
	if (node.near == null) break;
	node.near.Sort();
	foreach (int n in node.near) {
		Node curNode = nodes.Find(x => x.number == n);
		if (curNode == null) break;
		if (!curNode.visited) {
			nodes_q.Enqueue(curNode);
			curNode.visited = true;
			sb.Append(curNode.number + " ");
		}
	}
}


Console.WriteLine(sb.ToString());

/* 사용법
 * string[] inputs = InputsToStringArray(sr.ReadToEnd().TrimEnd());
 * 예제 복붙하고 엔터로 빈 줄 만든담에 컨Z하고 엔터
 */
List<string> InputsToStringArray(string allInput)
{
	return allInput.Replace("\r", "").Split('\n').ToList();
}

void Search(Node root)
{
	if (root == null) return;
	root.visited = true;
	sb.Append(root.number + " ");

	if (root.near == null) return;
	root.near.Sort();

	foreach (int n in root.near) {
		Node node = nodes.Find(x => x.number == n);
		if (!node.visited) {
			Search(node);
		}
	}
}

// Node
class Node
{
	public int number;
	public List<int> near;
	public bool visited = false;
}

