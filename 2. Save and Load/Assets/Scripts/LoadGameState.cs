using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadGameState : MonoBehaviour
{
    public GameObject loadSavePanel;

    // Define a delegate and an event to notify when data is loaded
    public delegate void DataLoadedEvent(CharacterData characterData);
    public event DataLoadedEvent OnDataLoaded;

    public GameManager gameManager;

    public static LoadGameState Instance { get; private set; }
    public LoadGameState loadGameState;
    public int slot = 5;  // Make it public
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    public HealthSystem playerHealthSystem;
    public GameObject healthTextObject;
    public static int health;
    

    private SpawnBox spawnBoxScript;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CharacterData FetchCharacterData(int saveSlot)
    {
        slot = saveSlot;
        Debug.Log(slot + "changed global FetchData");
        Debug.Log(saveSlot + " FetchCharacterData");
        string savePath = $"playerSave{saveSlot}.json";

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            CharacterData characterData = JsonUtility.FromJson<CharacterData>(json);
            Debug.Log("Loaded character data: " + characterData.ToString());
            Debug.Log(savePath);
            return characterData;
        }
        else
        {
            
            string json = File.ReadAllText("newSave.json");
            CharacterData characterData = JsonUtility.FromJson<CharacterData>(json);
            Debug.Log("Loaded character data: " + characterData.ToString());
            Debug.Log("newSave.json");
            return characterData;
        }
    }

    public bool IsSaveDataAvailable(int saveSlot)
    {
        Debug.Log(saveSlot + " IsSaveDataAvailabl");
        string savePath = $"playerSave{saveSlot}.json";
        return File.Exists(savePath);
    }

    public void LoadData(int saveSlot)
    {
        slot = saveSlot;
        Debug.Log(saveSlot + " LoadData");
        CharacterData loadedCharacterData = FetchCharacterData(saveSlot);
        SceneManager.LoadScene("Game");
        Debug.Log(slot + " Global slot after changes");

        if (loadedCharacterData != null)
        {
            Debug.Log("Did we get here?");
            Vector3 playerPosition = loadedCharacterData.Position;
            GameObject playerObject = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
            playerObject.tag = "Player";
            DontDestroyOnLoad(playerObject);
            SceneManager.LoadScene("Game");
            Debug.Log(playerPosition);

            OnDataLoaded?.Invoke(loadedCharacterData);
            health = loadedCharacterData.Health;
            Debug.Log(health + " Loaded health");

            // Find the HealthSystem component in the HealthTextObject
            playerHealthSystem = playerObject.GetComponent<HealthSystem>();
            if (playerHealthSystem != null)
            {
                playerHealthSystem.SetCurrentHealth(health);
            }

            // Load and place the boxes
            List<Vector3> boxPositions = loadedCharacterData.BoxPositions.Positions;
            foreach (Vector3 boxPosition in boxPositions)
            {
                // Instantiate the box at the stored position
                GameObject newBox = Instantiate(boxPrefab, boxPosition, Quaternion.identity);
                DontDestroyOnLoad(newBox);
                //spawnBoxScript.spawnedBoxLocations.Add(boxPosition);
            }
        }
        
    }
    

    public void OpenPanel()
    {
        if (loadSavePanel != null)
        {
            loadSavePanel.SetActive(true); // Show the panel
        }
    }

    public void ClosePanel()
    {
        // Check if the load/save panel is not null
        if (loadSavePanel != null)
        {
            loadSavePanel.SetActive(false); // Hide the panel
        }
    }
}
