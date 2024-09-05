using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private CubeScaler cubeScaler;
    [SerializeField] private CubeRandomColorChanger cubeColor;
    [SerializeField] private CubeExplosion cubeExplosion;

    public void SpawnCubes(Cube cube, float splitChance)
    {
        int cubeMinCount = 2;
        int cubeMaxCount = 6;

        float radiusNextPosition = 5f;
        float nextSplitChance = splitChance * 0.5f;

        int cubeCount = Random.Range(cubeMinCount, cubeMaxCount + 1);

        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = cube.transform.position + new Vector3(Random.Range(-radiusNextPosition, radiusNextPosition),
                Random.Range(-radiusNextPosition, radiusNextPosition), Random.Range(-radiusNextPosition, radiusNextPosition));

            Cube newCube = Instantiate(cube, randomPosition, Quaternion.identity);

            cubeScaler.ScaleCube(newCube);

            cubeColor.ChangeColor(newCube);

            Cube splitController = newCube.GetComponent<Cube>();

            if (splitController != null)
                splitController.ChangeSplitChance(nextSplitChance);

            cubes.Add(newCube);
        }

        cubeExplosion.ExployCube(cube.transform.position, cubes);
    }

    private void OnValidate()
    {
        if (cubeScaler == null)
        {
            Debug.Log("cubeScaler отсустствует!", this);
        }
        if (cubeColor == null)
        {
            Debug.Log("cubeColor отсутствует!", this);
        }
        if (cubeExplosion == null)
        {
            Debug.Log("cubeExplosion отсутствует!", this);
        }
    }
}
