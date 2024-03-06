using System.Collections.Generic;
using UnityEngine;

public class AStarGrid : SingletonBehaviour<AStarGrid> 
{
    //--------------------Private--------------------//
    [SerializeField]
    private GameObject _player;
    
    [SerializeField]
    private LayerMask _unWalkableMask;
    
    [SerializeField]
    private Vector2 _gridWorldSize;
    
    [SerializeField]
    private float _nodeRadius;
    private float _nodeDiameter;

    private AStarNode[,] _grid;

    private int _gridSizeX;
    private int _gridSizeY;

    public List<AStarNode> _path;

    //--------------------Functions--------------------//
    private void Start()
    {
        _nodeDiameter = _nodeRadius * 2;

        _gridSizeX = Mathf.RoundToInt(_gridWorldSize.x / _nodeDiameter);
        _gridSizeY = Mathf.RoundToInt(_gridWorldSize.y / _nodeDiameter);

        createGrid();

        InvokeRepeating(nameof(CheckForUnWalkable), 0.0f, 0.1f);
    }

    private void createGrid()
    {
        _grid = new AStarNode[_gridSizeX, _gridSizeY];
        Vector3 worldBottomleft = transform.position - Vector3.right * _gridWorldSize.x / 2 - Vector3.forward * _gridWorldSize.y / 2;

        for (int x = 0; x < _gridSizeX; x++)
        {
            for (int y = 0; y < _gridSizeX; y++)
            {
                Vector3 worldPoint = worldBottomleft + Vector3.right * (x * _nodeDiameter + _nodeRadius) + Vector3.forward * (y * _nodeDiameter + _nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, _nodeRadius,_unWalkableMask));
                _grid[x, y] = new AStarNode(walkable, worldPoint,  x,y);
            }
        }
    }

    private void CheckForUnWalkable()
    {
        Vector3 worldBottomleft = transform.position - Vector3.right * _gridWorldSize.x / 2 - Vector3.forward * _gridWorldSize.y / 2;
        foreach (AStarNode node in _grid)
        {
            Vector3 worldPoint = worldBottomleft + Vector3.right * (node.GridX * _nodeDiameter + _nodeRadius) + Vector3.forward * (node.GridY * _nodeDiameter + _nodeRadius);
            node.Walkable = !(Physics.CheckSphere(worldPoint, _nodeRadius, _unWalkableMask));
        }
    }

    public List<AStarNode> GetNeighbours(AStarNode node)
    {
        List<AStarNode> neighbours = new List<AStarNode>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(x == 0 && y == 0)
                    continue;

                int checkX = node.GridX + x;
                int checkY = node.GridY + y;

                if(checkX >= 0&& checkX < _gridSizeX && checkY >=0&& checkY < _gridSizeY)
                {
                    neighbours.Add(_grid[checkX,checkY]);
                }
            }
        }
        return neighbours;
    }
    
   public AStarNode NodeFromWorldPosition(Vector3 worldposition)
    {
        float percentX = (worldposition.x + _gridWorldSize.x / 2) / _gridWorldSize.x;
        float percentY = (worldposition.z + _gridWorldSize.y / 2) / _gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((_gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((_gridSizeY - 1) * percentY);
        return _grid[x, y];
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(_gridWorldSize.x, 1, _gridWorldSize.y));

        if(_grid != null)
        {
            AStarNode PlayerNode = NodeFromWorldPosition(_player.transform.position);
            foreach(AStarNode node in _grid)
            {
                Gizmos.color = (node.Walkable) ? Color.white : Color.red;
                if(PlayerNode == node)
                {
                    Gizmos.color = Color.blue;
                }
                if(_path != null)
                { 
                    if (_path.Contains(node))
                    {
                        Gizmos.color = Color.black;
                    }
                }
                Gizmos.DrawCube(node.WorldPosition, Vector3.one * (_nodeDiameter - .1f));
            }
        }
    }

}
