using UnityEngine;
using UnityEngine.SceneManagement;

public class BannedZones : MonoBehaviour
{
    public Transform PlayerObject;
    
    public float warning_zone = 3f; 
    public float restart_zone = 1f;
    public float resetTime = 2f;

    public Renderer zoneRenderer; 
    public float shakeIntensity = 0.05f;

    private Color originalColor;
    private Vector3 originalPosition;
    private float timer = 0f;

    void Start()
    {
        originalPosition = transform.position;

        if (zoneRenderer == null)
        {
            zoneRenderer = GetComponent<Renderer>();
        }

        if (zoneRenderer != null)
        {
            originalColor = zoneRenderer.material.color;
        }
    }

    void Update()
    {
        if (PlayerObject == null) return;

        // Determines playerdistance from no object zone to trigger specific proximity funstions
        Vector3 distance = PlayerObject.position - transform.position;
        float Range_Zone = distance.magnitude;
       
        // restartzone
        if (Range_Zone <= restart_zone)
        {
            ApplyWarning();

            // Run 2 second timer till reset
            timer += Time.deltaTime;
            if (timer >= resetTime)
            {
                RestartScene();
            }
        }
        // Warning
        else if (Range_Zone <= warning_zone)
        {
            ApplyWarning();
            timer = 0f; // Reset timer if player backs out slightly
        }
        //Safe
        else 
        {
            ResetTime();
            timer = 0f; // Reset timer completely when safe
        }
    }
    
    void ApplyWarning()
    {
        if (zoneRenderer != null)
        {
            zoneRenderer.material.color = Color.red;
        }

        transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
    }

    void ResetTime()
    {
        if (zoneRenderer != null)
        {
            zoneRenderer.material.color = originalColor;
        }

        transform.position = originalPosition;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
