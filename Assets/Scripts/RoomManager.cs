using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public List<GameObject> roomPrefabs;

    void Awake()
    {
        Instance = this;
    }
}
