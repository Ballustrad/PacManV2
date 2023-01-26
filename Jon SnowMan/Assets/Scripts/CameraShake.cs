using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool Impact = true;

    public IEnumerator Shake(float duration, float magnitude)
    {
        transform.localPosition = new Vector3(0, 0, -10);
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-6f, 6f) * magnitude;
            float y = Random.Range(-6f, 6f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
