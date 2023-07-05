using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeThirdSkillBehavior : AbstractSkillBehavior
{
    private const float FORCE = 10.0f;
    private Animator _animator;
    private AttackMeleeSkillSetting _skillSetting;
    private AttackMeleeSkillLevel _skillLevel;
    private GameObject _bullet;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _fireDirection;
    [SerializeField] private CharacterTag _targetTag;

    private float _damageHero;

    public override void Init(AbstractSkillSetting attackMeleeSkillSetting, int levelIndex, float damageHero)
    {
        _skillSetting = (AttackMeleeSkillSetting)attackMeleeSkillSetting;
        _skillLevel = new AttackMeleeSkillLevel(_skillSetting, levelIndex);
        _bullet = ((AttackMeleeSkillSetting)attackMeleeSkillSetting).bullet;
        _animator = GetComponent<Animator>();
        manaExpend = _skillLevel.manaExpend;
        coolDownTime = _skillLevel.coolDownTime; 
        _damageHero = damageHero;
    }

    public override void OnNotify(ManaController manaController)
    {
        if (manaController.CurrentMana < manaExpend)
        {
            Debug.Log("khong du mana");
            return;
        }
        if (IsCoolDown) return;
        StartCoroutine(StartCoolDown(coolDownTime));        
        manaController.OnManaDecrease(manaExpend);
        Attack();
    }

    private void Attack()
    {
        _animator.Play("Attack_Special");

        Collider2D collider = Physics2D.OverlapCircle(transform.position, _skillLevel.range);
        Vector2 direction = _firePoint.right;
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("Seen");
            direction = collider.transform.position - _firePoint.position;
        }

        ThirdSkillKnightBulletBehavior buttletClone = Instantiate(_bullet, _firePoint.position, Quaternion.identity).GetComponent<ThirdSkillKnightBulletBehavior>();
        
        buttletClone.Init(_skillLevel.damage + _damageHero);
        buttletClone.GetComponent<Rigidbody2D>().AddForce(direction.normalized * FORCE, ForceMode2D.Impulse);
    }

}
