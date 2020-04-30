using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _roomSpawnPoint;
    private bool _canSpawnRoom;

    private void Start()
    {
        _canSpawnRoom = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>())
        {
            FirstPersonController character = other.GetComponent<FirstPersonController>();
            if (_canSpawnRoom && character.canSpawnRoom)
            {
                SpawnRoom();
                character.SetSpawnBuffer();
                Destroy(transform.parent.gameObject, 2); //Comment this out if you want.
            }
        }
    }

    void SpawnRoom()
    {
        int randomInt = Random.Range(0, 8);
        print("room number: " + randomInt);
        GameObject newRoom = Instantiate(RoomManager.Instance.roomPrefabs[randomInt], _roomSpawnPoint.position, transform.rotation, RoomManager.Instance.transform);
        _canSpawnRoom = false;
    }
}
