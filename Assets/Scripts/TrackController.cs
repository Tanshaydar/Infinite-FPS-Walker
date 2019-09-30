using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    private static readonly float NEW_TRACK_OFFSET = 6.0f;
    private static readonly int STARTING_TRACK_QUANTITY = 5;
    private static readonly int VARIATION_TRACK_QUANTITY = 15;
    [SerializeField] private GameObject DefaultTrackPrefab;
    [SerializeField] private GameObject[] TrackPrefabs;

    [SerializeField]
    private List<GameObject> _pool;
    
    private float _currentOffset;

    private void Start()
    {
        for (int i = 0; i < VARIATION_TRACK_QUANTITY; i++)
        {
            Instantiate(DefaultTrackPrefab, new Vector3(0, 0, _currentOffset), Quaternion.identity);
            _currentOffset += NEW_TRACK_OFFSET;
        }

        for (int i = 0; i < TrackPrefabs.Length; i++)
        {
            Instantiate(TrackPrefabs[i], new Vector3(0, 0, _currentOffset),
                Quaternion.identity);
            _currentOffset += NEW_TRACK_OFFSET;
        }
    }

    public void PoolGather(GameObject track)
    {
        _pool.Add(track);
        if (_pool.Count > STARTING_TRACK_QUANTITY)
        {
            GameObject newTrack = _pool[Random.Range(0, _pool.Count - 1)];
            newTrack.transform.position = new Vector3(0, 0, _currentOffset);
            _currentOffset += NEW_TRACK_OFFSET;
            _pool.Remove(newTrack);
        }
    }
}