using UnityEngine;

[DisallowMultipleComponent]
public class DestroyAfter : MonoBehaviour
{
    [SerializeField, Tooltip("The lifetime")]
    private float lifetime = 1f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime) {
            Destroy(gameObject);
        }
    }
}
