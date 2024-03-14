using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class AStarPathFinding : MonoBehaviour
    {
        //--------------------Private--------------------//
        [SerializeField]
        private Transform _start;
        [SerializeField]
        private Transform _end;

        private AStarGrid _grid;

        //--------------------Functions--------------------//
        private void Start()
        {
            _grid = AStarGrid.Instance;

        }

        private void Update()
        {
            AStarSearch(_start.position, _end.position);
        }

        private void AStarSearch(Vector3 startPos, Vector3 targetPos)
        {
            AStarNode startNode = _grid.NodeFromWorldPosition(startPos);
            AStarNode targetNode = _grid.NodeFromWorldPosition(targetPos);

            List<AStarNode> openList = new();
            List<AStarNode> closedList = new();

            openList.Add(startNode);

            while (openList.Count > 0)
            {
                AStarNode currentNode = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].HCost < currentNode.HCost)
                    {
                        currentNode = openList[i];
                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode == targetNode)
                {
                    ReTracePath(startNode, targetNode);
                    return;
                }

                foreach (AStarNode neighbourNode in _grid.GetNeighbours(currentNode))
                {
                    if (!neighbourNode.Walkable || closedList.Contains(neighbourNode))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentNode.GCost + GetDistance(currentNode, currentNode);

                    if (newMovementCostToNeighbour < neighbourNode.GCost || !openList.Contains(neighbourNode))
                    {
                        neighbourNode.GCost = newMovementCostToNeighbour;
                        neighbourNode.HCost = GetDistance(neighbourNode, targetNode);
                        neighbourNode.Parent = currentNode;
                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                        }
                    }
                }
            }
            if (openList.Count <= 0)
            {
                _grid._path.Clear();

            }
        }

        void ReTracePath(AStarNode StartNode, AStarNode EndNode)
        {
            List<AStarNode> Path = new List<AStarNode>();
            AStarNode CurrentNode = EndNode;

            while (CurrentNode != StartNode)
            {
                Path.Add(CurrentNode);
                CurrentNode = CurrentNode.Parent;
            }
            Path.Reverse();

            _grid._path = Path;
        }

        int GetDistance(AStarNode NodeA, AStarNode NodeB)
        {
            int dstX = Mathf.Abs(NodeA.GridX - NodeB.GridX);
            int dstY = Mathf.Abs(NodeA.GridY - NodeB.GridY);

            if (dstX > dstY)
            {
                return 14 * dstY + 10 * (dstX - dstY);
            }
            return 14 * dstX + 10 * (dstY - dstX);
        }
    }
}