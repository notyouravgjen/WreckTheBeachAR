using System.Collections.Generic;
using UnityEngine;

public class ActivatedTextBubbles : MonoBehaviour
{
    public enum Trigger { OnDamage, OnDestruction }
    public int currText = -1;

    private TextBubble[] allPossibleTexts;
    private Dictionary<Trigger, List<int>> triggerTextMap;

	void Start ()
    {
        EventManager.TookDamageEvent += ChooseVisibleDialog;

        allPossibleTexts = gameObject.GetComponents<TextBubble>();
        triggerTextMap = GenerateTriggerTextMap(allPossibleTexts);
    }

    Dictionary<Trigger, List<int>> GenerateTriggerTextMap(TextBubble[] allPossibleTexts)
    {
        Dictionary<Trigger, List<int>>  result = new Dictionary<Trigger, List<int>>();
        for (int i = 0; i < allPossibleTexts.Length; i++)
        {
            Trigger trigger = allPossibleTexts[i].triggersOn;
            if (!result.ContainsKey(trigger))
            {
                result.Add(trigger, new List<int>());
            }
            result[trigger].Add(i);
        }
        return result;
    }

    void ChooseVisibleDialog(bool wasDestroyed)
    {
        Trigger trigger;
        if (wasDestroyed)
        {
            trigger = Trigger.OnDestruction;
        }
        else
        {
            trigger = Trigger.OnDamage;
        }
        if (!triggerTextMap.ContainsKey(trigger) || triggerTextMap[trigger].Count == 0) {
            return;
        }
        List<int> possibleTexts = triggerTextMap[trigger];
        int mapIndex = Random.Range(0, possibleTexts.Count-1);
        currText = possibleTexts[mapIndex];
    }

    void OnGUI()
    {
        if (currText != -1)
        {
            allPossibleTexts[currText].Display();
        }
    }

    void OnDestroy()
    {
        EventManager.TookDamageEvent -= ChooseVisibleDialog;
        Debug.Log("Cleaned up ActivatedTextBubbles TookDamageEvent");
    }
}
