using TMPro;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float _pushForce = 1f;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                _rigidbody.velocity = Vector3.zero;
                var direction = hitInfo.point - transform.position;
                _rigidbody.AddForce(direction * _pushForce, ForceMode.Impulse);
            }
        }

        if (transform.position.y < 0)
        {
            transform.position = new Vector3(0f, 1.5f, 0f);
            _rigidbody.velocity = Vector3.zero;
        }
    }
}