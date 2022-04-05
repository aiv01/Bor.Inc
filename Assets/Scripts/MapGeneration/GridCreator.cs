using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridCreator : MonoBehaviour
{
    
    [SerializeField] Vector2Int gridSize = new Vector2Int(300, 300);
    [SerializeField] List<Vector2Int> tileSpawners;
    [SerializeField] int passages = 100;
    [SerializeField] int chanceOfNewSpawner = 10;
    [SerializeField] UnityEngine.UI.RawImage image;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField]  int[,] grid;

    void Start()
    {
        gridSize = new Vector2Int(gridSize.x / (3 - ScriptableStaticClass.instance.level + 1), gridSize.y / (3 - ScriptableStaticClass.instance.level + 1));
        grid = new int[gridSize.x, gridSize.y];
        for (int i = 0; i < tileSpawners.Count; i++) {
            tileSpawners[i] = gridSize / 2;
        }
        CreateGrid();
        //Write();
        if(image) Draw();
        GetComponent<PlatformSpawner>().Grid = grid;
    }

    private void Write() {
        string s = "";
        for (int i = 0; i < gridSize.x; i++) {
            for (int j = 0; j < gridSize.y; j++) {
                s = s + grid[i, j].ToString() + " ";
            }
            s += "\n";
        }
        text.text = s;
    }

    private void Draw() {
        Texture2D texture = new Texture2D(gridSize.x, gridSize.y);
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

    void CreateGrid() {
        for (int i = 0; i < passages; i++) {
            List<Vector2Int> newSpawners = new List<Vector2Int>();
            for (int j = 0; j < tileSpawners.Count; j++) {
                Vector2Int v;
                do {
                    int ran = Random.Range(1, 5);
                   v = tileSpawners[j] + (ran == 1 ? new Vector2Int(1, 0) : ran == 2 ? new Vector2Int(-1, 0) : ran == 3 ? new Vector2Int(0, 1) : new Vector2Int(0, -1));
                } while(v.x < 0 || v.y < 0 || v.x >= gridSize.x || v.y >= gridSize.y);
                tileSpawners[j] = v;
                grid[tileSpawners[j].x, tileSpawners[j].y] = 1;
                if(chanceOfNewSpawner > 0 && Random.Range(0, chanceOfNewSpawner) == 0) newSpawners.Add(new Vector2Int(tileSpawners[j].x, tileSpawners[j].y));
            }
            for (int j = 0; j < newSpawners.Count; j++) {
                tileSpawners.Add(newSpawners[j]);
            }
            newSpawners.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
