using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace DreamerConquest.Manager.Player
//{
//    public class Player : MonoBehaviour
//    {
//        public float maxInteractDistance = 8;
//        public byte selectedInventory = 0;
//        public bool resetCamera = false;
//        public Vector3 campos;
//        public Animator playerAnimator;
//        void Start()  // Use this for initialization
//        {
//            currentPlayerIO = this;
//            /*
//            QualitySettings.vSyncCount = 0;
//            Application.targetFrameRate = 144;
//            */
//        }
//        void Update() // Update is called once per frame
//        {
//            //playerAnimator.SetBool("walking", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
//            //if (GameObject.FindWithTag("Player").transform.position.y < -20)
//            //{
//            //    Debug.Log("Player fell through world, resetting!");
//            //    GameObject.FindWithTag("Player").transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x, 60, GameObject.FindWithTag("Player").transform.position.z);
//            //}
//            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.C))
//            {
//                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
//                RaycastHit hit;
//                float rayDistance = maxInteractDistance;
//                if (!resetCamera)
//                {
//                    rayDistance *= 3.14159f;
//                }
//                if (Physics.Raycast(ray, out hit, rayDistance))
//                {
//                    Chunk chunk = hit.transform.GetComponent<Chunk>();
//                    if (chunk == null)
//                    {
//                        return;
//                    }
//                    if (Input.GetMouseButtonDown(0))
//                    {
//                        Vector3 p = hit.point;
//                        p -= hit.normal / 4;
//                        chunk.SetBrick(0, p);
//                    }
//                    if (Input.GetMouseButtonDown(1))
//                    {
//                        Vector3 p = hit.point;
//                        if (selectedInventory != 0)
//                        {
//                            p += hit.normal / 4;
//                            chunk.SetBrick(selectedInventory, p);
//                        }
//                    }
//                    if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.C))
//                    {
//                        Vector3 p = hit.point;
//                        p -= hit.normal / 4;
//                        selectedInventory = chunk.GetByte(p);
//                    }
//                }
//            }
//            if (Input.GetKeyDown(KeyCode.F5))
//            {
//                if (!resetCamera)
//                {
//                    Camera.main.transform.localPosition -= Vector3.forward * 3.14159f;
//                }
//                else
//                {
//                    Camera.main.transform.position = transform.position;
//                }
//                resetCamera = !resetCamera;
//            }
//            if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.F1))
//            {
//                Application.Quit();
//            }
//        }
//    }
//}
