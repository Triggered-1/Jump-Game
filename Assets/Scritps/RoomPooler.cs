using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class RoomPooler : MonoBehaviour
{
    public static RoomPooler Instance;

    public Vector3 RoomSpawnPos;
    public List<Tilemap> groundmaps;
    public RoomInfo[] roomPrefabs;
    public CinemachineConfiner confiner;


    private List<RoomInfo> rooms;
    private Queue<RoomInfo> activeRooms = new Queue<RoomInfo>();
    private Vector3 newRoomPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rooms = new List<RoomInfo>();
        groundmaps = new List<Tilemap>();
        for (int i = 0; i < roomPrefabs.Length; i++)
        {
            RoomInfo room = Instantiate(roomPrefabs[i]);
            rooms.Add(room);
            room.transform.parent = transform;
            room.gameObject.SetActive(false);
        }

        SpawnFromPool(new Vector3(0,9.5f,0));
        PlayerControl.OnMove += HandleRoomSpawn;

    }

    public void SpawnFromPool(Vector3 position)
    {
        int randomRoom;
        do
        {
            randomRoom = Random.Range(0, rooms.Count);
            Debug.Log("rooms" + randomRoom);
        } while (rooms[randomRoom].gameObject.activeSelf);

        groundmaps.Add(rooms[randomRoom].Groundmap);
        activeRooms.Enqueue(rooms[randomRoom]);
        newRoomPos = position + RoomSpawnPos;
        rooms[randomRoom].transform.position = newRoomPos;
        rooms[randomRoom].gameObject.SetActive(true);
        confiner.m_BoundingShape2D = rooms[randomRoom].RoomConfiner;
        Debug.Log(rooms[randomRoom].name);
    }

    private void SpawnStartRoom(Vector3 StartPosition)
    {
        groundmaps.Add(rooms[0].Groundmap);
        activeRooms.Enqueue(rooms[0]);
        newRoomPos = StartPosition + RoomSpawnPos;
        rooms[0].transform.position = newRoomPos;
        rooms[0].gameObject.SetActive(true);
        confiner.m_BoundingShape2D = rooms[0].RoomConfiner;
    }

    public void DespawnFromPool(RoomInfo room)
    {
        groundmaps.Remove(room.Groundmap);
        room.gameObject.SetActive(false);
        activeRooms.Dequeue();
    }
    
    private void HandleRoomSpawn()
    {
        if (PlayerControl.instance.transform.position.y >= newRoomPos.y)
        {
            if (activeRooms.Count > 1)
            {
                DespawnFromPool(activeRooms.Peek()); 
            }
            SpawnFromPool(activeRooms.Peek().transform.position);
        }
    }
}
