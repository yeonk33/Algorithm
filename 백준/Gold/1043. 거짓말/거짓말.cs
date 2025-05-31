StreamReader sr = new StreamReader(Console.OpenStandardInput());

string[] firstLine = sr.ReadLine().Split();
int N = int.Parse(firstLine[0]); // 사람 수
int M = int.Parse(firstLine[1]); // 파티 수

string[] secondLine = sr.ReadLine().Split();
int K = int.Parse(secondLine[0]); // 진실을 아는 사람 수

List<int> truthPeople = new List<int>();
for (int i = 1; i <= K; i++)
{
    truthPeople.Add(int.Parse(secondLine[i]));
}

List<List<int>> parties = new List<List<int>>();
for (int i = 0; i < M; i++)
{
    string[] partyLine = sr.ReadLine().Split();
    int partySize = int.Parse(partyLine[0]);

    List<int> party = new List<int>();
    for (int j = 1; j <= partySize; j++)
    {
        party.Add(int.Parse(partyLine[j]));
    }
    parties.Add(party);
}

int result = Calculate(truthPeople, parties);
Console.WriteLine(result);

int Calculate(List<int> truthPeople, List<List<int>> parties)
{
    int result = 0;

    // 진실 아는 사람 집합
    HashSet<int> knownTruth = new HashSet<int>(truthPeople);

    bool changed = true;
    while (changed)
    {
        changed = false;

        foreach (var party in parties)
        {
            if (party.Any(p => knownTruth.Contains(p)))
            {
                foreach (var person in party)
                {
                    if (knownTruth.Add(person))
                    {
                        changed = true; // 진실을 아는 사람 추가 되면 다시 검사
                    }
                }
            }
        }
    }

    // 진실을 아는 사람 없는 파티만 count
    foreach (var party in parties)
    {
        if (!party.Any(p => knownTruth.Contains(p)))
        {
            result++;
        }
    }

    return result;
}
