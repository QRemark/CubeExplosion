using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    private float _explosionForce = 1000f;
    private float _explosionRadius = 20f;

    public void ExployCube(Vector3 cubePosition, List <GameObject> newCubes)
    {
        foreach (GameObject cube in newCubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, cubePosition, _explosionRadius);
        }
    }
}
