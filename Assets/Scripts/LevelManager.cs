using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject enemy;

    [Tooltip("Must be odd")]
    public int gridSize;
    private int halfGridSize;
    private GameObject[,] grid;

    private GameObject activeTile = null;

    private int previousX;
    private int previousZ;

    public int enemyDistance;

    // Start is called before the first frame update
    void Start()
    {
        ProgressScript progress = GameObject.Find("Progress").GetComponent<ProgressScript>();

        // Generate tile array
        Mesh mesh = tile.GetComponentsInChildren<MeshFilter>()[0].sharedMesh;
        grid = new GameObject[gridSize, gridSize];
        halfGridSize = gridSize / 2;
        previousX = halfGridSize;
        previousZ = halfGridSize;
        for (int z = -halfGridSize; z <= halfGridSize; z++)
        {
            for (int x = -halfGridSize; x <= halfGridSize; x++)
            {
                grid[x + halfGridSize, z + halfGridSize] = Instantiate(tile, new Vector3(x * mesh.bounds.size.x, -mesh.bounds.size.y, z * mesh.bounds.size.z), Quaternion.identity);
            }
        }

        // Generate vertical enemies
        for (int x = -halfGridSize; x <= halfGridSize; x++)
        {
            GameObject topEnemy = Instantiate(enemy, new Vector3(x * mesh.bounds.size.x, 0, (halfGridSize + enemyDistance) * mesh.bounds.size.z * 1.26f), Quaternion.identity);
            GameObject bottomEnemy = Instantiate(enemy, new Vector3(x * mesh.bounds.size.x, 0, (-halfGridSize - enemyDistance) * mesh.bounds.size.z * 1.26f), Quaternion.identity);
            bottomEnemy.transform.eulerAngles = new Vector3(180, 0, 0);
        }

        // Generate horizontal enemies
        if (progress.CurrentLevel == "Level 2")
        {
            for (int z = -halfGridSize; z <= halfGridSize; z++)
            {
                GameObject rightEnemy = Instantiate(enemy, new Vector3((halfGridSize + enemyDistance) * mesh.bounds.size.x, 0, z * mesh.bounds.size.z), Quaternion.identity);
                rightEnemy.transform.eulerAngles = new Vector3(0, 90, 0);
                GameObject leftEnemy = Instantiate(enemy, new Vector3((-halfGridSize - enemyDistance) * mesh.bounds.size.x, 0, z * mesh.bounds.size.z), Quaternion.identity);
                leftEnemy.transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }

        GenerateTarget();

        // Send data
        gameObject.BroadcastMessage("SendHalfGridSize", halfGridSize);
    }

    void GenerateTarget()
    {
        // If there was an active tile, this means we got a point
        if (activeTile)
        {
            Vector3 oldActivePosition = activeTile.transform.position;
            activeTile.transform.position = new Vector3(oldActivePosition.x, -1, oldActivePosition.z);
            gameObject.SendMessage("OnPointGet");
        }

        int x = previousX;
        while (Mathf.Abs(x - previousX) < 2)
        {
            x = Random.Range(0, gridSize);
        }
        previousX = x;

        int z = previousZ;
        while (Mathf.Abs(z - previousZ) < 2)
        {
            z = Random.Range(0, gridSize);
        }
        previousZ = z;

        activeTile = grid[x, z];
        Vector3 activePosition = activeTile.transform.position;
        activeTile.transform.position = new Vector3(activePosition.x, -0.4f, activePosition.z);

        // Send data
        gameObject.BroadcastMessage("SendActiveTile", new Vector2(x, z));
    }
}
