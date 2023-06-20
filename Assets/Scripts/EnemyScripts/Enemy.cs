using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Patrol,
        ChasingPlayer,
        GoingToLastPos
    }
    [SerializeField] private AWepon.Weapons _weaponType;
    [SerializeField] private float _hp;
    [SerializeField] private int _defense;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private EnemyType _type;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] Sprite[] _sprites;
    private GameObject _player;
    [SerializeField] private Rigidbody2D rb;
    private bool _clockWise, _moving, _guard;
    Vector3 target;
    private Vector3 _playerLastPos;
    RaycastHit2D hit;
    int LayerMask = 1 << 6;
    private int _weaponID;
    private Transform check;
    private bool _shooting;
    private Collider2D _col;
    private void Start()
    {
        _player = FindAnyObjectByType<PlayerWeaponController>().gameObject;
        _moving = true;
        switch (_weaponType)
        {
            case AWepon.Weapons.Knife:
                _weaponID = 0;
                break;
            case AWepon.Weapons.Pistol:
                _weaponID = 1;
                break;
            case AWepon.Weapons.Rifle:
                _weaponID = 2;
                break;     
        }
       // _sr.sprite = _sprites[_weaponID];
        _playerLastPos = this.transform.position;
        LayerMask = ~LayerMask;
    }
    void Update()
    {
        Movement();
        PlayerDetect();
        Debug.Log($"{gameObject.name} {_guard}");
        Debug.Log($"{gameObject.name} {hit.transform.gameObject.layer}");
        
        if (_hp <= 0)
        {
            Debug.Log("вы умерли");
            Destroy(gameObject);
            Instantiate(Resources.Load("Prefabs/Items/" + _weaponType), transform.position, Quaternion.identity);
        }
        if (_col is not null)
        {
            if(_col.tag == "FirePoint")
            {
                _hp -= _player.GetComponent<Knife>().Damage;
            }
            else
            {
                _hp -= _col.GetComponent<Bullet>().Damage;
                Destroy(_col.gameObject);
            }      
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>()||collision.tag == "FirePoint")
        {
            _col = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _col = null;
    }
    void Movement()
    {
        float dist = Vector3.Distance(_player.transform.position, this.transform.position);
        Vector3 dir = _player.transform.position - transform.position;
        hit = Physics2D.Raycast(new Vector2(this.transform.position.x,this.transform.position.y),new Vector2(dir.x,dir.y),dist,LayerMask);
        Debug.DrawRay(transform.position, dir, Color.red);

        Vector3 fwt = this.transform.TransformDirection(Vector3.right);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(this.transform.position.x,this.transform.position.y),new Vector2(fwt.x,fwt.y),1.0f,LayerMask);
        Debug.DrawRay(new Vector2(this.transform.position.x,this.transform.position.y),new Vector2(fwt.x,fwt.y),Color.cyan);

        if(_moving)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        if(_type == EnemyType.Patrol)
        {
            _speed = 3f;
            if(hit2.collider != null)
            {
                if(hit2.collider.gameObject.layer == 3)
                {
                    if(!_clockWise)
                    {
                        transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        transform.Rotate(0,0,-90);
                    }
                }
            }
        }
        if(_type == EnemyType.ChasingPlayer && !(_player.GetComponent<PlayerStats>().HP <= 0))
        {
            _speed = 9f;
            rb.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((_playerLastPos.y - transform.position.y),(_playerLastPos.x - transform.position.x))*Mathf.Rad2Deg);
            
            if(hit.transform.gameObject.layer == 7)
            {
                _playerLastPos = _player.transform.position;
                if(_weaponType == AWepon.Weapons.Pistol||_weaponType == AWepon.Weapons.Rifle)
                {
                    if(Vector3.Distance(transform.position,_player.transform.position) <= 6f)
                    {
                        _moving = false;
                        switch (_weaponType)
                        {
                            case AWepon.Weapons.Pistol:
                                Shoot(0.5f);
                                break;
                            case AWepon.Weapons.Rifle:
                                Shoot(0.1f);
                                break;
                        }
                    }
                  else
                  {
                      if(!_guard)
                      {
                          _moving = true;
                      }
                  }
                }
                if(_weaponType == AWepon.Weapons.Knife)
                {

                }
            }
            else
            {
                _moving = true;
            }
        }
        if(_type == EnemyType.GoingToLastPos)
        {
            _speed = 8f;
            rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((_playerLastPos.y - transform.position.y), (_playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg);
            if(Vector3.Distance(this.transform.position,_playerLastPos) < 1.5f)
            {
                _type = EnemyType.Patrol;
                _moving = true;
            }
        }
    }
    void PlayerDetect()
    {
        Vector3 pos = this.transform.InverseTransformPoint(_player.transform.position);
        if(hit.collider != null)
        {
            if(hit.transform.gameObject.layer == 7 && pos.x > 1.2f && Vector3.Distance(this.transform.position,_player.transform.position)<8f)
            {
                _type = EnemyType.ChasingPlayer;
            }
            else
            {
                if(_type == EnemyType.ChasingPlayer)
                {
                    _type = EnemyType.GoingToLastPos;
                }
            }
        }
    }
    void Shoot(float time)
    {
        if(!_shooting)
        {
            StartCoroutine("attackShoot", time);
        }
    }
    IEnumerator attackShoot(float time)
    {
        _shooting = true;
        Instantiate(Resources.Load("Prefabs/Items/" + _weaponType.ToString() + "_Bullet"), _firePoint.position, _firePoint.rotation);

        yield return new WaitForSeconds(time);
        _shooting = false;
    }
    private void OnMouseOver()
    {
        
    }
    private void OnMouseExit()
    {
        
    }
}
