using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSpawning
{
    public class ObstacleRowManager : SingletonBehaviour<ObstacleRowManager>
    {
        //--------------------Private--------------------//
        private List<List<GameObject>> _rows = new();

        //--------------------public--------------------//
        public List<List<GameObject>> Rows
        {
            get => _rows;
            set => _rows = value;
        }

        //--------------------Functions--------------------//
        /// <summary>
        /// Get the row(list of GameObjects) of the given GameObject
        /// </summary>
        /// <param name="obstacle">The GameObject to get the row of</param>
        /// <returns>List of GameOjects</returns>
        public List<GameObject> GetRowOfObject(GameObject obstacle)
        {
            List<GameObject> tempRow = new();

            foreach (List<GameObject> row in _rows) 
            {
                foreach(GameObject obj in row)
                {
                    if (obj != obstacle)
                        continue;

                    tempRow = row;        
                }
                return tempRow;
            }

            return null;
        }
        
        /// <summary>
        /// Get the row index of the given row
        /// </summary>
        /// <param name="rowToGetIndexFrom">The row to get the index from</param>
        /// <returns>Interger</returns>
        public int GetRowIndex(List<GameObject> rowToGetIndexFrom) 
        {
            foreach (List<GameObject> row in _rows)
            {
                if(row ==  rowToGetIndexFrom)
                    return _rows.IndexOf(rowToGetIndexFrom);
            }

            return -1;
        }
    }
}

