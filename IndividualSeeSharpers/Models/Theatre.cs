﻿namespace IndividualSeeSharpers.Models;

public class Theatre
{
    public int Id { get; set; }

    public int Number { get; set; }

    public ICollection<Row>? AmountOfRows { get; set; }
}