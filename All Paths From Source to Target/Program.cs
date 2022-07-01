using System;
using System.Collections.Generic;
using System.Linq;

namespace All_Paths_From_Source_to_Target
{
  class Program
  {
    static void Main(string[] args)
    {
      var graph = new int[5][] { new int[] { 4, 3, 1 }, new int[] { 3, 2, 4 }, new int[] { 3 }, new int[] { 4 }, new int[0] };
      Solution s = new Solution();
      s.AllPathsSourceTarget(graph);
    }
  }

  public class Solution
  {
    // Time = O(2^n * n)
    // Space = O(2^n * n)
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
      if (graph == null) return null;

      var result = new List<IList<int>>();
      var path = new List<int>();

      // we are adding the starting node 0 
      // all the paths with have 0 as starting till the last node
      path.Add(0);
      DFS(graph, result, path, 0);

      return result;
    }

    private void DFS(int[][] graph, List<IList<int>> result, List<int> path, int node)
    {
      if (node == graph.Length - 1)
      {
        result.Add(new List<int>(path));
        return;
      }

      var neighbors = graph[node];
      foreach (int n in neighbors)
      {
        path.Add(n);
        DFS(graph, result, path, n);

        path.RemoveAt(path.Count - 1);
      }
    }
  }
}
