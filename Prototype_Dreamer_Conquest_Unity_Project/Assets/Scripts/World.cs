using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldManager
{
    public class World : MonoBehaviour
    {
        public static World currentWorld; // variable of the current world in the games runtime
        public int chunkWidth = 10, chunkHeight = 10, seed = 0; // ints for chuck width height and seed
        void Awake() // Use this for initialization
        {
            currentWorld = this;
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
