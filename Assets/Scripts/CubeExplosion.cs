using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    private float _explosionForce = 1000f;
    private float _explosionRadius = 20f;

    public void ExployCube(Vector3 cubePosition, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            Rigidbody cloneCubeRb = cube.GetComponent<Rigidbody>();

            if (cloneCubeRb != null)
                cloneCubeRb.AddExplosionForce(_explosionForce, cubePosition, _explosionRadius);
        }
    }
}
