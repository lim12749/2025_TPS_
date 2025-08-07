using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
public abstract class BaseMonster : MonoBehaviour
{
    [Header("공용스테ㅅ")]
    public int MAXHP = 100; //최대 hp
    protected int currnetHP; //현재 hp;
    public float attackRange = 2f; //공격 범위 
    public float attackCooldown = 1f; //공ㄱㅕㄱ 속도 
    protected float lastAttackTime;

    [Header("AI 기능 추가")]
    public NavMeshAgent agent;
    public Transform target; //내가 가야하느ㄴ 목ㅍㅛ 

    protected virtual void Awake() //추상화 
    {
        agent = GetComponent<NavMeshAgent>();
        currnetHP = MAXHP; //hp 초기화 
    }
    protected virtual void Update()
    {
        if (target == null) return; //내가 추적할 대상이 없으면 함수를 실행하지 않음
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance >= attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position); //이게 움직이게하는 코드
        }
        else
        {
            if(Time.time > lastAttackTime +attackCooldown)
            {
                lastAttackTime = Time.time;
                Attack(); 
            }
        }
    }
    public virtual void TakeDamage(int _damage) //외부에서 함수를 호출하기위해 public
    {
        currnetHP -= _damage; // currnetHP = currentHP-_damge;
        Debug.Log($"{gameObject.name}이 피해를 입음: {_damage}"); //출력
        if (currnetHP <= 0)
        {
            Die(); //죽음 함수 호출
        }
    }
    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} 사망");
        Destroy(this.gameObject, 2); //2초뒤에 오브젝트 삭제
    }

    protected abstract void Attack();
}
