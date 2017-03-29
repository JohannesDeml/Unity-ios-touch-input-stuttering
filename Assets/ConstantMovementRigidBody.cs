namespace Supyrb
{
	using UnityEngine;
	using System.Collections;

    [RequireComponent(typeof(Rigidbody))]
	public class ConstantMovementRigidBody : MonoBehaviour
	{
		[SerializeField] private Vector3 movementPerSecond;
	    [SerializeField] private Rigidbody rigidBody;
		private Vector3 movementPerUpdate;
		private Vector3 position;
		private Vector3 startPosition;

	    private void Start()
	    {
	        CalculatePerUpdateMovement();
			startPosition = transform.position;
			position = startPosition;
	    }

	    private void FixedUpdate () 
		{
			position += movementPerUpdate;
			rigidBody.MovePosition(position);
        }

	    private void CalculatePerUpdateMovement()
	    {
			movementPerUpdate = movementPerSecond * Time.fixedDeltaTime;
        }

		public void ResetToStartPosition()
		{
			transform.position = startPosition;
			position = startPosition;
		}


		#if UNITY_EDITOR
	    private void Reset()
	    {
	        rigidBody = GetComponent<Rigidbody>();
	        rigidBody.isKinematic = true;
			rigidBody.interpolation = RigidbodyInterpolation.Interpolate;
            rigidBody.useGravity = false;
	        rigidBody.drag = 0f;
	        rigidBody.angularDrag = 0f;
	    }

	    private void OnValidate()
	    {
	        if (Application.isPlaying)
	        {
	            CalculatePerUpdateMovement();
	        }
	    }
		#endif
	}
}