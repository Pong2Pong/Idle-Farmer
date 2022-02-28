using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackpackController : MonoBehaviour
{
    [SerializeField] private GameObject coinToSpawn;
    [SerializeField] private float blockSpeed;
    [SerializeField] private TextMeshProUGUI backpackLabel;
    [SerializeField] private TextMeshProUGUI moneyLabel;
    [SerializeField] private float delay;
    public float money;
    public int capacity;
    public int curCapacity;
    public int targetCapacity;
    private float curDelay;
    private Vector3 offset;
    
    void Update()
    {
        
        for(int i = gameObject.transform.childCount-1;i>=0;i--)
        {   
            Transform child = gameObject.transform.GetChild(i);
            if((i%2)>0) offset.z=child.transform.localScale.z*0.75f;
            else offset.z=-child.transform.localScale.z*0.75f;
            if((i%4)>1) offset.x=child.transform.localScale.x*0.75f;
            else offset.x=-child.transform.localScale.x*0.75f;
            offset.y=(i/4) * child.transform.localScale.x*1.5f;
            offset= Quaternion.Euler(0,gameObject.transform.parent.rotation.eulerAngles.y,0) * offset;
            child.GetComponent<Rigidbody>().velocity = (gameObject.transform.position - child.position + offset)*blockSpeed;
        }
    }
    public void AddBlockInInventory(GameObject block)
    {
        curCapacity+=1;
        backpackLabel.text = "Backpack: " + curCapacity + "/" + capacity;
        block.GetComponent<WheatPointController>().isInBackpack = true;
        block.transform.SetParent(gameObject.transform);
        block.GetComponent<BoxCollider>().enabled=false;
        block.transform.localScale = block.transform.localScale/2;
        block.transform.rotation = new Quaternion(0,0,0,0);
        block.transform.position = gameObject.transform.position;
        block.GetComponent<Rigidbody>().freezeRotation = enabled;
    }
    public void changeBackpackText()
    {
        backpackLabel.text = "Backpack: " + curCapacity + "/" + capacity;
    }
    public void changeMoneyText()
    {
        moneyLabel.text = "Money: " + money;
    }
    private void OnTriggerStay(Collider collider) 
    {
        curDelay-=1*Time.deltaTime;
        if((collider.gameObject.tag == "Storage") && (curCapacity>0)&&(curDelay<=0))
        {
            curDelay=delay;
            Transform child = gameObject.transform.GetChild(gameObject.transform.childCount-1);
            child.SetParent(null);
            child.GetComponent<Rigidbody>().AddForce((collider.transform.position-child.position+Vector3.up*5)*50);
            curCapacity-=1;
            targetCapacity-=1;
            changeBackpackText();
            GameObject coin = Instantiate(coinToSpawn,collider.gameObject.transform.position,Quaternion.identity);
        }
    }
}
