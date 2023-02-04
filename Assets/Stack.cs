using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack
{
	Node head;
	int length = 0;
		
	public void Insert(Vector2Int data)
	{
		head = new Node(data, head);
		length = length + 1;
	}

	public Vector2Int Pop()
	{
		Vector2Int returned = head.val;
		head = head.next;
		length = length - 1;
		return returned;
	}

	public bool NotEmpty() 
	{
		if(length == 0) {
			return false;
		} else {
			return true;
		}
	}

	Vector2Int Top() {
		return head.val;
	}
}