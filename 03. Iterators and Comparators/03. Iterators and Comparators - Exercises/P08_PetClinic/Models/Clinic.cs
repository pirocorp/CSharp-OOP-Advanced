namespace P08_PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic
    {
        private readonly Pet[] rooms;
        private readonly int[] roomsAddSearchPattern;

        public Clinic(int numberOfRooms)
        {
            if (numberOfRooms % 2 == 0)
            {
                throw new ArgumentException("Cannot create clinic with even number of rooms.");
            }

            this.rooms = new Pet[numberOfRooms];
            this.roomsAddSearchPattern = this.GetAddSearchPattern();
        }

        public bool AddPet(Pet pet)
        {
            if (pet == null)
            {
                throw new NullReferenceException();
            }

            for (var i = 0; i < this.roomsAddSearchPattern.Length; i++)
            {
                var index = this.roomsAddSearchPattern[i];

                if (this.rooms[index] == null)
                {
                    this.rooms[index] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            var midpoint = this.rooms.Length / 2;

            for (var i = midpoint; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            for (var i = 0; i < midpoint; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public string PrintRoom(int roomIndex)
        {
            if (this.rooms[roomIndex] == null)
            {
                return $"Room empty";
            }

            return this.rooms[roomIndex].ToString();
        }

        public string Print()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < this.rooms.Length; i++)
            {
                sb.AppendLine(this.PrintRoom(i));
            }

            return sb.ToString();
        }

        public bool HasEmptyRooms()
        {
            for (var index = 0; index < this.rooms.Length; index++)
            {
                var t = this.rooms[index];

                if (t == null)
                {
                    return true;
                }
            }

            return false;
        }

        private int[] GetAddSearchPattern()
        {
            var midpoint = this.rooms.Length / 2;

            var result = new List<int> { midpoint };

            for (var i = 1; i <= midpoint; i++)
            {
                result.Add(midpoint - i);
                result.Add(midpoint + i);
            }

            return result.ToArray();
        }
    }
}