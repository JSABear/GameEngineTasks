using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBox : MonoBehaviour
{
    public GameObject boxPrefab; // Reference to your box prefab
    public List<Vector3> spawnedBoxLocations = new List<Vector3>();

    public HealthSystem playerHealthSystem;

    private void Start()
    {
        // Get the HealthSystem component from the player character.
        playerHealthSystem = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnBoxInFront();
            playerHealthSystem.TakeDamage(10); // Adjust the damage amount as needed.
            //ListBoxLocations();
        }
    }

    void SpawnBoxInFront()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 2.0f; // Adjust the "2.0f" value to control the spawn distance in front of the player
        Quaternion spawnRotation = Quaternion.identity;

        // Instantiate the box and add its position to the list
        GameObject newBox = Instantiate(boxPrefab, spawnPosition, spawnRotation);
        spawnedBoxLocations.Add(spawnPosition);
        Debug.Log("position: " + spawnPosition);
    }

    void ListBoxLocations()
    {
        Debug.Log("Box Locations:");
        foreach (Vector3 position in spawnedBoxLocations)
        {
            Debug.Log(position.ToString());
        }
    }

    public List<Vector3> GetSpawnedBoxLocations()
    {
        return spawnedBoxLocations;
    }

    public void LoadDamage(int damage)
    {
        playerHealthSystem.TakeDamage(damage);
    }
}

