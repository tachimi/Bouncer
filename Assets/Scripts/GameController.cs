using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _cylinderPrefab;
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private Transform _cylindersParent;

    [SerializeField] private Vector3[] _borders;
    [SerializeField] private Color[] _colors;

    private GameObject _cube;

    private void Awake()
    {
        _cube = Instantiate(_cubePrefab);

        SpawnSphere();

        for (int i = 0; i < 6; i++)
        {
            var cylinder = Instantiate(_cylinderPrefab, _cylindersParent);
            cylinder.transform.position = new Vector3(Random.Range(_borders[0].x, _borders[1].x), 6,
                Random.Range(_borders[0].z, _borders[1].y));
            cylinder.GetComponent<MeshRenderer>().material.color = _colors[Random.Range(0, 3)];
        }
    }

    public void SpawnSphere()
    {
        var sphere = Instantiate(_spherePrefab);
        sphere.transform.position = new Vector3(Random.Range(-40, 40), 2, Random.Range(-40, 40));
        sphere.GetComponent<MeshRenderer>().material.color = _colors[Random.Range(0, 3)];
    }

    public void ChangeCubeColor(Color color)
    {
        _cube.GetComponent<MeshRenderer>().material.color = color;
    }

    public void DestroyCylinder(GameObject cylinder)
    {
        var cylinderColor = cylinder.GetComponent<MeshRenderer>().material.color;
        var cubeColor = _cube.GetComponent<MeshRenderer>().material.color;
        if (cubeColor == cylinderColor)
        {
            Destroy(cylinder);
        }
    }
}