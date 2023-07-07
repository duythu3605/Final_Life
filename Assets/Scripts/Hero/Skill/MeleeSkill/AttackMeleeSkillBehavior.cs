using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeSkillBehavior : AbstractSkillBehavior
{
    private const float FORCE = 10.0f;

    private Animator _animator;
    private AttackMeleeSkillSetting _skillSetting;
    private AttackMeleeSkillLevel _skillLevel;
    private GameObject _bullet;


    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _fireDirection;
    [SerializeField] private CharacterTag _targetTag;

    public override void Init(AbstractSkillSetting skillSetting, int levelIndex, float damageHero)
    {
        _skillSetting = (AttackMeleeSkillSetting)skillSetting;
        _skillLevel = new AttackMeleeSkillLevel(_skillSetting, levelIndex);

        _animator = GetComponent<Animator>();
        _bullet = ((AttackMeleeSkillSetting)skillSetting).bullet;
        coolDownTime = _skillLevel.coolDownTime;
        manaExpend = _skillLevel.manaExpend;
    }

    public override void OnNotify(ManaController manaController)
    {
        if (IsCoolDown) return;

        StartCoroutine(StartCoolDown(coolDownTime));

        if (!manaController) return;
        manaController.OnManaDecrease(manaExpend);

        
        var colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, _skillLevel.range, LayerMask.GetMask(_targetTag.ToString()));

        if (colliders != null)
        {
            Collider2D nearestCollider = GetNearestCollider(colliders);
            Aim(nearestCollider);
            Attack();
        }
    }
    private void Attack()
    {
        _animator.Play("Attack");

        BulletBehavior buttletClone = Instantiate(_bullet, _firePoint.position, Quaternion.identity).GetComponent<BulletBehavior>();
        buttletClone.transform.rotation = transform.rotation;
        buttletClone.Init(_skillLevel.damage);
        
    }
    private void Aim(Collider2D target)
    {
        if (target == null) return;

        Vector2 direction = target.transform.position - transform.position;

        transform.rotation = Quaternion.Euler(new Vector3(0, direction.x < 0 ? 180 : 0, 0));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _fireDirection.eulerAngles = new Vector3(0, 0, angle);
    }
    private Collider2D GetNearestCollider(Collider2D[] enemiesCollider)
    {
        float minDistance = float.MaxValue;
        Collider2D nearestEnemyCollider = null;

        foreach (Collider2D enemyCollider in enemiesCollider)
        {
            if (Vector2.Distance(enemyCollider.transform.position, transform.position) < minDistance)
                nearestEnemyCollider = enemyCollider;
        }

        return nearestEnemyCollider;
    }
    
}
