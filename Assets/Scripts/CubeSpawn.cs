using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private CubeScaler cubeScaler;
    [SerializeField] private CubeRandomColorChanger cubeColor;
    [SerializeField] private CubeExplosion cubeExplosion;

    public void SpawnCubes(GameObject cube, float splitChance)
    {
        int cubeMinCount = 2;
        int cubeMaxCount = 6;

        float radiusNextPosition = 5f;
        float nextSplitChance = splitChance * 0.5f;

        if (Random.value <= splitChance)
        {
            int cubeCount = Random.Range(cubeMinCount, cubeMaxCount + 1);

            List<GameObject> cubes = new List<GameObject>();

            for (int i = 0; i < cubeCount; i++)
            {
                Vector3 randomPosition = cube.transform.position + new Vector3(Random.Range(-radiusNextPosition, radiusNextPosition),
                    Random.Range(-radiusNextPosition, radiusNextPosition), Random.Range(-radiusNextPosition, radiusNextPosition));

                GameObject newCube = Instantiate(cube, randomPosition, Quaternion.identity);

                if (cubeScaler != null)
                    cubeScaler.ScaleCube(newCube);

                if (cubeColor != null)
                    cubeColor.ChangeColor(newCube);

                CubeController splitController = newCube.GetComponent<CubeController>();

                if (splitController != null)
                    splitController.ChangeSplitChance(nextSplitChance);

                cubes.Add(newCube);
            }

            if (cubeExplosion != null)
            {
                cubeExplosion.ExployCube(cube.transform.position, cubes);
            }
        }
    }
}
