using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatPointController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float timeToLive;
    [SerializeField] private float speed;
    public bool isInBackpack = false;
    public bool forced = false;
    public Vector3 direction;

    void Start()
    {
        target = GameObject.Find("Player");
    }
    void FixedUpdate()
    {
        timeToLive -= 1*Time.deltaTime;
        if((timeToLive<=0)&&(!isInBackpack))
        {
            if(forced)
            target.GetComponentInChildren<BackpackController>().targetCapacity-=1;
            Destroy(gameObject);
        }
        if(forced)
        {
            if(target.GetComponentInChildren<BackpackController>().curCapacity >= target.GetComponentInChildren<BackpackController>().capacity)
            {
                forced=false;
                direction = Vector3.zero;
            }
            direction = Vector3.Lerp(target.transform.position,-gameObject.transform.position,0.5f);
            gameObject.GetComponent<Rigidbody>().velocity = direction*speed;
        }
        
        
    }
    private void OnTriggerEnter(Collider collider) 
    {
        if((collider.gameObject.tag == "Backpack") && 
        (collider.GetComponent<BackpackController>().targetCapacity < 
        collider.GetComponent<BackpackController>().capacity)&&
        (!isInBackpack))
        {
            collider.GetComponent<BackpackController>().targetCapacity+=1;
            forced=true;
        }
    }
    private void OnTriggerExit(Collider collider) 
    {
        if(collider.gameObject.tag == "Backpack")
        {
            forced=false;
            direction = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if((collision.gameObject.tag == "Player") && 
        (collision.gameObject.GetComponentInChildren<BackpackController>().curCapacity < 
        collision.gameObject.GetComponentInChildren<BackpackController>().capacity)&&
        (!isInBackpack))
        {
            isInBackpack = true;
            forced=false;
            collision.gameObject.GetComponentInChildren<BackpackController>().AddBlockInInventory(gameObject);
        }
        if(collision.gameObject.tag == "Storage")
        {
            Destroy(gameObject);
        }
    }
}
