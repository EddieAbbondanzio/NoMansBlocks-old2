using NoMansBlocks.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A monobehaviour wrapper to the No Mans Block
/// game engine.
/// </summary>
public class EngineBehaviour : MonoBehaviour {
    #region Properties
    /// <summary>
    /// The engine instance.
    /// </summary>
    public Engine Engine { get; private set; }
    #endregion

    #region Mono Events
    /// <summary>
    /// Prepares the engine for use.
    /// </summary>
    private void Awake() {
        Engine = new ClientEngine();
        Engine.Init();
    }

    /// <summary>
    /// Called after everything has been initialized.
    /// </summary>
    private void Start () {
        Engine.Start();
	}
	
    /// <summary>
    /// Called every tick of the game.
    /// </summary>
	private void Update () {
        Engine.Update();
	}

    /// <summary>
    /// Called when the engine is shutting down.
    /// </summary>
    private void OnApplicationQuit() {
        Engine.End();
    }
    #endregion
}
