using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WorldManager
{
    public class World : MonoBehaviour
    {
        public static World currentWorld; // variable of the current world in the games runtime
        public int chunkWidth = 10, chunkHeight = 10, seed = 0; // ints for chuck width height and seed
        public float viewRange; // range for chunk to be generated
        public Chunk chunkFab;
        void Awake() // Use this for initialization
        {
            currentWorld = this;
            if (seed == 0)
            {
                seed = Random.Range(0, int.MaxValue); // setting seed
            }
        }
        void Update() // Update is called once per frame
        {
            // checking to generate a new chunk based on the position of the player.
            for (float x = transform.position.x - viewRange; x < transform.position.x + viewRange; x+= chunkWidth)  
            {
                for (float z = transform.position.x - viewRange; z < transform.position.z + viewRange; z += chunkWidth)
                {
                    Vector3 pos = new Vector3(x, 0, z);
                    pos.x = Mathf.Floor(pos.x / (float)chunkWidth) * chunkWidth;
                    pos.z = Mathf.Floor(pos.z / (float)chunkWidth) * chunkWidth;
                    Chunk chunk = Chunk.FindChunk(pos);
                    if (chunk != null) 
                    {
                        continue;
                    }
                    chunk = (Chunk)Instantiate(chunkFab, pos, Quaternion.identity);
                }
            }
        }
    }
}
