using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackgroundUpdater : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private int gridSize = 8;
    [SerializeField] private int numberOfSpritesPerRow = 15;
    private int currentSpriteToLoad = 0;
    private int currentBackgroundRows = 0;
    private int maxNumbersObBackgrounds = 150;
    private List<GameObject> createdBackgrounds = new List<GameObject>();
    private float lastYPos;
 
    private void Start()
    {
        lastYPos = transform.position.y;
        SpawnNewRow();
        SpawnNewRow();
        SpawnNewRow();
        SpawnNewRow();
        SpawnNewRow();
    }

    private void Update()
    {
        if (lastYPos - gridSize > transform.position.y)
        {
            SpawnNewRow();
            RemoveOldestTiles();
            lastYPos = transform.position.y;
        }
    }

    private void SpawnNewRow()
    {
        for(int i = 0; i < numberOfSpritesPerRow; i++)
        {
            GameObject gameObject = new GameObject();
            AddSprite(gameObject);
            Vector3 currentTilePosition = new Vector3(
                ((int)transform.position.x) + i * gridSize - (numberOfSpritesPerRow / 2 * gridSize), 
                -1 * currentBackgroundRows * gridSize, 
                0);

            gameObject.transform.position = currentTilePosition;
            createdBackgrounds.Add(gameObject);
        }

        currentBackgroundRows++;
    }

    private void RemoveOldestTiles()
    {
        while (createdBackgrounds.Count > maxNumbersObBackgrounds)
        {
            if (createdBackgrounds[0] != null)
            {
                Destroy(createdBackgrounds[0]);
                createdBackgrounds.RemoveAt(0);
            }
        }
    }

    private void AddSprite(GameObject gameObject)
    {
        SpriteRenderer backgroundSprite = gameObject.AddComponent<SpriteRenderer>();
        if (currentSpriteToLoad < backgroundSprites.Length)
        {
            backgroundSprite.sprite = backgroundSprites[currentSpriteToLoad];
        }
        else
        {
            Debug.Log(currentSpriteToLoad + " " + backgroundSprites.Length);
        }
        backgroundSprite.sortingLayerName = "Background";
    }
}
