using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class Clinic:IComparable<Clinic>
    {

    public Clinic(string name, int roomsNumber)
    {
        this.Name = name;
        this.RoomsNumber = roomsNumber;
        this.Rooms = new Room[roomsNumber];
        CreateEmptyRooms(roomsNumber);
    }
 
    private string name;

    public string Name
    {
        get { return name; }
      private  set { name = value; }
    }

    private int roomsNumber;

    public int RoomsNumber
    {
        get { return roomsNumber; }
     private   set
        {
            if (value%2==0 || value<1||value>101)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            roomsNumber = value;
        }
    }

    private Room[] rooms;
    
    public Room[] Rooms
    {
        get { return rooms; }
      private  set { rooms = value; }
    }

    public int CompareTo(Clinic other)
    {
        return this.Name.CompareTo(other.Name);
    }
    private void CreateEmptyRooms(int roomsNumber)
    {
        for (int i = 0; i < roomsNumber; i++)
        {
            this.Rooms[i] = new Room();
        }
    }

    public bool AddPet(Pet pet)
    {
        int middleIndex = this.roomsNumber / 2;

        bool succsess = false;

        if (this.roomsNumber==1)
        {
            Room room = this.Rooms[0];

            if (!room.HasPet)
            {
                room.AddPet(pet);
                succsess = true;
                return succsess;
            }
            else
            {
                return succsess;
            }
        }
        for (int i = 0; i <= this.roomsNumber / 2; i++)
        {
            Room firstRoom = this.Rooms[middleIndex - i];
            Room secondRoom = this.Rooms[middleIndex + i];

            if (!firstRoom.HasPet)
            {
                firstRoom.AddPet(pet);
                succsess = true;
                break;
            }
            if (!secondRoom.HasPet)
            {
                secondRoom.AddPet(pet);
                succsess = true;
                break;
            }
        }

        return succsess;
    }

    internal bool ReleasePet()
    {
        int middleIndex = this.roomsNumber / 2;

        bool succsess = false;

        //if (this.roomsNumber == 1)
        //{
        //    Room room = this.Rooms[0];

        //    if (room.HasPet)
        //    {
        //        room.ReleasePet();
        //        succsess = true;
        //        return succsess;
        //    }
        //}
        for (int i = middleIndex; i < this.roomsNumber; i++)
        {
            Room room = this.Rooms[i];

            if (room.HasPet)
            {
                room.ReleasePet();
                succsess = true;
                break;
            }         
        }
        if (!succsess)
        {
            for (int i = 0; i < middleIndex; i++)
            {
                Room room = this.Rooms[i];

                if (room.HasPet)
                {
                    room.ReleasePet();
                    succsess = true;
                    break;
                }
            }
        }

        return succsess;
    }

    internal bool HasEmptyRooms()
    {
        bool result = false;

        if (this.Rooms.Any(r=>!r.HasPet))
        {
            result = true;
        }

        return result;
    }

    public string PrintAllRooms()
    {
        StringBuilder builder = new StringBuilder();

        foreach (var room in this.Rooms)
        {
            if (room.HasPet)
            {
                builder.AppendLine(room.Pet.ToString());
            }
            else
            {
                builder.AppendLine("Room empty");
            }
        }

        return builder.ToString().TrimEnd('\n');
    }

    public string PrintOneRoom(int roomNumber)
    {
        Room room = this.Rooms[roomNumber-1];

        if (room.HasPet)
        {
            return room.Pet.ToString();
        }
        else
        {
            return "Room empty";
        }
    }
}

