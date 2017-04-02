using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray {
    class Program {
        static void Main(string[] args) {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]);
            int q = Convert.ToInt32(line[1]);
            
            List<List<int>> seqList = new List<List<int>>();
            for (int i = 0; i < n; i++) {
                seqList.Add(new List<int>());
            }
            
            int lastAns = 0;
            for (int i = 0; i < q; i++) {
                string[] query = Console.ReadLine().Split(' ');
                int type = Convert.ToInt32(query[0]);
                int x = Convert.ToInt32(query[1]);
                int y = Convert.ToInt32(query[2]);
                
                if (type == 1) {
                    int seq = (x ^ lastAns) % n;
                    seqList.[seq].add(y);
                } else if (type == 2) {
                    int seq = (x ^ lastAns) % n;
                    int idx = y % seqList[seq].Count;
                    lastAns = seqList[seq][idx];
                    
                    Console.WriteLine(lastAns);
                }
            }
        }
    }
}