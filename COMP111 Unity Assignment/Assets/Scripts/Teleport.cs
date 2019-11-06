using UnityEngine;

public class Teleport : MonoBehaviour
{
    public LayerMask layerMask = -1;
    public float delay = 3f;
    public Vector3 teleportLocation = new Vector3();
    public GameObject endParticles;

    private ParticleSystem particles;
    private Collider toTeleport;
    private float timer = 0f;

    void Start()
    {
        this.particles = GetComponent<ParticleSystem>();
        this.particles.Stop();
    }

    void FixedUpdate()
    {
        if(this.toTeleport != null) {
            this.timer += Time.fixedDeltaTime;
            if(this.timer >= this.delay) {
                this.toTeleport.transform.position = this.teleportLocation;
                GameObject part = Instantiate(endParticles, this.toTeleport.transform) as GameObject;
                Destroy(part, 15f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(InMask(other)) {
            this.toTeleport = other;
            this.particles.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.timer = 0f;
        this.toTeleport = null;
        this.particles.Stop();
    }

    private bool InMask(Collider collider)
    {
        return ((layerMask.value & (1 << collider.gameObject.layer)) > 0);
    }

}
