using UnityEngine;

public abstract class MonsterBase : MonoBehaviour, IDamageable
{
    public float health = 0;
    public AudioSource _audio;
    public AudioClip _audioClip;
    public virtual void Start()
    {
        health = 50f; // 초기 체력 설정
    }
    public virtual void TakeDamage(int _damage)
    {
        health -= _damage;// 받은데미지로 감소
        Debug.Log($"몬스터 피격 남은 체력 : {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        _audio.PlayOneShot(_audioClip);
        Debug.Log("몬스터 사망");
        Destroy(gameObject, 3f);
    }
}
