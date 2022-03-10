using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public Transform target;

    Path path;
    Seeker seeker;
    Transform rb;
    float movementSpeed = 1f;
    float nextWaypointDistance = 3f;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    void Start()
    {
        // Assign the seeker after the game starts
        seeker = GetComponent<Seeker>();

        // Start a seeker path every x repeats/seconds
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        // Start a new path to the targetPosition, call the the OnPathComplete function
        // when the path has been calculated (which may take a few frames depending on the complexity)
        seeker.StartPath(transform.position, target.position, OnPathComplete);


        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        // https://arongranberg.com/astar/documentation/dev_4_1_6_17dee0ac/graph-updates.php
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        
    }

    void OnPathComplete(Path p)
    {
        // Assing the path and current waypoint valuues
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // We have no path to follow yet, so don't do anything
        if (path == null)
            return;

        // CHeck if we have run past the path end
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }
        
        // Move the enemy towards the end point
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(currentPosition, path.vectorPath[currentWaypoint], movementSpeed * Time.deltaTime);

        // Calculate the distance to move over to the next way point
        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
