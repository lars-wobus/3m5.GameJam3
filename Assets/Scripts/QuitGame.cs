﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	public void QuitApplication () {
        
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
