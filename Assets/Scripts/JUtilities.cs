using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUtilities {
	private const float m_error = 0.1f;
	private const float m_minCheckDistance = 10;
	private const float m_maxCheckDistance = 100;
	public static bool GetCollider_one_forceDist(out RaycastHit hit, Vector3 origin_trans, Vector3 direct, float need_dist)
	{
		float check_start = -m_error;
#if UNITY_EDITOR
		Debug.DrawLine(origin_trans + (direct * check_start), origin_trans + direct * (check_start + need_dist), Color.red);
#endif
		return Physics.Raycast(origin_trans + (direct * check_start), direct, out hit, need_dist);
	}

	public static bool GetCollider_one(out RaycastHit hit, Vector3 origin_trans, Vector3 direct, GameObject obj = null)
	{
		float check_dist = m_minCheckDistance;
		float check_start = -m_error;
		while (check_dist < m_maxCheckDistance)
		{
#if UNITY_EDITOR
			Debug.DrawLine(origin_trans + (direct * check_start), origin_trans + direct * (check_start + check_dist), Color.red);
#endif
			if (Physics.Raycast(origin_trans + (direct * check_start), direct, out hit, check_dist) && (!obj || hit.transform.gameObject == obj))
			{
				return true;
			}
			else
			{
				check_dist *= 2;
			}
		}
		hit = default(RaycastHit);
		return false;
	}

	public static bool GetCollider_one_reverse(out RaycastHit hit, Vector3 origin_trans, Vector3 direct, GameObject obj = null)
	{
		float check_dist = m_minCheckDistance;
		float check_start = -m_error;
		while (check_dist < m_maxCheckDistance)
		{
#if UNITY_EDITOR
			Debug.DrawLine(origin_trans + (direct * check_start), origin_trans + direct * (check_start + check_dist), Color.red);
#endif
			Debug.Log("Find 2:" + direct + "," + check_start + "," + check_dist);
			if (Physics.Raycast(origin_trans + direct * (check_start+check_dist), -direct, out hit, check_dist) && (!obj || hit.transform.gameObject == obj))
			{
				Debug.Log("Find!!!");
				return true;
			}
			else
			{
				check_dist *= 2;
			}
		}
		hit = default(RaycastHit);
		return false;
	}

	public static bool GetCollider_twoSide(out RaycastHit hit_up, out RaycastHit hit_down, Vector3 origin_trans, Vector3 direct, GameObject obj = null)
	{
		hit_up = default(RaycastHit);
		hit_down = default(RaycastHit);
		return GetCollider_one(out hit_up, origin_trans, direct, obj) && GetCollider_one_reverse(out hit_down, origin_trans, direct, obj);
	}
}
