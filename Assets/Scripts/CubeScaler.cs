using UnityEngine;

public class CubeScaler : MonoBehaviour
{
    private float _scaler = 0.5f;

    public void ScaleCube(GameObject cube)
    {
        cube.transform.localScale *= _scaler;
    }
}
