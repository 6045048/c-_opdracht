var list = new MyLinkedList<int>();
list.Add(1);
list.Add(2);
list.Add(3);

// Select
var doubled = list.Select(x => x * 2);   // 2, 4, 6
 
// Where
var even = list.Where(x => x % 2 == 0);  // 2

// Count
int count = list.Count();                // 3
int evenCount = list.Count(x => x % 2 == 0); // 1

// Any
bool hasTwo = list.Any(x => x == 2);     // true
bool has99 = list.Any(x => x == 99);     // false

// FirstOrDefault
int first = list.FirstOrDefault();       // 1
int firstEven = list.FirstOrDefault(x => x % 2 == 0); // 2
int notFound = list.FirstOrDefault(x => x > 99);      // 0 (default(int))

