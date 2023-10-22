using UnityEngine;

[System.Serializable]
public class Player
{
    public int id;
    public int health;
    public Vector3 position;

    public override string ToString()
    {
        return $"ID: {id}, Position: {position}, Health: {health}";
    }
}
