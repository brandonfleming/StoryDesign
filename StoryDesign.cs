using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDesign : MonoBehaviour
{
    [Header("StoryDesign v0.4a")]
    [Header("By Biohazard Studio")]

    [Header("StoryDesign Database")]
    public bool[] choice_bool_values;
    public string[] choice_string_values;
    [Header("Choices")]
    public Choice[] choices;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        DontDestroyOnLoad(this);

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
