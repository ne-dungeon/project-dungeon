using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    [Header("Basic Room Templates")]
    public GameObject[] rooms;

    [Header("Additional")]
    public int totalRooms;
    public GameObject spawnPoint_pf;

    private void Start()
    {
        Transform spawnPoints;
        GameObject spawningPoint;
        int count = 0;

        // Get the Parent "SpawnPoints"
        spawnPoints = GameObject.Find("SpawnPoints").transform;

        // SPAWN THE TOTAL ROOMS
        while (count < totalRooms)
        {
            // Get a random spawn point from the "SpawnPoints" Parent
            if (spawnPoints.childCount > 0 && count != totalRooms-1)
            {
                int i = Random.Range(0, spawnPoints.childCount);
                spawningPoint = spawnPoints.GetChild(i).gameObject;

                // We now check our spawn point (set its doors):
                spawningPoint = CheckSpawnPoint(spawningPoint, false);

                // We now spawn our room
                SpawnRoom(spawningPoint);

                // We now spawn our new spawn points
                SpawnNewPoints(spawningPoint);

                // Destroy old spawning point
                /*GameObject.Destroy(spawningPoint);*/
            }
            else if(count == totalRooms-1)
            {
                for (int i = 0; i < spawnPoints.childCount; i++)
                {
                    int j = Random.Range(0, spawnPoints.childCount);
                    spawningPoint = spawnPoints.GetChild(j).gameObject;
                    // We now check our spawn point (set its doors):
                    spawningPoint = CheckSpawnPoint(spawningPoint, true);

                    // We now spawn our room
                    SpawnRoom(spawningPoint);
                }

/*                // We now spawn our new spawn points
                SpawnNewPoints(spawningPoint);*/
            }

            // Increment our count
            count++;
        }
    }

    GameObject CheckSpawnPoint(GameObject point, bool lastRooms)
    {
        float point_xPos = point.transform.position.x;
        float point_yPos = point.transform.position.y;

        // -- Check SpawnPoint's Surroundings: --

        if (GameObject.Find("Room_" + (point_xPos - 1.25f) + " " + point_yPos)) // Room at the left?
        {
            point.GetComponent<SpawnPoint>().roomAtLeft = true;

            GameObject room = GameObject.Find("Room_" + (point_xPos - 1.25f) + " " + point_yPos);

            if (room.GetComponent<Room>().doorAtRight == true)
                point.GetComponent<SpawnPoint>().doorAtLeft = true;
            else
                point.GetComponent<SpawnPoint>().doorAtLeft = false;
        }
        else
        {
            if (Random.Range(0, 2) == 0 || lastRooms)
                point.GetComponent<SpawnPoint>().doorAtLeft = false;
            else
                point.GetComponent<SpawnPoint>().doorAtLeft = true;
        }

        if (GameObject.Find("Room_" + point_xPos + " " + (point_yPos + 1.25f))) // Room at the top?
        {
            point.GetComponent<SpawnPoint>().roomAtTop = true;

            GameObject room = GameObject.Find("Room_" + point_xPos + " " + (point_yPos + 1.25f));

            if (room.GetComponent<Room>().doorAtBottom == true)
                point.GetComponent<SpawnPoint>().doorAtTop = true;
            else
                point.GetComponent<SpawnPoint>().doorAtTop = false;
        }
        else
        {
            if (Random.Range(0, 2) == 0 || lastRooms)
                point.GetComponent<SpawnPoint>().doorAtTop = false;
            else
                point.GetComponent<SpawnPoint>().doorAtTop = true;
        }

        if (GameObject.Find("Room_" + (point_xPos + 1.25f) + " " + point_yPos)) // Room to the right?
        {
            point.GetComponent<SpawnPoint>().roomAtRight = true;

            GameObject room = GameObject.Find("Room_" + (point_xPos + 1.25f) + " " + point_yPos);

            if (room.GetComponent<Room>().doorAtLeft == true)
                point.GetComponent<SpawnPoint>().doorAtRight = true;
            else
                point.GetComponent<SpawnPoint>().doorAtRight = false;
        }
        else
        {
            if (Random.Range(0, 2) == 0 || lastRooms)
                point.GetComponent<SpawnPoint>().doorAtRight = false;
            else
                point.GetComponent<SpawnPoint>().doorAtRight = true;
        }

        if (GameObject.Find("Room_" + point_xPos + " " + (point_yPos - 1.25f))) // Room at the bottom?
        {
            point.GetComponent<SpawnPoint>().roomAtBottom = true;

            GameObject room = GameObject.Find("Room_" + point_xPos + " " + (point_yPos - 1.25f));

            if (room.GetComponent<Room>().doorAtTop == true)
                point.GetComponent<SpawnPoint>().doorAtBottom = true;
            else
                point.GetComponent<SpawnPoint>().doorAtBottom = false;
        }
        else
        {
            if (Random.Range(0, 2) == 0 || lastRooms)
                point.GetComponent<SpawnPoint>().doorAtBottom = false;
            else
                point.GetComponent<SpawnPoint>().doorAtBottom = true;
        }

        return point;
    }

    void SpawnRoom(GameObject point)
    {
        // Loop through rooms to spawn the correct one
        foreach (GameObject room in rooms)
        {
            // Do these rooms have doors that correspond w/ spawn point?
            if (room.GetComponent<Room>().doorAtTop == point.GetComponent<SpawnPoint>().doorAtTop
                && room.GetComponent<Room>().doorAtRight == point.GetComponent<SpawnPoint>().doorAtRight
                && room.GetComponent<Room>().doorAtLeft == point.GetComponent<SpawnPoint>().doorAtLeft
                && room.GetComponent<Room>().doorAtBottom == point.GetComponent<SpawnPoint>().doorAtBottom)
            {
                // Spawn room
                GameObject newRoom = Instantiate(room, point.transform.position, transform.rotation);

                // Change room name
                newRoom.name = "Room_" + point.transform.position.x + " " + point.transform.position.y;
                point.transform.parent = newRoom.transform;
                newRoom.transform.parent = GameObject.Find("Rooms").transform;
            }
        }
    }

    void SpawnNewPoints(GameObject point)
    {

        // Does this point/room not already exist, and do we have a door at the top?
        if (!GameObject.Find("SpawnPoint_" + point.transform.position.x
            + " " + (point.transform.position.y + 1.25f))
            && !point.GetComponent<SpawnPoint>().roomAtTop
            && point.GetComponent<SpawnPoint>().doorAtTop)
        {
            // Spawn a new point adjacent to that door
            GameObject newPoint = Instantiate(spawnPoint_pf, point.transform.position + new Vector3(0, 1.25f, 0), transform.rotation);

            // Change name
            newPoint.name = "SpawnPoint_" + point.transform.position.x
            + " " + (point.transform.position.y + 1.25f);

            newPoint.transform.parent = GameObject.Find("SpawnPoints").transform;
        }

        // Does this point not already exist, and do we have a door at the bottom?
        if (!GameObject.Find("SpawnPoint_" + point.transform.position.x
            + " " + (point.transform.position.y - 1.25f))
            && !point.GetComponent<SpawnPoint>().roomAtBottom
            && point.GetComponent<SpawnPoint>().doorAtBottom)
        {
            // Spawn a new point adjacent to that door
            GameObject newPoint = Instantiate(spawnPoint_pf, point.transform.position + new Vector3(0, -1.25f, 0), transform.rotation);

            // Change name
            newPoint.name = "SpawnPoint_" + point.transform.position.x
            + " " + (point.transform.position.y - 1.25f);

            newPoint.transform.parent = GameObject.Find("SpawnPoints").transform;
        }

        // Does this point not already exist, and do we have a door at the right?
        if (!GameObject.Find("SpawnPoint_" + (point.transform.position.x + 1.25f)
            + " " + point.transform.position.y)
            && !point.GetComponent<SpawnPoint>().roomAtRight
            && point.GetComponent<SpawnPoint>().doorAtRight)
        {
            // Spawn a new point adjacent to that door
            GameObject newPoint = Instantiate(spawnPoint_pf, point.transform.position + new Vector3(1.25f, 0, 0), transform.rotation);

            // Change name
            newPoint.name = "SpawnPoint_" + (point.transform.position.x + 1.25f)
            + " " + point.transform.position.y;

            newPoint.transform.parent = GameObject.Find("SpawnPoints").transform;
        }

        // Does this point not already exist, and do we have a door at the left?
        if (!GameObject.Find("SpawnPoint_" + (point.transform.position.x - 1.25f)
            + " " + point.transform.position.y)
            && !point.GetComponent<SpawnPoint>().roomAtLeft
            && point.GetComponent<SpawnPoint>().doorAtLeft)
        {
            // Spawn a new point adjacent to that door
            GameObject newPoint = Instantiate(spawnPoint_pf, point.transform.position + new Vector3(-1.25f, 0, 0), transform.rotation);

            // Change name
            newPoint.name = "SpawnPoint_" + (point.transform.position.x - 1.25f)
            + " " + point.transform.position.y;

            newPoint.transform.parent = GameObject.Find("SpawnPoints").transform;
        }
    }

    void spawnFinalRooms()
    {
        for (int i = 0; i < GameObject.Find("SpawnPoints").transform.childCount; i++)
        {
            GameObject point = GameObject.Find("SpawnPoints").transform.GetChild(i).gameObject;
            point = CheckSpawnPoint(point, true);
            SpawnRoom(point);
        }
    }
}
