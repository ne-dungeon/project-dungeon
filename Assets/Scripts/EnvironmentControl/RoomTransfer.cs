using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraChangeMin;
    public Vector2 cameraChangeMax;
    public Vector3 playerChange;

    private CameraMovement cameraMovement;

    public bool needPlaceCard;
    public string placeName;
    public GameObject textDisplay;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D enteree)
    {
        if (enteree.CompareTag("Player"))
        {
            cameraMovement.minPosition += cameraChangeMin;
            cameraMovement.maxPosition += cameraChangeMax;

            enteree.transform.position += playerChange;
            if (needPlaceCard)
            {
                StartCoroutine(activatePlaceCard());
            }
        }

    }

    private IEnumerator activatePlaceCard(){
        textDisplay.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(3f);

        textDisplay.SetActive(false);
    }
}
