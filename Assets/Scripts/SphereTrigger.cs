using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _gameController.ChangeCubeColor(gameObject.GetComponent<MeshRenderer>().material.color);
            Destroy(gameObject);
            _gameController.SpawnSphere();
        }
    }
}