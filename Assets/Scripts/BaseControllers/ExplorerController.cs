using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplorerController : BaseController {
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
    
    [HideInInspector] public float damageMultCombo;

    public override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        targetPos = transform.position;
        timerRandomIdle = 10f;
        timerShootAnim = 1;
    }

    // Update is called once per frame
    override public void Update() {
        base.Update();
        Movement();
    }

    void Movement() {
        if (moveDirection.sqrMagnitude > 0) {
            //transform.LookAt(transform.position + moveDirection, Vector3.up);
            InputDetected();
        }
        stateTime += Time.deltaTime;
        if (moveDirection == Vector3.zero) {
            Idle();
        }
        if (moveDirection != Vector3.zero) {
            Locomotion();
        }
        anim.SetFloat("ForwardSpeed", navMesh.velocity.magnitude);
        
        currentRT += Time.deltaTime;
        if (currentRT >= timerRandomIdle) {
            anim.SetBool("InputDetected", false);
            anim.SetTrigger("TimeoutToIdle");
        }
        
        if(currentTimerShootAnim < timerShootAnim)
        {
            currentTimerShootAnim += Time.deltaTime;
            anim.SetFloat("TimeToEndShoot", currentTimerShootAnim);
        }
    }

    #region Input
    bool moveInputPressedKeyboard = false;
    bool moveInputPressedController = false;
    public void InputControllerMove(float horizontal, float vertical) {
        if (navMesh.isStopped) {
            moveDirection = Vector3.zero;
            Vector3 d = (vertical * (Vector3.forward + Vector3.right).normalized + horizontal * (-Vector3.forward + Vector3.right).normalized).normalized;
            if (d.sqrMagnitude > 0) 
                transform.rotation = Quaternion.LookRotation(d, Vector3.up);
        } else {
            moveDirection = (vertical * (Vector3.forward + Vector3.right).normalized + horizontal * (-Vector3.forward + Vector3.right).normalized).normalized;
            if (moveDirection.sqrMagnitude > 0.2f) {
                targetPos = transform.position + moveDirection;
                moveInputPressedController = true;
            }
            //else {
            //    if (moveInputPressedController) {
            //        moveInputPressedController = false;
            //        targetPos = transform.position + transform.forward;
            //    }
            //}

        }
        
    }
    public void InputKeyboardMove(float horizontal, float vertical) {
        if (navMesh.isStopped) {
            moveDirection = Vector3.zero;
            //Vector3 d = (vertical * (Vector3.forward + Vector3.right).normalized + horizontal * (-Vector3.forward + Vector3.right).normalized).normalized;
            //if (d.sqrMagnitude > 0) 
            //    transform.rotation = Quaternion.LookRotation(d, Vector3.up);
        } else {
            moveDirection = (vertical * (Vector3.forward + Vector3.right).normalized + horizontal * (-Vector3.forward + Vector3.right).normalized).normalized;
            if (moveDirection.sqrMagnitude > 0.2f) {
                targetPos = transform.position + moveDirection;
                moveInputPressedKeyboard = true;
            }
            // else {
            //    if (moveInputPressedKeyboard) {
            //        moveInputPressedKeyboard = false;
            //        targetPos = transform.position + transform.forward;
            //    }
            //}

        }
        
    }
    void Idle() {
        anim.SetInteger("RandomIdle", Random.Range(0, 3));
        anim.SetFloat("ForwardSpeed", 0);
    }
    public void ClickPressed() {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 100, groundMask)) {
                if (/*(groundMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0 && */(raycastHit.point - transform.position).sqrMagnitude > attackDistance * attackDistance) {
                //if(raycastHit.transform.gameObject.layer == groundMask) {

                targetPos = raycastHit.point;
            }
        }
        InputDetected();
    }
    public void ClickDown() {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 100,groundMask|attackableMask)) {
            if ((raycastHit.point - transform.position).sqrMagnitude <= attackDistance * attackDistance
                //|| (attackableMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0
                        && (raycastHit.point - transform.position).sqrMagnitude <= attackDistance * attackDistance
                ) {
                Attack();
                transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z), Vector3.up);
            }else if ((raycastHit.point - transform.position).sqrMagnitude > attackDistance * attackDistance
                 //&& (attackableMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0
                ) {
                targetPos = raycastHit.point;
            }
        }
    }
    public void RightClick() {
        RaycastHit mouseHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out mouseHit, 100);
        transform.LookAt(new Vector3(mouseHit.point.x, transform.position.y, mouseHit.point.z), Vector3.up);
        
        InputDetected();

        Fire();
    }
    public void Shoot() {
        navMesh.isStopped = true;
        InputDetected();
        Fire();
    }
    public void Attack() {
        targetPos = transform.position;
        anim.SetTrigger("MeleeAttack");
        anim.SetFloat("StateTime", stateTime);
        stateTime = 0;
    }
    void Fire() {

        anim.SetTrigger("ShootAttack");
    }
    void InputDetected() {
        anim.SetBool("InputDetected", true);
        currentRT = 0;
    }

    #endregion
    override public void TakeDamage(float damage, BaseController attacker)
    {
        navMesh.isStopped = false;
        Vector3 forwardPlayer = transform.forward;
        Vector3 positionFromPlayer = (attacker.transform.position - transform.position);
        Vector2 pippo = new Vector2(positionFromPlayer.x, positionFromPlayer.z).normalized;
        Quaternion anglePlayer = Quaternion.FromToRotation(forwardPlayer, pippo);
        pippo = anglePlayer * Vector3.forward;
        base.TakeDamage(damage, attacker);
        if(currentHp > 0)
        {
            anim.SetTrigger("Hurt");
            anim.SetFloat("HurtFromX", pippo.x);
            anim.SetFloat("HurtFromY", pippo.y);
        }
    }

    void Locomotion() {
        anim.SetFloat("ForwardSpeed", speed);
    }
    #region AnimationEvents
    TrailRenderer tr;
    public void MeleeAttackStart(int throwing = 0) {
        if (!tr) tr = gameObject.GetComponentInChildren<TrailRenderer>(true);
        tr.gameObject.SetActive(true);
        weaponArea.damageMult = damageMultCombo * effectDamageMult;
        weaponArea.AttackStart();
    }

    public void MeleeAttackEnd() {
        tr.gameObject.SetActive(false);
        weaponArea.AttackEnd();
    }
    
    public void ShootStart()
    {
        GetComponent<ModSlots>().StrikeAttack(AtachTo.gun);
        navMesh.isStopped = true;
        currentTimerShootAnim = 0;
        Bullet bullet = BulletMgr.instance.GetBullet(bulletType);
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            bullet.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Bullet>().Shoot(this, "Enemy", bulletBaseDamage);
            
        }
    }
    public void ShootEnd() {
        navMesh.isStopped = false;
    }

    override protected void Die()
    {
        mods.RemoveAll();
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("Death");
    }

    private void DeathEvent()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("DeadScene");
    }
    #endregion
}
