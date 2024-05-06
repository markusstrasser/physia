using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance { get; private set; }

    private Dictionary<GameObject, ObjectStats> objects = new Dictionary<GameObject, ObjectStats>();

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

    public void RegisterObject(GameObject obj, float health, float damage)
    {
        objects[obj] = new ObjectStats(health, damage, Vector3.zero);
    }

    public ObjectStats GetStats(GameObject obj)
    {
        if (objects.ContainsKey(obj))
        {
            // Update dynamic stats like distance dynamically
            objects[obj].Distance = Vector3.Distance(obj.transform.position, Camera.main.transform.position);
            return objects[obj];
        }
        return null;
    }
}

public class ObjectStats
{
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Distance { get; set; } // Distance from the camera

    public ObjectStats(float health, float damage, Vector3 position)
    {
        Health = health;
        Damage = damage;
        //Distance = 0;
    }
}