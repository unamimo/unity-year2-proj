using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private GameController _gameController;
    [SerializeField]
    private PlatformPath waypointPath;
    [SerializeField]
    private float speed;

    private int targetWaypointIndex;
    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameController.GetState() != GameController.EGameState.Playing)
            return;

        elapsed += Time.deltaTime;

        float elapsedPercent = elapsed / timeToWaypoint;
        elapsedPercent = Mathf.SmoothStep(0, 1, elapsedPercent);
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercent);
        
        if(elapsedPercent >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        elapsed = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

}
