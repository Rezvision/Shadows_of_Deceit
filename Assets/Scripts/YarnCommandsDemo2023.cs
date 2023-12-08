using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class YarnCommandsDemo2023 : MonoBehaviour
{
    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public GameObject[] NPCGameObjects;

    public GameObject knifePrefab;
    Vector3 newPosition = new Vector3(2f, 1f, 1f);

    public Material blue, red, orange;


    // Start is called before the first frame update
    void Start()
    {
        yarnInMemoryVariableStorage.SetValue("$numberOfNPCs", NPCGameObjects.Length);
        Debug.Log(NPCGameObjects.Length);
    }


    [YarnCommand("change_cube_colour")]
    public void ChangeCubeColour()
    {
        string cubeToChange;
        yarnInMemoryVariableStorage.TryGetValue("$cubeToChange", out cubeToChange);

        string colourToChangeTo;
        yarnInMemoryVariableStorage.TryGetValue("$colourOfCube", out colourToChangeTo);

        Debug.Log("Changing " + cubeToChange + " to " + colourToChangeTo);

        if(cubeToChange == "1")
        {
            if (colourToChangeTo == "Blue")
            {
                NPCGameObjects[0].GetComponent<MeshRenderer>().material = blue;
            }

            if (colourToChangeTo == "Red")
            {
                NPCGameObjects[0].GetComponent<MeshRenderer>().material = red;
            }

            if (colourToChangeTo == "Orange")
            {
                NPCGameObjects[0].GetComponent<MeshRenderer>().material = orange;
            }
        }

        if(cubeToChange == "2")
        {
            if (colourToChangeTo == "Blue")
            {
                NPCGameObjects[1].GetComponent<MeshRenderer>().material = blue;
            }

            if (colourToChangeTo == "Red")
            {
                NPCGameObjects[1].GetComponent<MeshRenderer>().material = red;
            }

            if (colourToChangeTo == "Orange")
            {
                NPCGameObjects[1].GetComponent<MeshRenderer>().material = orange;
            }
        }
    }
    
    [YarnCommand("apear_knife")]
    public void ApearKnife() 
    {
        bool foundEvidence;
        yarnInMemoryVariableStorage.TryGetValue("$foundevidence", out foundEvidence);
        if (foundEvidence) // no need to say true
        {
            Debug.Log("knife should apear");
            Instantiate( knifePrefab, newPosition, Quaternion.Euler(150f, 0f, 0f));
        }
    }


}
