using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplexNoise;
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
            for (int x = 0; x< World.currentWorld.chunkWidth; x++) // building the world at the start of runtime and using SimplexNoise to generate the noise for random terrian
            {
                float noiseX = (float)x / 20;
                for (int y = 0; y < World.currentWorld.chunkHeight; y++)
                {
                    float noiseY = (float)y / 20;
                    for (int z = 0; z < World.currentWorld.chunkWidth; z++)
                    {
                        float noiseZ = (float)z / 20;
                        float noiseValue = Noise.Generate(noiseX, noiseY, noiseZ);
                        noiseValue += (10f - (float)y) / 10;
                        //noiseValue /= (float)y / 5;
                        if (noiseValue > 0.2f)
                        {
                            map[x, y, z] = 1;
                        }
                    }
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
                for (int y = 0; y < World.currentWorld.chunkHeight; y++)
                {
                    for (int z = 0; z < World.currentWorld.chunkWidth; z++)
                    {
                        if (map[x, y, z] == 0)
                        {
                            continue; 
                        }
                        int brick = map[x, y, z]; // varible of the bricks in the chunk
                        if (IsTransparent(x - 1, y, z)) // checking if the face is facing other face 
                        {
                            BuildFace(brick, new Vector3(x, y, z), Vector3.up, Vector3.forward, false, verts, uvs, tris); // calling the BuildFace methods and passing all the arguments with pre set variables to create the left face
                        }
                        if (IsTransparent(x + 1, y, z)) // checking if the face is facing other face 
                        {
                            BuildFace(brick, new Vector3(x + 1, y, z), Vector3.up, Vector3.forward, true, verts, uvs, tris); // same as above but reversed and offset by 1 in the x axis to create the right face
                        }
                        if (IsTransparent(x, y - 1, z)) // checking if the face is facing other face 
                        {
                            BuildFace(brick, new Vector3(x, y, z), Vector3.forward, Vector3.right, false, verts, uvs, tris); // creating the bottom faces
                        }
                        if (IsTransparent(x, y + 1, z)) // checking if the face is facing other face 
                        {
                            BuildFace(brick, new Vector3(x, y + 1, z), Vector3.forward, Vector3.right, true, verts, uvs, tris); // creating the top faces
                        }
                        if (IsTransparent(x, y, z - 1)) // checking if the face is facing other face 
                        {
                            BuildFace(brick, new Vector3(x, y, z), Vector3.up, Vector3.right, true, verts, uvs, tris); // creating the back faces
                        }
                        if (IsTransparent(x, y, z + 1)) // checking if the face is facing other face 
                        {
                            BuildFace(brick, new Vector3(x, y, z + 1), Vector3.up, Vector3.right, false, verts, uvs, tris); // creating the front faces
                        }
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
        public virtual void BuildFace(int brick, Vector3 corner, Vector3 up, Vector3 right, bool reversed, List<Vector3> verts, List<Vector2> uvs, List<int> tris) // created the faces of the mesh
        {
            int index = verts.Count; // counting the vert index
            verts.Add(corner + up); // building the mesh verts in a clockwise order
            verts.Add(corner + up + right);
            verts.Add(corner + right);
            verts.Add(corner);
            uvs.Add(new Vector2(0, 0)); // building the uvs (will change later)
            uvs.Add(new Vector2(0, 1));
            uvs.Add(new Vector2(1, 1));
            uvs.Add(new Vector2(1, 0));
            if (reversed) //checking to see of the tris order is reversed 
            {
                tris.Add(index + 0); // building the tris of the mesh using the vert index
                tris.Add(index + 1);
                tris.Add(index + 2); // one triangle
                tris.Add(index + 2);
                tris.Add(index + 3);
                tris.Add(index + 0); // two triangles
            }
            else // reversing the tris order 
            {
                tris.Add(index + 1); // building the tris of the mesh using the vert index
                tris.Add(index + 0);
                tris.Add(index + 2); // one triangle
                tris.Add(index + 3);
                tris.Add(index + 2);
                tris.Add(index + 0); // two triangles
            }
        }
        public virtual bool IsTransparent(int x, int y, int z) // returning a bool to determine which faces on the inside of the mesh shouldn't be generated
        {
            int brick = GetInt(x, y, z); 
            switch(brick) //switch statement for brick to cull faces that don't need to be seen
            {
                default:
                case 0:
                    return true;
                case 1:
                    return false;
            } 
        }
        public virtual int GetInt(int x, int y, int z) // gets the int 
        {
            if ((x < 0) || (y < 0) || (z < 0) || (y >= World.currentWorld.chunkHeight) || (x >= World.currentWorld.chunkWidth) || (z >= World.currentWorld.chunkWidth)) // if any of this ints are true it will return an error (to be changed)
            {
                return 0;
            }
            return map[x, y, z]; // returns map
        }
    }
}