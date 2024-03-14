using UnityEngine;

namespace PathFinding
{
    public class AStarNode
    {
        //--------------------Private--------------------//
        private bool _walkable;

        private Vector3 _worldPosition;

        private int _gridX;
        private int _gridY;

        private int _gCost;
        private int _hCost;

        private AStarNode _parent;

        //--------------------Public--------------------//
        public bool Walkable
        {
            get => _walkable;
            set => _walkable = value;
        }
        public Vector3 WorldPosition
        {
            get => _worldPosition;
            set => _worldPosition = value;
        }

        public int GridX
        {
            get => _gridX;
            set => _gridX = value;
        }
        public int GridY
        {
            get => _gridY;
            set => _gridY = value;
        }
        public int GCost
        {
            get => _gCost;
            set => _gCost = value;
        }
        public int HCost
        {
            get => _hCost;
            set => _hCost = value;
        }
        public int fCost
        {
            get => _gCost + _hCost;
        }

        public AStarNode Parent
        {
            get => _parent;
            set => _parent = value;
        }

        //--------------------Public--------------------//
        public AStarNode(bool walkable, Vector3 worldPosition, int gridX, int gridY)
        {
            _walkable = walkable;
            _worldPosition = worldPosition;
            _gridX = gridX;
            _gridY = gridY;
        }
    }
}