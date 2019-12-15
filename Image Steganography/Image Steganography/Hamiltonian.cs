using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class Hamiltonian
    {
        private bool[,] adjacency;
        private bool[,] path;
        private bool extracted;
        private int pathCode = 0;
        public int pathCodeLegnth = 0;
        List<int> currPath;
        private Dictionary<int, List<int>> paths;

        private bool vaild(int row, int col, int h, int w)
        {
            return row >= 0 && col >= 0 && row < h && col < w;
        }

        private void dfs(int subset, int parent)
        {
            currPath.Add(parent);

            if(subset == 0) // if the subset is empty then there is no more nodes to extract
            {
                paths.Add(pathCode, new List<int>(currPath));
                paths[pathCode].Reverse();
                pathCode++;
            }

            for(int i = 0; i < path.GetLength(0); i ++)
                if(adjacency[i, parent] && path[i, subset])
                {
                    dfs(subset ^ (1 << i), i);
                }

            currPath.RemoveAt(currPath.Count - 1);
        }

        private void ExtractPaths(int h, int w)
        {
            int n = h * w; // number of nodes
            adjacency = new bool[n, n];
            path = new bool[n, 1 << n];
            paths = new Dictionary<int, List<int>>();
            currPath = new List<int>();

            int[] dr = { 1, -1, 0, 0 };
            int[] dc = { 0, 0, 1, -1 };

            // initialize adjacency list
            for (int row = 0; row < h; row++)
                for (int col = 0; col < w; col++)
                    for (int k = 0; k < dr.Length; k++)
                    {
                        int DR = row + dr[k];
                        int DC = col + dc[k];

                        if (vaild(DR, DC, h, w))
                            adjacency[row * w + col, DR * w + DC] = true; // converting from 2D to 1D
                    }

            // initialize the base case
            for (int i = 0; i < n; i++)
            {
                path[i, 1 << i] = true;
            }

            // bulding the table
            for (int i = 0; i < path.GetLength(1); i++) // 2^n * n^2
            {
                for (int j = 0; j < n; j++)
                {
                    if (((1 << j) & i) != 0) // if node j in subset i
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (((1 << k) & i) != 0) // if node k in subest i
                            {
                                // if j and k are neighbours and
                                // if the subset i except node j
                                // has a Hamiltonian path that ends at k
                                if (adjacency[j, k] && path[k, i ^ (1 << j)])
                                {
                                    path[j, i] = true; // then the subset i has Hamiltonian path ends at node j
                                }
                            }
                        }
                    }
                }
            }

            // extracting Hamiltonian paths
            for (int i = 0; i < n; i++)
                if (path[i, (1 << n) - 1])
                {
                    dfs(((1 << n) - 1) ^ (1 << i), i);
                }

            pathCodeLegnth = (int)Math.Ceiling(Math.Log10(pathCode) / Math.Log10(2));
            extracted = true;
        }

        public Dictionary<int, List<int>> getPath(int h, int w)
        {
            if (!extracted)
                ExtractPaths(h, w);

            return paths;
        }
    }
}
