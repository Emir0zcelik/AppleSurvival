using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform appleSpawnPoint;
    [SerializeField] private Transform skeletonSpawnPoint1;
    [SerializeField] private Transform skeletonSpawnPoint2;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject apple;

    private GameObject appleClone;
    private GameObject skeletonClone1;
    private GameObject skeletonClone2;

    private void Start()
    {
        RespawnPlayer();
        
        RespawnApple();

        RespawnSkeleton();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Skeleton"))
        {
            RespawnPlayer();

            DestroyApples();

            RespawnApple();

            DestroySkeletons();

            RespawnSkeleton();
        }
    }

    private void RespawnPlayer()
    {
        transform.position = playerSpawnPoint.position;
    }

    public void RespawnApple()
    {
        appleClone = Instantiate(apple, appleSpawnPoint.position, Quaternion.identity);
    }

    public void DestroyApples()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
            GameObject.Destroy(apple);
    }

    private void RespawnSkeleton()
    {
        skeletonClone1 = Instantiate(skeleton, skeletonSpawnPoint1.position, Quaternion.identity);
        skeletonClone2 = Instantiate(skeleton, skeletonSpawnPoint2.position, Quaternion.identity);
    }

    public void DestroySkeletons()
    {
        GameObject[] skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
        foreach (GameObject skeleton in skeletons)
            GameObject.Destroy(skeleton);
    }
}
