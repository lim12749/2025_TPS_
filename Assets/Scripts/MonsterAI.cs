using UnityEngine;
using UnityEngine.AI; //네비게이션 AI기능을 사용하기위해 참조

public class MonsterAI : MonoBehaviour
{
    public Transform target; //기능
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //자기자신 기능 가져오기
    }

    private void Update()
    {
        if (target == null) return; //내가 추적할 대상이 없으면 함수를 실행하지 않음
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 2)
        {
            agent.isStopped = true;
            Debug.Log("공격 중 ...");
        }
        else
        {
            agent.isStopped= false;
            agent.SetDestination(target.position); //이게 움직이게하는 코드
        }
        
    }
}
