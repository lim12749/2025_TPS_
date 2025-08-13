using Unity.XR.OpenVR;
using UnityEngine;

public class Monster : MonsterBase 
{
    private Animator _animator; 
    public override void Start()
    {
        base.Start(); //부모꺼 실행
        _animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
    }

    public override void Die()
    {
        base.Die();
        _animator.SetTrigger("Die"); // 사망 애니메이션 트리거 설정
    }
}
