using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class Hamiltonian
    {
        private bool[,] adjacency; // O(1)
        private bool[,] path; // O(1)
        private bool extracted; // O(1)
        private int pathCode = 0; // O(1)
        public int pathCodeLegnth = 0; // O(1)
        List<int> currPath; // O(1)
        private Dictionary<int, List<int>> paths; // O(1)

        private bool vaild(int row, int col, int h, int w)// O(1))
        {
            return row >= 0 && col >= 0 && row < h && col < w; // O(1)
        }

        private void dfs(int subset, int parent) // O(N^2)
        {
            currPath.Add(parent); // O(1)

            if (subset == 0) // O(1) // if the subset is empty then there is no more nodes to extract
            {
                paths.Add(pathCode, new List<int>(currPath)); // O(N)
                paths[pathCode].Reverse(); // O(N)
                pathCode++; // O(1)
            }

            for(int i = 0; i < path.GetLength(0); i ++)// O(N)
                if (adjacency[i, parent] && path[i, subset])
                {
                    dfs(subset ^ (1 << i), i);//T(N) = N * T(N - 1);
                }

            currPath.RemoveAt(currPath.Count - 1);// O(1)
        }

        private void ExtractPaths(int h, int w)
        {
            int n = h * w; // number of nodes// O(1)
            adjacency = new bool[n, n];// O(N62)
            path = new bool[n, 1 << n];// O(2^n * n^2)
            paths = new Dictionary<int, List<int>>();// O(1)
            currPath = new List<int>();// O(1)

            int[] dr = { 1, -1, 0, 0 };// O(1)
            int[] dc = { 0, 0, 1, -1 };// O(1)
            // O(1)
            // initialize adjacency list
            for (int row = 0; row < h; row++)// O(1)
                for (int col = 0; col < w; col++)// O(1)
                    for (int k = 0; k < dr.Length; k++)// O(1)
                    {
                        int DR = row + dr[k];// O(1)
                        int DC = col + dc[k];// O(1)

                        if (vaild(DR, DC, h, w))// O(1)
                            adjacency[row * w + col, DR * w + DC] = true; // converting from 2D to 1D// O(1)
                    }

            // initialize the base case
            // O(N)
            for (int i = 0; i < n; i++)// O(!)
            {
                path[i, 1 << i] = true;// O(1)
            }

            // bulding the table
            // O(2^n * n^2)
            for (int i = 0; i < path.GetLength(1); i++) // 2^n * n^2
            {
                for (int j = 0; j < n; j++) // O(1)
                {
                    if (((1 << j) & i) != 0)// O(1) // if node j in subset i
                    {
                        for (int k = 0; k < n; k++)// O(1)
                        {
                            if (((1 << k) & i) != 0)// O(1) // if node k in subest i
                            {
                                // if j and k are neighbours and
                                // if the subset i except node j
                                // has a Hamiltonian path that ends at k
                                if (adjacency[j, k] && path[k, i ^ (1 << j)])// O(1)
                                {
                                    path[j, i] = true;// O(1) // then the subset i has Hamiltonian path ends at node j
                                }
                            }
                        }
                    }
                }
            }

            // extracting Hamiltonian paths
            // O(N^3)
            for (int i = 0; i < n; i++)// O(1)
                if (path[i, (1 << n) - 1])// O(1)
                {
                    dfs(((1 << n) - 1) ^ (1 << i), i);// O(N^2)
                }

            pathCodeLegnth = (int)Math.Ceiling(Math.Log10(pathCode) / Math.Log10(2));// O(1)
            extracted = true;// O(1)
        }

        public Dictionary<int, List<int>> getPath(int h, int w) // O(2^n * n^2),  Lower(1)
        {
            if (!extracted)// O(1)
                ExtractPaths(h, w);// O(2^n * n^2)

            return paths;// O(1)
        }
    }
}
