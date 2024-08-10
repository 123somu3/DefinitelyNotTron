using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxCollection : MonoBehaviour
{
  

    private int Box = 0;
    public TextMeshProUGUI BoxText;

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Box")
        {
            Box++;
            BoxText.text = "Box:" + Box.ToString();
            Debug.Log(Box);
            Destroy(other.gameObject);  
        }
    }
}
