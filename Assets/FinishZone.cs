using UnityEngine;

public class FinishZone : MonoBehaviour
{

    public Transform PlayerObject; 
    public float finish_zone = 2f;

    public GameObject winPanel;
    
    void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerObject == null) return;

        float distance = Vector3.Distance(transform.position, PlayerObject.position);
       
        if (distance <= finish_zone)
        {
            ActivateWinPanel();
        }
    }

    void ActivateWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);

        }
    }
}

