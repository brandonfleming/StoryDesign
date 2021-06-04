using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{

    public string Name;

    public string choiceID;

    public StoryDesign storydesign;

    public bool Decision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        storydesign = GameObject.FindGameObjectWithTag("StoryDesign").GetComponent<StoryDesign>();

    }
}
