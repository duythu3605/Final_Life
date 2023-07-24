using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItemQuest : QuestStep
{
    private int ItemsCollected = 0;
    private int ItemsToComplete = 10;

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onItemCollected += ItemCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onItemCollected -= ItemCollected;
    }

    private void ItemCollected()
    {
        if (ItemsCollected < ItemsToComplete)
        {
            ItemsCollected++;
            UpdateState();
        }

        if (ItemsCollected >= ItemsToComplete)
        {
            FinishQuestStep();
        }
    }

    private void UpdateState()
    {
        string state = ItemsCollected.ToString();
        ChangeState(state);
    }

    protected override void SetQuestStepState(string state)
    {
        this.ItemsCollected = System.Int32.Parse(state);
        UpdateState();
    }
}
