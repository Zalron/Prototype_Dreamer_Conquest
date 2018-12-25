using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deprecated : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //public float panSpeed = 20f; // speed of the panning
    //public float panBorderThickness = 10f; // the thickness of the border that the mouse has to cross inorder to move the camera in that direction
    //public Vector2 panLimit; // the limit that the camera can pan to
    //public float scrollSpeed; // the speed for scrolling 
    //public float minY; // the minimum scrolling depth for the camera
    //public float maxY; // the maximum scrolling height for the camera
    //void Start() // Use this for initialization
    //{

    //}
    //void Update() // Update is called once per frame
    //{
    //    Vector3 pos = transform.position; // updates the position of the object with every frame
    //    if (Input.GetButton("Forward") || Input.mousePosition.y >= Screen.height - panBorderThickness) // input function for if the player presses the "w" key or if the curser cross the border thickness at the top of the screen
    //    {
    //        pos.z += panSpeed * Time.deltaTime; // muitlpilying the panning speed of the camera with every frame smoothly
    //    }
    //    if (Input.GetButton("Down") || Input.mousePosition.y <= panBorderThickness) // input function for if the player presses the "s" key or if the curser cross the border thickness at the bottem of the screen
    //    {
    //        pos.z -= panSpeed * Time.deltaTime; // muitlpilying the panning speed of the camera with every frame smoothly
    //    }
    //    if (Input.GetButton("Right") || Input.mousePosition.x >= Screen.width - panBorderThickness) // input function for if the player presses the "d" key or if the curser cross the border thickness at the right of the screen
    //    {
    //        pos.x += panSpeed * Time.deltaTime; // muitlpilying the panning speed of the camera with every frame smoothly
    //    }
    //    if (Input.GetButton("Left") || Input.mousePosition.x <= panBorderThickness) // input function for if the player presses the "d" key or if the curser cross the border thickness at the left of the screen
    //    {
    //        pos.x -= panSpeed * Time.deltaTime; // muitlpilying the panning speed of the camera with every frame smoothly
    //    }
    //    float scroll = Input.GetAxis("Mouse ScrollWheel"); // setting the variable to the scroll wheel on the mouse
    //    pos.y += scroll * scrollSpeed * 100f * Time.deltaTime; // calculating the scrolling
    //    pos.x = Mathf.Clamp(pos.x, 0, panLimit.x); // clamping the camera possible movement on the x axis.
    //    pos.y = Mathf.Clamp(pos.y, minY, maxY); // claming the cameras possible movement on the y axis. 
    //    pos.z = Mathf.Clamp(pos.z, 0, panLimit.y); // clamping the camera possible movement on the z axis. (writing over the top of the y axs)
    //    transform.position = pos; // feeding back the edited position of the camera
}
