﻿using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.CollisionManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to have a HitBox
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ICollidable
    {
        #region PROPERTIES

        /// <summary>
        /// Used to Return a rectangle object to caller of property
        /// </summary>
        Rectangle HitBox { get; }

        #endregion
    }
}