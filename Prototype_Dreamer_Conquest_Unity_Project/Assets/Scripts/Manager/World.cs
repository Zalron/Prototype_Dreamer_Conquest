using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerConquest.Manager.World;
namespace DreamerConquest.Manager.World
{
    public class World : MonoBehaviour
    {
        public static World currentWorld; // variable of the current world in the games runtime
        public int chunkSize = 50, seed = 0; // ints for chuck width height and seed
        public float viewRange; // range for chunk to be generated
        public float grain0scale = 0.05f, grain1scale = 0.03f, grain2scale = 0.009f;
        public float brickHeight = 1;
        public Chunk chunkFab;
        void Awake() // Use this for initialization
        {
            Cursor.visible = false;
            currentWorld = this;
            if (seed == 0)
            {
                seed = Random.Range(0, int.MaxValue); // setting seed
            }
        }
        void Update() // Update is called once per frame
        {
            // checking to generate a new chunk based on the position of the player.
            for (float x = transform.position.x - viewRange; x < transform.position.x + viewRange; x += chunkSize)
            {
                for (float y = transform.position.y - viewRange; y < transform.position.y + viewRange; y += chunkSize)
                {
                    for (float z = transform.position.z - viewRange; z < transform.position.z + viewRange; z += chunkSize)
                    {
                        Vector3 pos = new Vector3(x, y, z);
                        pos.x = Mathf.Floor(pos.x / chunkSize) * chunkSize;
                        pos.y = Mathf.Floor(pos.y / chunkSize) * chunkSize;
                        pos.z = Mathf.Floor(pos.z / chunkSize) * chunkSize;
                        Chunk chunk = Chunk.FindChunk(pos);
                        if (chunk != null)
                        {
                            continue;
                        }
                        if (Vector3.Distance(pos, transform.position) < viewRange)
                        {
                            chunk = (Chunk)Instantiate(chunkFab, pos, Quaternion.identity);
                        }
                    }
                }
            }
            for (int a = 0; a < Chunk.chunks.Count; a++)
            {
                if (Vector3.Distance(transform.position - Vector3.up * transform.position.y, Chunk.chunks[a].transform.position) > viewRange)
                {
                    Destroy((Object)Chunk.chunks[a].GetComponent<MeshFilter>().sharedMesh);
                    Destroy(Chunk.chunks[a].GetComponent<MeshRenderer>().material, .1f);
                    Destroy(Chunk.chunks[a].gameObject, .2f);
                    Chunk.chunks.Remove(Chunk.chunks[a]);
                }
            }
        }
    }
}
