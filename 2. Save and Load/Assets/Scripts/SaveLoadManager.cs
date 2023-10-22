/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.Json;

public class SaveLoadManager : MonoBehaviour
{

    private Transform playerTransform;
    private HealthSystem healthSystem;
    private const int MaxSaveSlots = 4;
    private int slotId = 1;
    private string saveFileName = "playerSave.json";


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        healthSystem = playerTransform.GetComponent<HealthSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveCharacterData();
        }
    }

    private void SaveCharacterData()
    {
        slotId = slotId % MaxSaveSlots + 1; // Increment and wrap slotId
        Debug.Log(slotId);
        UpdatePlayerSlot(slotId);
    }

    private List<Player> FetchPlayerFile()
    {
        if (File.Exists(saveFileName))
        {
            Debug.Log("memeshit");
            var jsonContent = File.ReadAllText(saveFileName);
            Debug.Log(jsonContent);
            return JsonUtility.FromJson<List<Player>>(jsonContent);
        }
        return new List<Player>();
    }

    private void SavePlayerFile(List<Player> players)
    {
        var jsonContent = JsonUtility.ToJson(players);
        Debug.Log("SavePlayerFile");
        Debug.Log(players);
        Debug.Log(players.Count);

        File.WriteAllText(saveFileName, jsonContent);
    }

    private void UpdatePlayerSlot(int slotId) 
    {
        List<Player> players = FetchPlayerFile();
        Player playerToUpdate = players.Find(p => p.id == slotId);

        if (playerToUpdate == null)
        {
            Debug.Log("if (playerToUpdate == null)");
            Debug.Log(players.Count);
            playerToUpdate = new Player() { id = slotId };
            players.Add(playerToUpdate);
            Debug.Log(players.Count);
        }

        playerToUpdate.position = playerTransform.position;
        playerToUpdate.health = healthSystem.GetCurrentHealth();
        Debug.Log(playerToUpdate);
        SavePlayerFile(players);
    }
}
*/