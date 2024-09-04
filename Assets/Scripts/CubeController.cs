using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeDestroyer cubeDestroyer;
    [SerializeField] private CubeSpawn cubeSpawn;

    private float _splitChance = 1.0f;

    private void OnMouseDown()
    {
        if (cubeDestroyer != null)
        {
            cubeDestroyer.DestroyCube(gameObject);
        }
        if (cubeSpawn != null)
        {
            cubeSpawn.SpawnCubes(gameObject, _splitChance);
        }
    }

    public void ChangeSplitChance(float chance)
    {
        _splitChance = chance;
    }
}
