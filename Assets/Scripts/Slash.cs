using UnityEngine;

public class Slash : MonoBehaviour
{
    //공격시 애니메이션
    //공격시 파티클 재생
    public Animator anim; //애니메이션 사용을 위한 
    public GameObject Effect; //슬레쉬 이펙트 프리팹
    public Transform EffectSpawnPoint; //이펙트 생성위치
    public float Delay = 0.5f;
    private void Update()
    {
        //게임중에 사용하는 모든것 정의
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //스페이스바 한번 눌렸을때 
            anim.SetTrigger("Attack");
            Invoke(nameof(SpawnSlashEffect), Delay); //함수 실행
        }    
    }
    void SpawnSlashEffect()
    {
        //회전축 
        Quaternion slashRot = Quaternion.LookRotation(EffectSpawnPoint.forward); //z축방향으로 바라보는 회전각을 만들고

        GameObject effect = Instantiate(Effect, EffectSpawnPoint.position, slashRot);

        Destroy(effect, 2f); //이펙트가 2초뒤에 사라지게 하기
    }    
}
