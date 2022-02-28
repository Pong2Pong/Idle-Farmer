using UnityEngine;

public class FarmTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject == player)
        {
            playerController.isTriggered = true;
        }
    }
    private void OnTriggerExit(Collider collider) 
    {
        if(collider.gameObject == player)
        {
            playerController.isTriggered = false;
        }
    }
}
