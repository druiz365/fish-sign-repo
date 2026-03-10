using System.Collections;
using UnityEngine;

public class GrowToSize : MonoBehaviour
{
    public float growSpeed = 1.5f;

    public float startScale = 0.2f;
    public float targetScale = 0.65f;

    public float pulseDelay = 0.5f;

    bool growing = false;
    PulseScale pulse;

    void Awake()
    {
        pulse = GetComponent<PulseScale>();
        if (pulse != null)
            pulse.enabled = false; // prevent pulsing at start
    }

    void OnEnable()
    {
        transform.localScale = new Vector3(startScale, startScale, transform.localScale.z);
        growing = true;
    }

    void Update()
    {
        if (!growing) return;

        Vector3 current = transform.localScale;
        Vector3 target = new Vector3(targetScale, targetScale, current.z);

        transform.localScale = Vector3.MoveTowards(
            current,
            target,
            growSpeed * Time.deltaTime
        );

        if (Mathf.Abs(transform.localScale.x - targetScale) < 0.001f)
        {
            growing = false;
            StartCoroutine(StartPulseAfterDelay());
        }
    }

    IEnumerator StartPulseAfterDelay()
    {
        yield return new WaitForSeconds(pulseDelay);

        if (pulse != null)
            pulse.enabled = true;
    }
}