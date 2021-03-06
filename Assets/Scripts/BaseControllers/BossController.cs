using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : BaseController {
    // Start is called before the first frame update
    private float stateTime;
    private float timerRandomIdle;
    private float currentRT;
    private float timerShootAnim;
    private float currentTimerShootAnim;
    private Vector3 moveDirection;
    //private CharacterController cc;
    [SerializeField] AttackArea weaponArea;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask attackableMask;
    private Animator anim;
    [SerializeField] protected Transform ellen;
    float invulnerability = 1;
    public override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        targetPos = transform.position;
        timerRandomIdle = 10f;
        timerShootAnim = 1;
    }
    override public void Update() {
        base.Update();
        if (invulnerability > 0) invulnerability -= Time.deltaTime;
        Movement();
        anim.SetBool("InputDetected", true);
    }
    void Movement() {
        targetPos = ellen.position;
        //if (moveDirection.sqrMagnitude > 0) {
        //    //transform.LookAt(transform.position + moveDirection, Vector3.up);
        //    InputDetected();
        //}
        stateTime += Time.deltaTime;
        //if (moveDirection == Vector3.zero) {
        //    Idle();
        //}
        if (moveDirection != Vector3.zero) {
            Locomotion();
        }
        anim.SetFloat("ForwardSpeed", navMesh.velocity.magnitude);

        if ((-transform.position + ellen.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("MeleeAttack");
        }
        //currentRT += Time.deltaTime;
        //if (currentRT >= timerRandomIdle) {
        //    anim.SetBool("InputDetected", false);
        //    anim.SetTrigger("TimeoutToIdle");
        //}

        //if (currentTimerShootAnim < timerShootAnim) {
        //    currentTimerShootAnim += Time.deltaTime;
        //    anim.SetFloat("TimeToEndShoot", currentTimerShootAnim);
        //}
    }
    void Locomotion() {
        anim.SetFloat("ForwardSpeed", speed);
    }
    TrailRenderer tr;
    public void MeleeAttackStart(int throwing = 0) {
        if (!tr) tr = gameObject.GetComponentInChildren<TrailRenderer>(true);
        tr.gameObject.SetActive(true);
        transform.LookAt(ellen);
        weaponArea.damageMult = effectDamageMult;
        weaponArea.AttackStart();
    }
    public void MeleeAttackEnd() {
        tr.gameObject.SetActive(false);
        weaponArea.AttackEnd();
    }
    override public void TakeDamage(float damage, BaseController attacker) {
        if (invulnerability > 0) return;
        invulnerability = 0.5f;
        if (currentHp <= 0) return;
        navMesh.isStopped = false;
        Vector3 forwardPlayer = transform.forward;
        Vector3 positionFromPlayer = (attacker.transform.position - transform.position);
        Vector2 pippo = new Vector2(positionFromPlayer.x, positionFromPlayer.z).normalized;
        Quaternion anglePlayer = Quaternion.FromToRotation(forwardPlayer, pippo);
        pippo = anglePlayer * Vector3.forward;
        base.TakeDamage(damage, attacker);
        if (currentHp > 0) {
            anim.SetTrigger("Hurt");
            anim.SetFloat("HurtFromX", pippo.x);
            anim.SetFloat("HurtFromY", pippo.y);
        }
        if(currentHp <= 0) {
            Die();
        }
    }
    override protected void Die() {
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("Death");
    }

    private void DeathEvent() {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("FinalScene");
    }
}
