using UnityEngine;

public class Track : MonoBehaviour
{
    private TrackController _trackController;

    [Header("Obstacles")] public Obstacle[] ObstacleForwardLeft;
    public Obstacle[] ObstacleForwardCenter;
    public Obstacle[] ObstacleForwardRight;
    public Obstacle[] ObstacleBackwardLeft;
    public Obstacle[] ObstacleBackwardCenter;
    public Obstacle[] ObstacleBackwardRight;

    [Header("Pickables")] public Pickable[] PickableLeftLane;
    public Pickable[] PickableCenterLane;
    public Pickable[] PickableRightLane;

    private void Awake()
    {
        _trackController = FindObjectOfType<TrackController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _trackController.PoolGather(gameObject);
    }
}