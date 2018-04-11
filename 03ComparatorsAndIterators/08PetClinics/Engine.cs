using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class Engine
    {
    private List<Clinic> clinics = new List<Clinic>();
    private List<Pet> pets = new List<Pet>();
    private ClinicFactory clinicFactory = new ClinicFactory();
    private PetFactory petFactory = new PetFactory();

    public void Run()
    {
        int lineNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < lineNumber; i++)
        {
            string[] input = Console.ReadLine().Split();

            string command = input[0];

            string[] args = input.Skip(1).ToArray();

            try
            {
                ReadOneLine(command, args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private void ReadOneLine(string command, string[] args)
    {
        switch (command)
        {
            case "Create":
                {
                    string kindOfCreating = args[0];
                    if (kindOfCreating == "Clinic")
                    {
                        string clinicName = args[1];
                        int roomsNumber = int.Parse(args[2]);

                        this.clinics.Add(clinicFactory.CreateClinic(clinicName, roomsNumber));
                    }
                    else if (kindOfCreating == "Pet")
                    {
                        string name = args[1];
                        int age = int.Parse(args[2]);
                        string kind = args[3];
                        this.pets.Add(petFactory.CreatePet(name, age, kind));
                    }
                    break;
                }
            case "Add":
                {
                    string petName = args[0];
                    string clinicName = args[1];

                    Pet pet = this.pets.FirstOrDefault(p => p.Name == petName);

                    if (pet == null)
                    {
                        throw new ArgumentException("Invalid Operation!");
                    }

                    Clinic clinic = this.clinics.First(c => c.Name == clinicName);

                    bool succsess = clinic.AddPet(pet);

                    if (succsess)
                    {
                        this.pets.Remove(pet);
                    }

                    Console.WriteLine(succsess);

                    break;
                }
            case "Release":
                {
                    string clinicName = args[0];

                    Clinic clinic = this.clinics.First(c => c.Name == clinicName);

                    bool success = clinic.ReleasePet();

                    Console.WriteLine(success);

                    break;
                }
            case "HasEmptyRooms":
                {
                    string clinicName = args[0];

                    Clinic clinic = this.clinics.First(c => c.Name == clinicName);

                    Console.WriteLine(clinic.HasEmptyRooms());

                    break;
                }
            case "Print":
                {
                    string clinicName = args[0];

                    Clinic clinic = this.clinics.First(c => c.Name == clinicName);

                    if (args.Length == 1)
                    {
                        Console.WriteLine(clinic.PrintAllRooms());
                    }
                    else if (args.Length == 2)
                    {
                        int roomNumber = int.Parse(args[1]);

                        Console.WriteLine(clinic.PrintOneRoom(roomNumber));
                    }
                    break;
                }
            default:
                break;
        }
    }
}

