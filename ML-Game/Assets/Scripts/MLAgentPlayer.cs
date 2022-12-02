using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class MLAgentPlayer : Agent
{
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RaycastHit2D test;
    [SerializeField] public float jumpForce = 5.0f;
    [SerializeField] public int points;
    [SerializeField] public bool alive = true;
    [SerializeField] public Animator animator;
    [SerializeField] public MLManager MLman;
    [SerializeField] private int reward = 1;

    public override void OnEpisodeBegin()
    {
        reward = 1;
        points = 0;
    }


    public override void OnActionReceived(ActionBuffers actions)
    {

        int jump = actions.DiscreteActions[0];

        rb.velocity = new Vector2(rb.velocity.x, (1 - jump) * (rb.velocity.y));
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce * jump), ForceMode2D.Impulse);


    }




    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Points>(out Points points))
        {
            SetReward(reward);
            this.points++;
            reward++;
            spriteRenderer.material = winMaterial;
            Debug.Log("hit");
        }
        if (collision.TryGetComponent<Wall>(out Wall wall))
        {

            SetReward(-1f);
            MLman.Reset(this.points);
            spriteRenderer.material = loseMaterial;
            EndEpisode();

        }
        if (collision.TryGetComponent<Edge>(out Edge edge))
        {

            SetReward(-1f);
            MLman.Reset(this.points);
            spriteRenderer.material = loseMaterial;
            EndEpisode();

        }
    }

    public void HighScore(int score)
    {

    }
}
