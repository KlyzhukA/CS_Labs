namespace CS_Lab2
{
    enum State
    {
        Winner,
        Loser,
        Playing,
        NotInGame,
    }
    class Player
    {
        public string name;
        public State state = State.NotInGame;
        public int location;
        public int distanceTraveled;
        public Player(string name)
        {
            this.name = name;
            this.location = -1;
        }
        public void Move(int steps,int size)
        {
            int steps2 = steps % size;
            if(this.location == -1)
            {
                if (steps2 < 0)
                {
                    this.location = size + steps2;
                }
                else
                {
                    this.location = steps2;
                }
                this.state = State.Playing;
            }
            else
            {
                this.location += steps2;
                this.distanceTraveled += Math.Abs(steps);
                if(this.location < 0)
                {
                    this.location += size;
                }
                else if(this.location > size)
                {
                    this.location -= size;
                }
            }
        }
    }
}
