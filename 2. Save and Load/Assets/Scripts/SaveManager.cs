using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to your player character prefab.
    private HealthSystem healthSystem;
    public SpawnBox spawnBoxScript;
    private int saveIndex = 1; // Initialize the save index to 1.
    private GameObject playerCharacter;
    private int healthToBeSaved;
    public HealthSystem playerHealthSystem;
    private static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public static SaveManager Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        //playerCharacter = GameObject.FindWithTag("Player");
        playerHealthSystem = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
        spawnBoxScript = GameObject.FindObjectOfType<SpawnBox>();
        if (spawnBoxScript == null)
        {
            Debug.LogError("SpawnBox script not found in the scene.");
            return;
        }

        
    }

    private void Update()
    {
        playerCharacter = GameObject.FindWithTag("Player");
        if (Input.GetKeyDown(KeyCode.R))
        {
            List<Vector3> boxLocations = spawnBoxScript.GetSpawnedBoxLocations();

            // Use the list as needed
            foreach (Vector3 location in boxLocations)
            {
                Debug.Log("Box Location: " + location);
            }

            healthToBeSaved = playerHealthSystem.GetCurrentHealth();
            Debug.Log(healthToBeSaved + " health to be saved");
            
            Debug.Log("Number of Box Locations: " + spawnBoxScript.spawnedBoxLocations.Count);
            ListBoxLocations(spawnBoxScript.spawnedBoxLocations);
            SaveCharacterData();
        }

    }


    private void SaveCharacterData()
    {
        // Create a new CharacterData instance and populate it with the data you want to save.
        CharacterData characterData = new CharacterData
        {
            Position = playerCharacter.transform.position,
            ID = playerPrefab.GetInstanceID(),
            Health = healthToBeSaved,
            BoxPositions = new BoxPositionData  // Initialize as an empty list
            {
                Positions = spawnBoxScript.spawnedBoxLocations // Assign the list of box positions
            }
        };

        // Add the box positions to the list
        characterData.BoxPositions.Positions.AddRange(spawnBoxScript.spawnedBoxLocations);

        // Convert the CharacterData instance to a JSON string.
        string jsonData = JsonUtility.ToJson(characterData);

        // Define the path where you want to save the file.
        string savePath = Path.Combine("playerSave" + saveIndex + ".json");

        // Write the JSON data to the file.
        File.WriteAllText(savePath, jsonData);
        Debug.Log("position: " + playerCharacter.transform.position);
        Debug.Log("Saved character data to: " + savePath);
        

        saveIndex++;
        if (saveIndex > 4)
        {
            saveIndex = 1; // Reset save index if it exceeds 4.
        }
    }

    void ListBoxLocations(List<Vector3> locations)
    {
        Debug.Log("Box Locations:");
        foreach (Vector3 position in locations)
        {
            Debug.Log(position.ToString());
        }
    }
}
    [System.Serializable]
public class CharacterData
{
    public Vector3 Position;
    public int ID;
    public int Health;
    public BoxPositionData BoxPositions;
}

[System.Serializable]
public class BoxPositionData
{
    public List<Vector3> Positions;
}

// ...