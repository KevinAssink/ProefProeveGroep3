using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSpawning
{
    public class ObstacleRow : MonoBehaviour
    {
        private List<List<GameObject>> _rows = new();

        public List<GameObject> GetRowOfObject(GameObject obstacle)
        {
            foreach (List<GameObject> row in _rows) 
            {
                foreach(GameObject obj in row)
                {
                    if (obj != obstacle)
                        continue;
                    

                }
            }

            return null;
        }

    }
}

