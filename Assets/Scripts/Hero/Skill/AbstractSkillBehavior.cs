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
    [HideInInspector]
    public float manaExpend;


    public abstract void Init(AbstractSkillSetting skillSetting, int levelIndex, float damage);

    public abstract void OnNotify(ManaController data);

    protected IEnumerator StartCoolDown(float coolDownTime)
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(coolDownTime);
        IsCoolDown = false;
    }
}
