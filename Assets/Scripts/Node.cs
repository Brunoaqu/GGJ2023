using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public Vector2Int val;
	public Node next;

	public Node(Vector2Int value, Node head) {
		val = value;
		next = head;
	}
}