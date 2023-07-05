using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttackSkillBehavior : AbstractSkillBehavior
{
    private const float FORCE = 10.0f;

    private Animator _animator;
    private AttackRangeSkillLevel _skillLevel;
    private GameObject _bullet;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _fireDirection;
    [SerializeField] private CharacterTag _targetTag;

    public override void Init(AbstractSkillSetting attackRangeSkillSetting, int levelIndex, float damage)
    {
        _animator = GetComponent<Animator>();
        _skillLevel = new AttackRangeSkillLevel((AttackRangeSkillSetting)attackRangeSkillSetting, levelIndex);

        _bullet = ((AttackRangeSkillSetting)attackRangeSkillSetting).bullet;
        coolDownTime = _skillLevel.coolDownTime;
    }

    public override void OnNotify(ManaController manaController)
    {
        if (IsCoolDown) return;

        StartCoroutine(StartCoolDown(coolDownTime));

        manaController?.OnManaDecrease(_skillLevel.manaExpend);

        Attack();
    }

    private void Attack()
    {
        _animator.Play("Attack");

        Collider2D collider = Physics2D.OverlapCircle(transform.position, _skillLevel.range);
        Vector2 direction = -_firePoint.right;
        if (collider.CompareTag("Hero"))
        {
            direction = collider.transform.position - _firePoint.position;
        }

        SnakeBulletBehavior buttletClone = Instantiate(_bullet, _firePoint.position, Quaternion.identity).GetComponent<SnakeBulletBehavior>();

        buttletClone.Init(_skillLevel.damage);
        buttletClone.GetComponent<Rigidbody2D>().AddForce(direction.normalized * FORCE, ForceMode2D.Impulse);
    }


}
