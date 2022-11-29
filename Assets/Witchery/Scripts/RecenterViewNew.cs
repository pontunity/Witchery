using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class RecenterViewNew : MonoBehaviour
    {
        [SerializeField]
        Transform resetTransform;

        [SerializeField]
        GameObject player;

        [SerializeField] Camera playerHead;
        public float zPosition = 2;

    [ContextMenu("Reset Position")]

    private void Start()
    {
       
    }

    public void ResetPosition()
        {

            var rotationAngleY = resetTransform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
            player.transform.Rotate(0, rotationAngleY, 0);

            var distanceDiff = resetTransform.position - playerHead.transform.position;

            player.transform.position += distanceDiff;

            //Vector3 temp = transform.position;
            //temp.y = zPosition;

            /// player.transform.position = transform.localPosition = temp;

        }



}
