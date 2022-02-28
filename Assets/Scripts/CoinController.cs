using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private float speed;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = (player.transform.position - gameObject.transform.position+Vector3.up)*speed;
    }
    private void OnCollisionEnter(Collision collision) 
    {   
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponentInChildren<BackpackController>().money += value;
            player.GetComponentInChildren<BackpackController>().changeMoneyText();
            Destroy(gameObject);
        }
    }
}
