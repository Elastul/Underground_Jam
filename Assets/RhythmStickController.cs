using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmStickController : MonoBehaviour
{
    public float rhythm = 1f;
    SpriteRenderer sr;
    bool turned = false;
    // Update is called once per frame

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        RookMovement[] rooks = GameObject.FindObjectsOfType<RookMovement>();
        HorseMovement[] horses = GameObject.FindObjectsOfType<HorseMovement>();
        PawnMovement[] pawns = GameObject.FindObjectsOfType<PawnMovement>();
        BishopMovement[] bishops = GameObject.FindObjectsOfType<BishopMovement>();
        TrainLeftController[] trainLeft = GameObject.FindObjectsOfType<TrainLeftController>();
        TrainRightController[] trainRight = GameObject.FindObjectsOfType<TrainRightController>();
        TrainBotController[] trainBot = GameObject.FindObjectsOfType<TrainBotController>();
        TrainTopController[] trainTop = GameObject.FindObjectsOfType<TrainTopController>();
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-2.85f, 4f), rhythm * Time.deltaTime);
        if (transform.position.y <= 4.6f && transform.position.y > 4f)
        {
            PlayerController.plrInstance.canMove = true;
            if ((transform.position.y <= 4.1f && transform.position.y > 4f))
            {
                if (turned == false)
                {
                    foreach (TrainLeftController train in trainLeft)
                    {
                        train.canMove = true;
                    }
                    foreach (TrainRightController train in trainRight)
                    {
                        train.canMove = true;
                    }
                    foreach (TrainBotController train in trainBot)
                    {
                        train.canMove = true;
                    }
                    foreach (TrainTopController train in trainTop)
                    {
                        train.canMove = true;
                    }
                    foreach (RookMovement rook in rooks)
                    {
                        rook.canMove = true;
                    }
                    foreach (HorseMovement horse in horses)
                    {
                        horse.canMove = true;
                    }
                    foreach (PawnMovement pawn in pawns)
                    {
                        pawn.canMove = true;
                    }
                    foreach (BishopMovement bishop in bishops)
                    {
                        bishop.canMove = true;
                    }
                }
                turned = true;
            }
        }        
        else if (transform.position.y == 4f)
        {
            turned = false;
            foreach (TrainLeftController train in trainLeft)
            {
                if(train.canMove != false)
                {
                    train.canMove = false;
                }
            }
            foreach (TrainRightController train in trainRight)
            {
                if(train.canMove != false)
                {
                    train.canMove = false;
                }
            }
            foreach (TrainBotController train in trainBot)
            {
                if(train.canMove != false)
                {
                    train.canMove = false;
                }
            }
            foreach (TrainTopController train in trainTop)
            {
                if(train.canMove != false)
                {
                    train.canMove = false;
                }
            }
            foreach (RookMovement rook in rooks)
            {
                if(rook.canMove != false)
                {
                    rook.canMove = false;
                }
            }
            foreach (HorseMovement horse in horses)
            {
                if(horse.canMove != false)
                {
                    horse.canMove = false;
                }
            }
            foreach (PawnMovement pawn in pawns)
            {
                if(pawn.canMove != false)
                {
                    pawn.canMove = false;
                }
            }
            foreach (BishopMovement bishop in bishops)
            {
                if(bishop.canMove != false)
                {
                    bishop.canMove = false;
                }
            }
            StartCoroutine(ITurnOffPlr());
        }
    }

    IEnumerator ITurnOffPlr()
    {
        sr.enabled = false;
        yield return new WaitForSecondsRealtime(.2f);
        PlayerController.plrInstance.canMove = false;
        PlayerController.plrInstance.missedTiming = false;
        Destroy(gameObject);
    }
}
