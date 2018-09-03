using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldManager
{
    public class World : MonoBehaviour
    {
        public int chuckWidth = 20, chunkHeight = 20, seed = 0; // ints for chuck width height and seed
        void Start() // Use this for initialization
        {
            if (seed == 0)
            {
                seed = Random.Range(0, int.MaxValue);
            }
        }
        void Update() // Update is called once per frame
        {

        }
    }
}
