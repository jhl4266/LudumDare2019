using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Mesh playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        playerMesh = gameObject.GetComponentsInChildren<MeshFilter>()[0].sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(playerMesh.bounds.size.x, 0, 0);
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position -= new Vector3(playerMesh.bounds.size.x, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0, 0, playerMesh.bounds.size.z);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position -= new Vector3(0, 0, playerMesh.bounds.size.z);
        }
    }
}
