using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractSkillBehavior : MonoBehaviour, IObserver<ManaController>
{
    public bool IsCoolDown { get; private set; }

    [HideInInspector]
    public float coolDownTime;

    public abstract void Init(AbstractSkillSetting skillSetting, int levelIndex);

    public abstract void OnNotify(ManaController data);

    protected IEnumerator StartCoolDown(float coolDownTime)
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(coolDownTime);
        IsCoolDown = false;
    }
}
