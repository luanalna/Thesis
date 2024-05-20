using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particlesPrefab; // inspector refernces to the particle prefab material
    int numberOfParticles = 10000; // number of particles created
    float minDistance = 5f; // Minimum distance from the camera
    float maxDistance = 30f; // Maximum distance from the camera
    private bool particlesCreated = false;
    public bool create = false; // triigger to create particles from extern

    private List<Transform> particles = new List<Transform>();

    void Start()
    {
        particlesCreated = false;
        create = false;
    }

    void Update()
    {
        if(create && !particlesCreated)
        {
            
            for (int i = 0; i < numberOfParticles; i++)
            {
                // Instantiate spheres within the specified distance range
                float distance = Random.Range(minDistance, maxDistance); // create a random distance between min and max
                Vector3 randomPosition = Random.onUnitSphere * distance; // create a vector [distance, distance, distance]
                GameObject sphere = Instantiate(particlesPrefab, randomPosition, Quaternion.identity); // create one GameObject from a [sphere, position, orientation]
                particles.Add(sphere.transform); // add the sphere to particles list
            }
        particlesCreated = true;
        }

    }

}
