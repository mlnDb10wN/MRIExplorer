using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Query;

public class ImageManager : MonoBehaviour
{
    public GameObject currentImage;
    public GameObject nextImage;
    public List<Texture> images;
    public Leap.Unity.LeapServiceProvider leapMotionService;
    public List<Leap.Hand> hands;
    // Start is called before the first frame update
    void Start()
    {
        currentImage.GetComponent<MeshRenderer>().material.mainTexture = images[0];
    }


    // Update is called once per frame
    void Update()
    {
        hands = leapMotionService.CurrentFrame.Hands;
        foreach (Leap.Hand h in hands) {
            if (h.IsLeft) {
                currentImage.GetComponent<MeshRenderer>().material.mainTexture = images[(int)(h.GrabStrength * (images.Count-1))];
                //Camera.main.orthographicSize = Mathf.Clamp(Mathf.Sin(Mathf.Clamp01(h.PalmPosition.y)) * 10, 3, 10);
            }
            if (h.IsRight)
            {
                //currentImage.GetComponent<MeshRenderer>().material.color = new Color(h.GrabStrength, 1 - h.GrabStrength, currentImage.GetComponent<MeshRenderer>().material.color.b);
                //currentImage.transform.eulerAngles = new Vector3 (0,Mathf.Clamp01(h.PalmPosition.y) * 360, 0);
            }  
        }
        //currentImage.GetComponent<MeshRenderer>().material.color = new Color(currentImage.GetComponent<MeshRenderer>().material.color.r, currentImage.GetComponent<MeshRenderer>().material.color.g, Mathf.Sin(Time.time * 1));
        if (Input.GetKeyDown(KeyCode.W))
        {   //Move Up 
            if(images.IndexOf(currentImage.GetComponent<MeshRenderer>().material.mainTexture) + 1 < images.Count)
                currentImage.GetComponent<MeshRenderer>().material.mainTexture = images[images.IndexOf(currentImage.GetComponent<MeshRenderer>().material.mainTexture) + 1];
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //Move Down
            if (images.IndexOf(currentImage.GetComponent<MeshRenderer>().material.mainTexture) - 1 >= 0)
                currentImage.GetComponent<MeshRenderer>().material.mainTexture = images[images.IndexOf(currentImage.GetComponent<MeshRenderer>().material.mainTexture) - 1];
        }


       
    }
}
