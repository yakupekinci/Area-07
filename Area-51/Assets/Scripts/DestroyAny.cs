using System.Collections;
using UnityEngine;

public class DestroyAny : MonoBehaviour
{
    public float destructDelay = 2f;

    private void Start()
    {
        StartCoroutine(DestructAfterDelay());
    }

    private IEnumerator DestructAfterDelay()
    {
        yield return new WaitForSeconds(destructDelay);
        Destroy(gameObject);
    }
}
