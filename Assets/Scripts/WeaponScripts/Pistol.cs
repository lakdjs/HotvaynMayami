public class Pistol : AWepon
{
    public override void Fire()
    {
        throw new System.NotImplementedException();
    }
    private void Update()
    {
        Destroy(gameObject, 10);
    }
}
