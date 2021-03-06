﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Speed.cs" company="RuPC">
//   Copyright 2013 RuPC
// </copyright>
// <summary>
//   Defines the Speed type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StravaCenturion.Units
{
    using System;

    /// <summary>
    /// Represents a speed.
    /// </summary>
    public struct Speed
    {
        /// <summary>
        /// The speed of zero.
        /// </summary>
        public static readonly Speed Zero = new Speed(0.0);

        /// <summary>
        /// The unknown speed.
        /// </summary>
        public static readonly Speed Unknown = new Speed(double.NaN);

        /// <summary>
        /// The speed in meters per second.
        /// </summary>
        private double metresPerSecond;

        /// <summary>
        /// Initializes a new instance of the <see cref="Speed"/> struct.
        /// </summary>
        /// <param name="speedInMetresPerSecond">
        /// The speed in meters per second.
        /// </param>
        public Speed(double speedInMetresPerSecond)
        {
            this.metresPerSecond = speedInMetresPerSecond;
        }

        /// <summary>
        /// Gets or sets the speed in meters per second.
        /// </summary>
        public double MetresPerSecond
        {
            get
            {
                return this.metresPerSecond;
            }

            set
            {
                this.metresPerSecond = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this speed is unknown.
        /// </summary>
        public bool IsUnknown
        {
            get
            {
                return double.IsNaN(this.MetresPerSecond);
            }
        }

        /// <summary>
        /// Gets the speed as kilometers per hour.
        /// </summary>
        public double KilometresPerHour
        {
            get
            {
                return this.MetresPerSecond * 3.6;
            }
        }

        /// <summary>
        /// An implicit conversion to a double.
        /// </summary>
        /// <param name="speed">The speed to convert.</param>
        /// <returns>The number of meters as a double.</returns>
        public static implicit operator double(Speed speed)
        {
            return speed.MetresPerSecond;
        }

        /// <summary>
        /// Adds two speeds together.
        /// </summary>
        /// <param name="a">The first speed.</param>
        /// <param name="b">The second speed.</param>
        /// <returns>The result of the addition.</returns>
        public static Speed operator +(Speed a, Speed b)
        {
            return new Speed(a.MetresPerSecond + b.MetresPerSecond);
        }

        /// <summary>
        /// Subtracts one speed from another.
        /// </summary>
        /// <param name="a">The first speed.</param>
        /// <param name="b">The second speed.</param>
        /// <returns>The result of the subtraction.</returns>
        public static Speed operator -(Speed a, Speed b)
        {
            return new Speed(a.MetresPerSecond - b.MetresPerSecond);
        }

        /// <summary>
        /// Divides a speed by a divisor.
        /// </summary>
        /// <param name="speed">The speed to be divided.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of the division.</returns>
        public static Speed operator /(Speed speed, double divisor)
        {
            return new Speed(speed.MetresPerSecond / divisor);
        }

        /// <summary>
        /// Divides a speed by a divisor.
        /// </summary>
        /// <param name="speed">The speed to be divided.</param>
        /// <param name="timeSpan">The timeSpan.</param>
        /// <returns>The result of the division.</returns>
        public static Acceleration operator /(Speed speed, TimeSpan timeSpan)
        {
            return new Acceleration(speed.MetresPerSecond / timeSpan.TotalSeconds);
        }
    }
}
