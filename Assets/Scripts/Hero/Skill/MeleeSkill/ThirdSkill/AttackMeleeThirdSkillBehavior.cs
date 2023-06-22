using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeThirdSkillBehavior : AbstractSkillBehavior
{
    private Animator _animator;
    private AttackMeleeSkillSetting _skillSetting;
    private AttackMeleeSkillLevel _skillLevel;

    [SerializeField] private Transform _firePoint;

    public override void Init(AbstractSkillSetting attackMeleeSkillSetting, int levelIndex)
    {
        _skillSetting = (AttackMeleeSkillSetting)attackMeleeSkillSetting;
        _skillLevel = new AttackMeleeSkillLevel(_skillSetting, levelIndex);

        _animator = GetComponent<Animator>();
        coolDownTime = _skillLevel.coolDownTime;
    }

    public override void OnNotify(ManaController manaController)
    {
        if (IsCoolDown) return;
        StartCoroutine(StartCoolDown(coolDownTime));

        if (!manaController) return;
        manaController.OnManaDecrease(_skillLevel.manaExpend);

        _animator.Play("Attack_Special");
    }

    public void TakeDamage()
    {
        Collider2D collider = Physics2D.OverlapCircle(_firePoint.position, _skillLevel.range);

        if (collider == null) return;

        collider.GetComponent<HealthController>()?.OnHealthDecrease(_skillLevel.damage);
    }
}
