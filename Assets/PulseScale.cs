using UnityEngine;

public class PulseScale : MonoBehaviour
{
    public float amplitude = 0.03f;
    public float frequency = 1.2f;

    Vector3 baseScale;

    void OnEnable()
    {
        // Capture the scale after GrowToSize finishes
        baseScale = transform.localScale;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.localScale = new Vector3(
            baseScale.x + offset,
            baseScale.y + offset,
            baseScale.z
        );
    }
}