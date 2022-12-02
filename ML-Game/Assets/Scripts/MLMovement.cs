using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class MLMovement : Agent
{

    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RaycastHit2D test;
    int reward = 1;
    public float jumpForce = 15f;

    public override void OnEpisodeBegin()
    {
        reward = 1;
        transform.localPosition = new Vector2(-5, 2);
        rb.velocity = new Vector2(0, 0);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {

        int jump = actions.DiscreteActions[0];
        
        rb.velocity = new Vector2(rb.velocity.x, (1-jump)*(rb.velocity.y));
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce*jump), ForceMode2D.Impulse);

/*        float moveZ = actions.ContinuousActions[0];
        float moveSpeed = 15f;
        transform.Translate(new Vector2(0, moveZ) * Time.deltaTime * moveSpeed);*/
    }




    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        /*        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
                continuousActions[0] = Input.GetAxisRaw("Vertical");*/
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Points>(out Points points))
        {
            SetReward(reward);
            reward++;
            spriteRenderer.material = winMaterial;
            Debug.Log("hit");
        }
        if (collision.TryGetComponent<Wall>(out Wall wall))
        {

            SetReward(-1f);
            spriteRenderer.material = loseMaterial;
            EndEpisode();

        }
        if (collision.TryGetComponent<Edge>(out Edge edge))
        {

            SetReward(-5f);
            spriteRenderer.material = loseMaterial;
            EndEpisode();

        }
    }

}
