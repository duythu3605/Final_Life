using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkillBehavior : AbstractSkillBehavior
{
    private Animator _animator;
    private BuffSkillSetting _skillSetting;
    private BuffSkillLevel _skillLevel;

    [SerializeField] private Transform _firePoint;

    public override void Init(AbstractSkillSetting skillSetting, int levelIndex)
    {
        _skillSetting = (BuffSkillSetting)skillSetting;
        _skillLevel = new BuffSkillLevel(_skillSetting, levelIndex);

        _animator = GetComponent<Animator>();
        coolDownTime = _skillLevel.coolDownTime;
    }

    public override void OnNotify(ManaController manaController)
    {
        if (manaController.CurrentMana < _skillLevel.manaExpend)
        {
            Debug.Log("khong du mana");
            return;
        }
        if (IsCoolDown) return;

        StartCoroutine(StartCoolDown(coolDownTime));

        
        manaController.OnManaDecrease(_skillLevel.manaExpend);

        _animator.Play("Jump");
    }

    public void TakeDamage()
    {
        Collider2D collider = Physics2D.OverlapCircle(_firePoint.position, _skillLevel.range);

        if (collider == null) return;

        collider.GetComponent<HealthController>()?.OnHealthDecrease(_skillLevel.damage);
    }
}
