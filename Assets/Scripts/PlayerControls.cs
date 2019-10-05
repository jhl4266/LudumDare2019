using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Mesh playerMesh;

    private float bpm;
    private float movementSpeed;
    public int tilesPerMove;

    private Vector3 lastPosition;
    private bool isMoving = false;
    private float lastPercentage = 0;

    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;
    private Vector3 movementVector = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerMesh = gameObject.GetComponentsInChildren<MeshFilter>()[0].sharedMesh;
        horizontalMovement = new Vector3(playerMesh.bounds.size.x * tilesPerMove, 0, 0);
        verticalMovement = new Vector3(0, 0, playerMesh.bounds.size.z * tilesPerMove);

        bpm = GameObject.Find("LevelManager").GetComponent<BeatManager>().bpm;
        movementSpeed = 60.0f / bpm;
    }

    // Update is called once per frame
    void BeatUpdate(float percentage)
    {
        bool isNewBeat = percentage < lastPercentage;
        lastPercentage = percentage;

        if (isMoving) {
            if (isNewBeat) {
                SetIsMoving(false);
            }
            else {
                SetPosition(percentage);
                return;
            }
        }

        if (isNewBeat) {
            CheckInputs();
        }
    }

    void SetPosition(float percentage) {
        float x = lastPosition.x + (movementVector.x * percentage);
        float y = Mathf.Abs(Mathf.Sin(Mathf.PI * percentage));
        float z = lastPosition.z + (movementVector.z * percentage);
        gameObject.transform.position = new Vector3(x, y, z);
    }

    void CheckInputs() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementVector = horizontalMovement;
            gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
            SetIsMoving(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementVector = -horizontalMovement;
            gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            SetIsMoving(true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementVector = verticalMovement;
            gameObject.transform.eulerAngles = new Vector3(180, 0, 0);
            SetIsMoving(true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movementVector = -verticalMovement;
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            SetIsMoving(true);
        }
    }

    void SetIsMoving(bool value) {
        isMoving = value;
        if (isMoving) {
            lastPosition = transform.position;
        }
        else {
            SetPosition(1.0f);
            movementVector = new Vector3(0, 0, 0);
        }
    }
}
