using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject tile;

    [Tooltip("Must be odd")]
    public int gridSize;
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        // Generate tile array
        Mesh mesh = tile.GetComponentsInChildren<MeshFilter>()[0].sharedMesh;
        grid = new GameObject[gridSize, gridSize];
        int halfGridSize = gridSize / 2;
        for (int z = -halfGridSize; z <= halfGridSize; z++) {
            for (int x = -halfGridSize; x <= halfGridSize; x++)
            {
                Instantiate(tile, new Vector3(x * mesh.bounds.size.x, -mesh.bounds.size.y, z * mesh.bounds.size.z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
