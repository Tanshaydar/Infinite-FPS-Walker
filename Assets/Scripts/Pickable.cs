using UnityEngine;

public class Pickable : MonoBehaviour
{
    public AudioClip ItemPickUpSound;
    private static readonly float _rotationSpeed = 40f;

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(ItemPickUpSound, transform.position);
        //gameObject.SetActive(false);
        // Player picked up a pickable object, register score
        // Assignment indicated there will be no score system
    }
}