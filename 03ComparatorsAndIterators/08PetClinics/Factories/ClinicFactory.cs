using System;
using System.Collections.Generic;
using System.Text;


   public class ClinicFactory
    {
    public Clinic CreateClinic(string name, int roomsNumber)
    {
        return new Clinic(name, roomsNumber);
    }
    }

