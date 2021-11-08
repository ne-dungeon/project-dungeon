using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private ObjectAnimation objectAnimation;
    // Start is called before the first frame update
    void Start()
    {
        objectAnimation = GetComponent<ObjectAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Break()
    {
        objectAnimation.Break();
        StartCoroutine(DisableOnBreak()); 
    }

    IEnumerator DisableOnBreak()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
