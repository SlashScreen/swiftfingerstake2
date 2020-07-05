using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC FIELDS
        [Header("MOVEMENT SETTINGS")]
        public Vector3Int cell;
        public GridLayout grid;
        public Tilemap col_map;
    #endregion

    #region PRIVATE FIELDS

        private Vector3Int dir;
        private float _xAxis;
        private float _yAxis;
        private bool registerMovement = false;
    #endregion
    private void Start() {
        //snaps to grid from editor
        cell = grid.WorldToCell(transform.position);
        change_position();
        //GetComponent(Sprite).textureRectOffset = new Vector2(0.5f,0.5f);
    }

    private void Update() {
        //horizontal axis
        if(Input.GetButtonDown("Horizontal")){
            _xAxis = digitize(Input.GetAxis("Horizontal"));
            registerMovement = true;
        }else if(!Input.GetButtonDown("Horizontal")){
            _xAxis = 0.0f;
        }
        //vertical axis
        if(Input.GetButtonDown("Vertical")){
            _yAxis = digitize(Input.GetAxis("Vertical"));
            registerMovement = true;
        }else if(!Input.GetButtonDown("Vertical")){
            _yAxis = 0.0f;
        }
        //move if there's demand to move
        if (registerMovement){
            move();
        }
    }

    void move(){
        //set direction
        dir = new Vector3Int((int)_xAxis, (int)_yAxis, 0);
        //debug
        Debug.Log(dir.ToString());
        //set position if movement is clear
        if (!col_map.HasTile(cell + ( dir + new Vector3Int(0,-1,0) ) )){ //the -1 is necessary for some reason
            cell += dir; //set direction
            change_position(); //change position
        }
        //reset variables
        dir = new Vector3Int(0,0,0);
        registerMovement = false;
    }

    private int digitize(float axis){ 
        //takes the signal and goes from 0,-1,1
        if (axis < 0.0f){
            return -1;
        }else if(axis > 0.0f){
            return 1;
        }else{
            return 0;
        }
    }

    void change_position(){
        //changes the position and offset
        transform.position = grid.CellToWorld(cell);// + new Vector3(.5f,.5f,0);
    }
}
