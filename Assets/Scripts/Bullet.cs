using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; //시간되면 삭제
    public int damage = 10;
    public AudioClip AudioClip; //소리원본
    public AudioSource AudioSource; //재생
    public GameObject impactPrefab; //충돌지점에 나타나는 파티클
    void Start()
    {
        Destroy(gameObject, lifeTime); //3초 뒤에 삭제
    }
    void OnCollisionEnter(Collision other)
    {
        //최신 TryGet으로 out으로 매개변수로 전달
        if (other.collider.TryGetComponent<IDamageable>(out var monster))
        {
            monster.TakeDamage(damage);
        }
        //충돌지점
        var contact = other.contacts[0]; //첫번째 충돌지점을 contact에 저장
        Vector3 hitpoint = contact.point; // 포인트
        Vector3 hitNoraml = contact.normal; //면
        //이펙트 생성
        GameObject impact = Instantiate(impactPrefab, hitpoint, Quaternion.LookRotation(hitNoraml));
        Destroy(impact,1.5f);

        AudioSource.PlayClipAtPoint(AudioClip, transform.position); //총알포지션으로 사운드 재생

        Destroy(gameObject); //충돌하면 삭제
        //여기에 충돌 피격 효과 이펙트도 추가
        
    }
}
