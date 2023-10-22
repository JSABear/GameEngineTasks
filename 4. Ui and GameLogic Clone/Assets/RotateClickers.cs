using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClickers : MonoBehaviour
{
    public GameObject objectToSpawn;  // The prefab you want to spawn
    public Transform centerPoint;     // The center point for spawning objects

    private int currentSpawnCount = 0;
    private float circleRadius = 2.45f; // Radius of the initial circle
    private float angle = 0.0f;

 

    public void SpawnObject()
    {
        if (currentSpawnCount < 20)
        {
            // Calculate the position of the next object in a circle
            float x = centerPoint.position.x + circleRadius * Mathf.Cos(angle);
            float y = centerPoint.position.y + circleRadius * Mathf.Sin(angle);
            Vector3 spawnPosition = new Vector3(x, y, 0);

            // Spawn the object
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Calculate the rotation to make the pointy end face the center point
            Vector3 lookDirection = centerPoint.position - spawnedObject.transform.position;
            float objectRotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            spawnedObject.transform.rotation = Quaternion.Euler(0, 0, objectRotation - 90f);

            // Increment the angle for the next object
            angle -= (2 * Mathf.PI) / 20; // 20 objects in a circle (negative to go clockwise)

            currentSpawnCount++;
        }
        else
        {
            // Switch to spawning objects around a larger axis
            circleRadius += 1.0f;
            angle = 0.0f;
            currentSpawnCount = 0;
        }
    }
}
