﻿using IndividualSeeSharpers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IndividualSeeSharpers.ViewModels;

public class HomeIndexViewModel
{
    public List<Movie>? Movies { get; set; }
    public List<Show>? Shows { get; set; }
}