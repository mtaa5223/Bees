using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCQuestDialogueScript : MonoBehaviour
{
    [SerializeField] private GameObject honeyBases;
    [SerializeField] private GameObject honeyOut;
    [SerializeField] private GameObject flowerBoxs;

    private void Update()
    {
        if (DialogueLua.GetQuestField("Collect_Honey_From_Flowers", "State").asString == "active")
        {
            foreach (Transform honeyBase in honeyBases.transform)
            {
                foreach (Transform honeyPlate in honeyBase.GetChild(3))
                {
                    Debug.Log(honeyPlate.gameObject.name);
                    if (honeyPlate.GetComponent<HoneyPlate>() != null)
                    {
                        if (honeyPlate.GetComponent<HoneyPlate>().CurrentHoney > 0)
                        {
                            DialogueLua.SetQuestField("Collect_Honey_From_Flowers", "State", "success");
                            return;
                        }
                    }
                }
            }
        }
        else if (DialogueLua.GetQuestField("Use_HoneyOut", "State").asString == "active")
        {
            if (honeyOut.GetComponent<HoneyOut>().CurrentBigHoney > 0)
            {
                DialogueLua.SetQuestField("Use_HoneyOut", "State", "success");
            }
        }
        else if (DialogueLua.GetQuestField("Plant_Flowers", "State").asString == "active")
        {
            foreach (Transform flowerBox in flowerBoxs.transform)
            {
                foreach (Transform seedArea in flowerBox)
                {
                    if (seedArea.GetComponent<SetArea>() != null)
                    {
                        if (seedArea.GetComponent<SetArea>().inputObject != null)
                        {
                            DialogueLua.SetQuestField("Plant_Flowers", "State", "success");
                            return;
                        }
                    }
                }
            }
        }
        else if (DialogueLua.GetQuestField("Water_The_Flowers", "State").asString == "active")
        {
            foreach (Transform flowerBox in flowerBoxs.transform)
            {
                foreach (Transform seedArea in flowerBox)
                {
                    if (seedArea.GetComponent<SetArea>() != null)
                    {
                        if (seedArea.GetComponent<SetArea>().inputObject != null)
                        {
                            if (seedArea.GetComponent<SetArea>().inputObject.GetComponent<FlowerDataScript>().FlowerGrade >= 4)
                            {
                                DialogueLua.SetQuestField("Water_The_Flowers", "State", "success");
                                return;
                            }
                        }
                    }
                }
            }
        }
        else if (DialogueLua.GetQuestField("More_Flower", "State").asString == "active")
        {
            int flowerCount = 0;
            foreach (Transform flowerBox in flowerBoxs.transform)
            {
                foreach (Transform seedArea in flowerBox)
                {
                    if (seedArea.GetComponent<SetArea>() != null)
                    {
                        if (seedArea.GetComponent<SetArea>().inputObject != null)
                        {
                            if (seedArea.GetComponent<SetArea>().inputObject.GetComponent<FlowerDataScript>().FlowerGrade >= 4)
                            {
                                flowerCount++;
                            }
                        }
                    }
                }
            }
            DialogueLua.SetVariable("FlowerCount", flowerCount);
            if (flowerCount >= 3)
            {
                DialogueLua.SetQuestField("More_Flower", "State", "success");
            }
        }
    }
}