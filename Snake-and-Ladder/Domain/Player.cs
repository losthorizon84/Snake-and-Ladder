﻿namespace Snake_and_Ladder.Domain
{
    /// <summary>
    /// Clase que representa a un jugador
    /// </summary>
    public class Player : IDentifiable
    {
        /// <summary>
        /// Player Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Current position
        /// </summary>
        public int Position { get; set; } = 1;

        public bool IsTheWinner { get; set; } = false;

        public Player(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
