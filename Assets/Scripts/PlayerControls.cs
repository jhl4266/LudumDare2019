using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Mesh playerMesh;
    public float jumpHeight;

    private float bpm;
    private float movementSpeed;
    public int tilesPerMove;

    private Vector3 lastPosition;
    private bool isMoving = false;
    private float lastPercentage = 0;

    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;
    private Vector3 movementVector = new Vector3(0, 0, 0);

    private int halfGridSize;
    private Vector2 gridLocation;
    private Vector2 nextGridLocation;
    private bool targetIsActive = false;
    Vector2 activeTileLocation;

    // Start is called before the first frame update
    void Start()
    {
        playerMesh = gameObject.GetComponentsInChildren<MeshFilter>()[0].sharedMesh;
        horizontalMovement = new Vector3(playerMesh.bounds.size.x * tilesPerMove, 0, 0) * transform.localScale.x;
        verticalMovement = new Vector3(0, 0, playerMesh.bounds.size.z * tilesPerMove) * transform.localScale.z * 1.26f;

        bpm = GameObject.Find("LevelManager").GetComponent<BeatManager>().bpm;
        movementSpeed = 60.0f / bpm;
    }

    void Update()
    {
        //Test Button
        if (!targetIsActive && Input.GetKey(KeyCode.Space))
        {
            targetIsActive = true;
            gameObject.SendMessageUpwards("GenerateTarget");
        }
    }

    void BeatUpdate(float percentage)
    {
        if (isMoving)
        {
            SetPosition(percentage);
            return;
        }
    }

    void OnNewBeat()
    {
        if (isMoving)
        {
            SetIsMoving(false);
        }
        CheckInputs();
    }

    void SetPosition(float percentage)
    {
        float x = lastPosition.x + (movementVector.x * percentage);
        float y = Mathf.Abs(Mathf.Sin(Mathf.PI * percentage)) * jumpHeight;
        float z = lastPosition.z + (movementVector.z * percentage);
        gameObject.transform.position = new Vector3(x, y, z);
    }

    void CheckInputs()
    {
        //Horizontal Movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementVector = horizontalMovement;
            nextGridLocation = gridLocation + new Vector2(tilesPerMove, 0);
            gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
            SetIsMoving(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementVector = -horizontalMovement;
            nextGridLocation = gridLocation - new Vector2(tilesPerMove, 0);
            gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            SetIsMoving(true);
        }

        //Vertical Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementVector = verticalMovement;
            nextGridLocation = gridLocation + new Vector2(0, tilesPerMove);
            gameObject.transform.eulerAngles = new Vector3(180, 0, 180);
            SetIsMoving(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementVector = -verticalMovement;
            nextGridLocation = gridLocation - new Vector2(0, tilesPerMove);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            SetIsMoving(true);
        }
    }

    void SetIsMoving(bool value)
    {
        isMoving = value;
        if (isMoving)
        {
            // Make sure we're in bounds
            if (nextGridLocation.x > halfGridSize * 2
                || nextGridLocation.y > halfGridSize * 2
                || nextGridLocation.x < 0
                || nextGridLocation.y < 0)
            {
                isMoving = false;
            }
            else
            {
                lastPosition = transform.position;
            }
        }
        else
        {
            SetPosition(1.0f);
            movementVector = new Vector3(0, 0, 0);
            gridLocation = nextGridLocation;
            if (gridLocation == activeTileLocation)
            {
                gameObject.SendMessageUpwards("GenerateTarget");
            }
        }
    }

    void SendHalfGridSize(int size)
    {
        halfGridSize = size;
        gridLocation = new Vector2(halfGridSize, halfGridSize);
    }

    void SendActiveTile(Vector2 location)
    {
        activeTileLocation = location;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            gameObject.SendMessageUpwards("OnDamageTaken");
        }
    }
}
