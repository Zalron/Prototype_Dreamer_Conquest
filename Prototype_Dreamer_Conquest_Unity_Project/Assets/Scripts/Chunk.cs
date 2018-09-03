using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WorldManager
{
    [RequireComponent(typeof(MeshFilter))] // automatically adding the MeshFilter component 
    [RequireComponent(typeof(MeshRenderer))] // automatically adding the MeshRenderer component 
    [RequireComponent(typeof(MeshCollider))] // automatically adding the MeshCollider component 
    public class Chunk : MonoBehaviour
    {
        #region Variables
        public int[,,] map; // 3 dimensional array for the map generation
        public Mesh visualMesh; // the visual mesh component
        protected MeshFilter meshFilter; // the mesh filter component
        protected MeshRenderer meshRenderer; // The mesh renderer component
        protected MeshCollider meshCollider; // the mesh collider component
        #endregion
        #region Start and Update()
        void Start() // Use this for initialization
        {
            meshFilter = GetComponent<MeshFilter>(); // setting the mesh filter to the component 
            meshRenderer = GetComponent<MeshRenderer>(); // setting the mesh renderer to the component
            meshCollider = GetComponent<MeshCollider>(); // setting the mesh collider to the component
            map = new int[World.currentWorld.chunkWidth, World.currentWorld.chunkHeight, World.currentWorld.chunkWidth]; // setting the 3 dimensional map array to the map variable in here
            for (int x = 0; x< World.currentWorld.chunkWidth; x++) // building the world at the start of runtime
            {
                for (int z = 0; z < World.currentWorld.chunkWidth; z++)
                {
                    map[x, 0, z] = 1;
                    map[x, 1, z] = Random.Range(0, 1);
                }
            }
            CreateVisualMesh(); // calling the createvisualmesh to generate a chunk 
        }
        void Update() // Update is called once per frame
        {

        }
        #endregion
        public virtual void CreateVisualMesh() //Generating visual mesh
        {
            visualMesh = new Mesh(); // creating an empty mesh for the visual mesh variable
            List<Vector3> verts = new List<Vector3>(); // list of vertices on the mesh
            List<Vector2> uvs = new List<Vector2>(); // list of uvs on the mesh
            List<int> tris = new List<int>(); // list of triangles on the mesh
            for (int x = 0; x < World.currentWorld.chunkWidth; x++) // building the world at the start of runtime
            {
                for (int y = 0; y < World.currentWorld.chunkWidth; y++)
                {
                    for (int z = 0; z < World.currentWorld.chunkWidth; z++)
                    {
                        map[x, 0, z] = 1;
                        map[x, 1, z] = Random.Range(0, 1);
                    }
                }
            }
            visualMesh.vertices = verts.ToArray(); //setting the visualmesh vertices to the verts list
            visualMesh.uv = uvs.ToArray(); //setting the visualmesh uvs to the uvs list
            visualMesh.triangles = tris.ToArray(); //setting the visualmesh triangles to the tris list
            visualMesh.RecalculateBounds(); // recalculating the bounding volume of the mesh from the vertices
            visualMesh.RecalculateNormals(); // recalculating the normals of the mesh from the tris and verts
            meshFilter.mesh = visualMesh; // setting the meshfilter to the newly calculated visual mesh
            meshCollider.sharedMesh = visualMesh; //setting the meshCollider to the newly calculated visual mesh
        }
    }
}
