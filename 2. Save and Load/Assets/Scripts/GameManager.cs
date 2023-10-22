using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private LoadGameState loadGameState;
    public GameObject boxPrefab;
    private int receivedSaveSlot;
    

    int saveSlot = LoadGameState.Instance.slot;


    public void Start()
    {
        DontDestroyOnLoad(playerPrefab);
        
        if (saveSlot != 5)
        {
            Debug.Log(saveSlot + "receivedSaveSlot");
            int saveSlotToLoad = saveSlot; // Change this to the desired save slot.
            if (loadGameState.IsSaveDataAvailable(saveSlotToLoad))
            {
                // Load the data from the specified save slot.
                CharacterData loadedCharacterData = loadGameState.FetchCharacterData(saveSlotToLoad);
                // Now, spawn the player and boxes with the loaded data.
                Vector3 playerPosition = loadedCharacterData.Position;
                int playerHealth = (int)loadedCharacterData.Health; // Cast to int if needed.
                Debug.Log(loadedCharacterData.Position);
                SpawnPlayerAndBoxes(playerPosition, playerHealth);
            }
            else
            {
                Debug.LogError("loadGameState is not assigned.");
            }
        }
        
        Debug.Log("end of start");
    }

    //private void SpawnPlayerAndBoxes(Vector3 playerPosition, int playerHealth, List<Vector3> boxPositions)
    private void SpawnPlayerAndBoxes(Vector3 playerPosition, int playerHealth)
    {
        GameObject playerObject = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        playerObject.tag = "Player"; // Set the tag of the instantiated object.
        /*
        foreach (Vector3 boxPosition in boxPositions)
        {
            GameObject boxObject = Instantiate(boxPrefab, boxPosition, Quaternion.identity);
        }
        */
    }

    public void SetSaveSlotValue(int saveSlot)
    {
        receivedSaveSlot = saveSlot;

        // Now you can use receivedSaveSlot in this script.
        Debug.Log("Received Save Slot: " + receivedSaveSlot);
    }


}



