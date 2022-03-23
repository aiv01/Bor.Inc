using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct Platform {
    public Transform platform;
    public Vector2Int size;
    [HideInInspector] public Quaternion rot;
    public float height;

    [HideInInspector] public float area {
        get {
            return size.x * size.y;
        }
    }
}

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] List<Platform> platforms;
    //[SerializeField] Transform platformShort; //4 * 4
    //[SerializeField] Transform PlatformLong; //8 * 4
    //[SerializeField] Transform Platform1x1; //7 * 7
    //[SerializeField] Transform Platform2x2; //11 * 11
    //[SerializeField] Transform Platform3x3; //15 * 15
    //[SerializeField] Transform Platform4x4; //19 * 19
    //[SerializeField] Transform Bridge; //40 * 5
    //[SerializeField] Transform PlatformTall4x1; //19 * 6
    //[SerializeField] Transform FloorCircular01; //55 * 55
    //[SerializeField] Transform smallFloorCircular01; //20 * 20
    //[SerializeField] Transform RockLedge02; //30 * 16
    //[SerializeField] Transform RockChunk01; //18 * 10
    //[SerializeField] Transform RockFloating04; //38 * 25
    [SerializeField] UnityEngine.UI.RawImage image;

    [SerializeField] int gridMultiplier = 4;
    NavMeshSurface navMeshSurface;
    int[,] grid;
    [HideInInspector] public int[,] Grid {
        set {
            grid = new int[value.GetLength(0) * gridMultiplier, value.GetLength(1) * gridMultiplier];
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    grid[i, j] = value[i / gridMultiplier, j / gridMultiplier];
                }
            }
            SpawnPlatforms();
            transform.position = new Vector3(-grid.GetLength(0) * 0.5f, 0,-grid.GetLength(1) * 0.5f);
            navMeshSurface.BuildNavMesh();
            //Draw();
        }
    }
    private void Awake() {
        navMeshSurface = GetComponent<NavMeshSurface>();
        OrderPlatformsWithArea();
    }
    private void OrderPlatformsWithArea() {
        List<Platform> toAdd = new List<Platform>();
        foreach (Platform p in platforms) {
            
            if(p.size.x != p.size.y) {
                Platform newPlat = new Platform();

                newPlat.platform = p.platform;
                newPlat.rot = new Quaternion(0, 0.707106829f, 0, 0.707106829f);

                newPlat.height = p.height;

                newPlat.size.x = p.size.y;
                newPlat.size.y = p.size.x;
                toAdd.Add(newPlat);
            }
        }
        foreach (Platform item in toAdd) {
            platforms.Add(item);
        }
        toAdd.Clear();
        bool flag; //reiniziallizzo a zero il flag
        do {
            flag = false;
            for (int i = 0; i < platforms.Count - 1; i++)
                if (platforms[i].area < platforms[i + 1].area) {
                    Platform temp = platforms[i];
                    platforms[i] = platforms[i + 1];
                    platforms[i + 1] = temp;
                    flag = true; //se avviene lo scambio modifico il valore del flag
                }
        }
        while (flag);
    }
    void SpawnPlatforms() {
        GameObject platformFolder = new GameObject("Platforms");
        platformFolder.transform.parent = transform;
        foreach (Platform p in platforms) {//scorre tra le piattaforme
            bool exit = false;
            GameObject folder = new GameObject(p.platform.name + " Folder");
            folder.transform.parent = platformFolder.transform;
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {//scorre nella griglia
                    exit = false;
                    if(grid[i,j] == 1) {
                        for (int u = i; u < i + p.size.x; u++) {
                            for (int v = j; v < j + p.size.y; v++) {//controlla le zone oltre i e j per controllare se tutti i punti sono disponibili per la piattaforma
                                if (p.platform == platforms[platforms.Count - 1].platform) { 
                                    exit = false; 
                                    break; 
                                }
                                if (u >= grid.GetLength(0) || v >= grid.GetLength(1) || grid[u,v] == 0) { //controlla che nella griglia le zone della piattaforma siano tutti a 1
                                    exit = true;
                                }
                                if (exit) break;
                            }
                            if (exit) break;
                        }
                        if (!exit) {
                            for (int u = i; u < i + p.size.x; u++) {
                                for (int v = j; v < j + p.size.y; v++) {//setta tutti i punti toccati dalla piattafroma a 0
                                    grid[u, v] = 0;
                                }
                            }
                            Instantiate(p.platform, new Vector3(i + (p.size.x) * 0.5f, p.height, j + (p.size.y) * 0.5f), p.rot, folder.transform);
                        }
                    }
                }
            }

        }
    }

    private void Draw() {
        Texture2D texture = new Texture2D(grid.GetLength(0), grid.GetLength(1));
        image.texture = texture;

        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                Color color;
                if (grid[x, y] == 0)
                    color = Color.gray;
                else
                    color = Color.white;
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
