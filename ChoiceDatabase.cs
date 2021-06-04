using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChoiceDatabase : MonoBehaviour
{


    [Header("StoryDesign Database")]
    public bool[] choice_bool_values;
    public string[] choice_string_values;
    [Header("Choices")]
    public Choice[] choices;

    //Each choice has a 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < choices.Length; i++)
        {
            if (choices[i] != null)
            {
                choice_bool_values[i] = choices[i].Decision;
                choice_string_values[i] = choices[i].Name;

            }
        }
    }
}