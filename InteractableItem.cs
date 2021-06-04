using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour
{

    public string ItemName;
    public string Description;

    public bool InvokesDialogue;

    [Header("Does this item require past choices?")]
    public bool RequiresPastDecisions;

    [Header("Item ONLY invokes dialogue")]
    public bool MiscItem;

    [TextArea]
    public string Item_Text;

    public string[] Character_Response;

    public Text DialogueUI;

    [Header("StoryDesign Database")]
    public StoryDesign choiceDatabase;

    [Tooltip("Enable this only if RequiresPastDecisions is ON.")]
    [Header("Involved Choices")]
    public int InvolvedChoices1;
    public int InvolvedChoices2;

    [Header("The required decisions")]
    public bool InvolvedChoices1_bool;
    public bool InvolvedChoices2_bool;

    private int responsearraynum;
    private bool hasalreadyinteracted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (this.GetComponent<Choice>() == true && RequiresPastDecisions == true)
        {
            choiceDatabase = GameObject.FindGameObjectWithTag("StoryDesign").GetComponent<StoryDesign>();
        } else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }

    private void OnTriggerEnter(Collider other)
    {

        if (hasalreadyinteracted == false)
        {
            // IF THE PLAYER HAS ALREADY INTERACTED WITH ITEM
            hasalreadyinteracted = true;

            // Sets decision on Choice
            if (other.tag == "Player" && MiscItem == false)
            {
                this.GetComponent<Choice>().Decision = true;
            }

            //If the item does not effect any decisions or actions

            if (MiscItem == true)
            {
                responsearraynum = 0;
                StartCoroutine(DisplayText());
            }

            if (RequiresPastDecisions == true)
            {

                //BOTH CHOICES WERE MET
                if (choiceDatabase.choices[InvolvedChoices1].Decision == InvolvedChoices1_bool && choiceDatabase.choices[InvolvedChoices2].Decision == InvolvedChoices2_bool && InvokesDialogue == true)
                {
                    Debug.Log(ItemName + " has met decision requirements");
                    responsearraynum = 0;
                    StartCoroutine(DisplayText());
                }
                else
                {
                    //ONE OR NONE CHOICES WERE MET
                    Debug.Log(ItemName + " decision requirements not met, defaulting to standard dialouge");
                    responsearraynum = 1;
                    StartCoroutine(DisplayText());
                }

            }

            // DOES NOT REQUIRE CHOICES OR PREVIOUS DECISIONS
            if (RequiresPastDecisions == false && InvokesDialogue == true)
            {
                Debug.Log(ItemName + " has been interacted with by Player");
                responsearraynum = 0;
                StartCoroutine(DisplayText());
            }

        } else
        {
            //PLAYER HAS ALREADY SEEN THE ITEM
            Debug.Log("Player has already seen " + ItemName);
            Character_Response[0] = "I've already seen this";
            StartCoroutine(DisplayText());
        }

    }

    IEnumerator DisplayText ()
    {
        DialogueUI.text = Character_Response[responsearraynum];
        yield return new WaitForSeconds(5f);
        DialogueUI.text = null;
    }

}
