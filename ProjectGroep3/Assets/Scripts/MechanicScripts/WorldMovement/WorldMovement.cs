using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WorldMovement
{
    public class WorldMovemeny : MonoBehaviour
    {
        //-------------------Public-------------------//
        public Transform tile1Obj;

        //-------------------Private-------------------//
        private Vector3 _nextTileSpawn;

        //-------------------Functions-------------------//



        // Start is called before the first frame update
        void Start()
        {
            _nextTileSpawn.x = 0;
            StartCoroutine(spawnTile);

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator spawnTile()
        {
            yield return new WaitForSeconds(1);
            Instantiate(tile1Obj, _nextTileSpawn, tile1Obj.rotation);
            _nextTileSpawn.x += 17.5;
            StartCoroutine(spawnTile());
        }

    }


}
