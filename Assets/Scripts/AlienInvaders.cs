using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienInvaders : MonoBehaviour {

    public GameObject largeInvader, mediumInvader, smallInvader, ufo;
    public int rows, cols;
    public float xPad, yPad;
    public Vector3 startPos;

    public float baseSpeed, speedMultiplier, currSpeed;
    public float moveDownDist;
    private Vector3 direction;
    private GameObject[,] invadersGrid;

    private float ufoTimer, ufoInterval;
    public Vector3 ufoStartPos;
    private bool hasChangedDirection;
    public int wave;
    public float gameOverY;

    public TMP_Text waveClearedText;
    public float waveClearedTextTimer, waveClearedTextDuration;
    // Start is called before the first frame update
    void Start() {
        wave = 1;

        rows = 5;
        cols = 11;
        xPad = 2.0f;
        yPad = 2.0f;
        startPos = new Vector3(-14.0f, 7.0f, 0);

        baseSpeed = 1.5f;
        speedMultiplier = 0.05f;
        currSpeed = baseSpeed;

        moveDownDist = 0.5f;
        direction = Vector3.right;

        invadersGrid = new GameObject[rows, cols];

        SpawnInvaders();
        ResetUFOTimer();
        ufoStartPos = new Vector3(-20.0f, 18.0f, 0);

        hasChangedDirection = false;
        gameOverY = 1.0f;

        waveClearedText.gameObject.SetActive(false);
        waveClearedTextDuration = 2.0f;
        waveClearedTextTimer = waveClearedTextDuration;
    }

    // Update is called once per frame
    void Update() {
        MoveInvaders();
        UpdateCanShootStatus();
        SpawnUFO();
        UpdateSpeed();
        SpawnNextWave();
        GameOver();
    }

    void SpawnInvaders() {
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                Vector3 spawnPos = startPos + new Vector3(col * xPad, row * yPad, 0);
                GameObject invader = null;

                if (row < 2) {
                    // First two bottom rows are the large invaders
                    invader = largeInvader;
                    spawnPos.z += 0.35f;
                } else if (row < 4) {
                    // Middle two rows are the medium invaders
                    invader = mediumInvader;
                } else if (row == 4) {
                    // Top row are the small invaders
                    invader = smallInvader;
                }

                // Spawn the invader
                if (invader != null) {
                    GameObject spawnedInvader = Instantiate(invader, spawnPos, Quaternion.identity);
                    invadersGrid[row, col] = spawnedInvader;
                }
            }
        }
    }

    void MoveInvaders() {
        Vector3 moveStep = direction * currSpeed * Time.deltaTime;

        // Move all invaders
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (invadersGrid[row, col] != null) {
                    invadersGrid[row, col].transform.position += moveStep;
                }
            }
        }

        // Check for collisions with screen edges
        bool hitEdge = false;
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (invadersGrid[row, col] != null) {
                    Vector3 currPos = invadersGrid[row, col].transform.position;
                    if (currPos.x <= -16.0f || currPos.x >= 16.0f) {
                        hitEdge = true;
                        break;
                    }
                }
            }
            if (hitEdge) break;
        }

        // If the invaders hits the screen edge, change direction and move down
        if (hitEdge && !hasChangedDirection) {
            Debug.Log("Invaders Changing Direction");
            direction *= -1;
            hasChangedDirection = true;
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    if (invadersGrid[row, col] != null) {
                        invadersGrid[row, col].transform.position += new Vector3(0, -moveDownDist, 0);
                    }
                }
            }
        }

        // reset hasChangedDirection when all invaders are away from the edge
        if (!hitEdge) {
            hasChangedDirection = false;
        }
    }

    void UpdateCanShootStatus() {
        // Reset canShoot for all invaders
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (invadersGrid[row, col] != null) {
                    if (row < 2) {
                        // First two bottom rows are the large invaders
                        LargeAlienInvader invaderScript = invadersGrid[row, col].GetComponent<LargeAlienInvader>();
                        invaderScript.canShoot = false;
                    } else if (row < 4) {
                        // Middle two rows are the medium invaders
                        MediumAlienInvader invaderScript = invadersGrid[row, col].GetComponent<MediumAlienInvader>();
                        invaderScript.canShoot = false;
                    } else if (row == 4) {
                        // Top row are the small invaders
                        SmallAlienInvader invaderScript = invadersGrid[row, col].GetComponent<SmallAlienInvader>();
                        invaderScript.canShoot = false;
                    }
                }
            }
        }

        // Set canShoot for the bottom-most invader in each column
        for (int col = 0; col < cols; col++) {
            for (int row = 0; row < rows; row++) {
                if (invadersGrid[row, col] != null) {
                    if (row < 2) {
                        // First two bottom rows are the large invaders
                        LargeAlienInvader invaderScript = invadersGrid[row, col].GetComponent<LargeAlienInvader>();
                        invaderScript.canShoot = true;
                    } else if (row < 4) {
                        // Middle two rows are the medium invaders
                        MediumAlienInvader invaderScript = invadersGrid[row, col].GetComponent<MediumAlienInvader>();
                        invaderScript.canShoot = true;
                    } else if (row == 4) {
                        // Top row are the small invaders
                        SmallAlienInvader invaderScript = invadersGrid[row, col].GetComponent<SmallAlienInvader>();
                        invaderScript.canShoot = true;
                    }
                    break; 
                }
            }
        }
    }
    void ResetUFOTimer() {
        // Set a random interval between 15 to 30 seconds
        ufoInterval = Random.Range(15.0f, 30.0f);
        ufoTimer = ufoInterval;
    }

    void SpawnUFO() {
        ufoTimer -= Time.deltaTime;
        if (ufoTimer <= 0) {
            Instantiate(ufo, ufoStartPos, Quaternion.identity);
            ResetUFOTimer();
            ufoTimer += 10;
        }
    }

    public int CountInvaders() {
        int count = 0;
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (invadersGrid[row, col] != null) {
                    count++;
                }
            }
        }
        return count;
    }

    void UpdateSpeed() {
        int totalInvaders = rows * cols;
        int remainingInvaders = CountInvaders();
        float speedFactor = Mathf.Exp((totalInvaders - remainingInvaders) * speedMultiplier);
        currSpeed = baseSpeed * speedFactor;
    }

    void SpawnNextWave() {
        if (CountInvaders() == 0) {
            // Show Wave Cleared text
            StartCoroutine(DisplayWaveClearedText());
            // Wait for Wave Cleared text to disapper before spawning next wave
            waveClearedTextTimer -= Time.deltaTime;
            if (waveClearedTextTimer <= 0) {
                wave++;
                SpawnInvaders();
                waveClearedTextTimer = waveClearedTextDuration;
            }
        }
    }

    IEnumerator DisplayWaveClearedText() {
        // Show and set the text
        waveClearedText.gameObject.SetActive(true);
        waveClearedText.text = $"Wave {wave} Clear";
        // Show the text for a certain amount of time
        yield return new WaitForSeconds(waveClearedTextDuration);
        // Remove the text from the screen
        waveClearedText.gameObject.SetActive(false);
    }

    void GameOver() {
        for (int col = 0; col < cols; col++) {
            for (int row = 0; row < rows; row++) {
                if (invadersGrid[row, col] != null) {
                    // if the invader reaches a certain y position, end the game by setting lives to 0
                    if (invadersGrid[row, col].transform.position.y <= gameOverY) {
                        GameObject obj = GameObject.Find("GlobalObject");
                        Global g = obj.GetComponent<Global>();
                        g.lives = 0;
                    }
                }
            }
        }
    }
}
