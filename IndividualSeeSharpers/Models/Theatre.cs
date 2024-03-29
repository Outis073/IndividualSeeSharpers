﻿namespace IndividualSeeSharpers.Models;

public class Theatre
{
    public int Id { get; set; }

    public int Number { get; set; }

    public int AmountOfRows { get; set; }

    public int AmountOfSeats { get; set; }

    public ICollection<Show> Shows { get; set; }

}