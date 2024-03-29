﻿using System.Numerics;
using IndividualSeeSharpers.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using IndividualSeeSharpers.Data;
using IndividualSeeSharpers.Services.SeatService.Exceptions;
using IndividualSeeSharpers.Services.SeatService.Extensions;
using IndiviualSeeSharpers.Services.SeatService;


namespace IndividualSeeSharpers.Services.SeatService;

public class SeatService
{
    private readonly SeeSharpersContext _context;
    private readonly Show _show;
    private readonly int _seatsPerRow;
    private readonly int _rows;

    private readonly HashSet<Seat> _seats = new();

    public SeatService(Show show, SeeSharpersContext context)
    {
        _show = show;
        _seatsPerRow = show.Theatre.AmountOfSeats/show.Theatre.AmountOfRows;
        _rows = show.Theatre.AmountOfRows;
        _context = context;

        GenerateSeats();
    }

    /**
     * Get the seat based on the x and y value from a Vector2.
     */
    public Seat? GetSeat(Vector2 position) => GetSeat((int) position.X, (int) position.Y);

    /**
     * Get the seat based on the x and y value.
     */
    public Seat? GetSeat(int x, int y)
    {
        return _seats.First(s => (int) s.Position.X == x && (int) s.Position.Y == y);
    }

    /**
     * Get a list of seats based on more positions (Vector2)
     */
    public List<Seat> GetSeats(List<Vector2> positions)
    {
        List<Seat> seats = new();
        positions.ForEach(pos =>
        {
            var foundedSeat = GetSeat(pos);

            if (foundedSeat != null)
            {
                seats.Add(foundedSeat);
            }
        });

        return seats;
    }

    /**
     * Set The next seat that is available occupied, and return the seats that are set to occupied.
     * <param name="amount">amount of seats that you want to occupy.</param>
     */
    public List<Seat> OccupyNextSeat(int amount)
    {
        List<Seat> newOccupiedSeats = new();

        if (GetFreeSeatCount() < amount)
            throw new NoFreeSeatException();

        for (int i = 0; i < amount; i++)
        {
            var seat = _seats.NextSeat();

            if (seat != null && SaveOccupiedSeat(seat))
            {
                newOccupiedSeats.Add(seat);
            }
        }

        return newOccupiedSeats;
    }

    public Seat? OccupySeat(Vector2 position)
    {
        var seat = GetSeat(position);

        if (seat == null)
            return null;

        if (seat.Occupied)
            return null;

        return SaveOccupiedSeat(seat)
            ? seat
            : null;
    }

    /**
     * Get amount of not occupied seats.
     */
    public int GetFreeSeatCount()
    {
        return _seats.Count(s => !s.Occupied);
    }

    /**
     * Get a list of ordered seats per row.
     */
    public List<List<Seat>> GetSeatsOrderedByNumber()
    {
        var listOfRows = new List<List<Seat>>();

        for (int i = 0; i < _rows; i++)
        {
            listOfRows.Add(_seats.Where(s => (int) s.Position.Y == i).OrderBy(s => s.Number).ToList());
        }

        return listOfRows;
    }

    private void GenerateSeats()
    {
        var radius = (int) Math.Floor(_seatsPerRow / 2.0);
        var evenRows = _seatsPerRow % 2 == 0;

        for (int row = 0; row < _rows; row++)
        {
            Add(0, row);
            for (int i = 1; i <= radius; i++)
            {
                if (!evenRows || (evenRows && i != radius)) Add(i, row);
                Add(-i, row);
            }
        }

        AllocateSeatNumbers();
        SetOccupiedSeats();

        void Add(int x, int y) => _seats.Add(new Seat(new Vector2(x, y)));
    }

    private void AllocateSeatNumbers()
    {
        for (int y = 0; y < _rows; y++)
        {
            var xMin = _seats.Where(s => (int) s.Position.Y == y).Min(s => (int) s.Position.X);
            var xMax = _seats.Where(s => (int) s.Position.Y == y).Max(s => (int) s.Position.X);
            var numberIterator = 1;

            for (int x = xMin; x <= xMax; x++)
            {
                var seat = GetSeat(x, y);
                if (seat == null) continue;

                seat.Number = numberIterator++;
            }
        }
    }

    private void SetOccupiedSeats()
    {
        GetViewingSeats().ForEach(vs =>
        {
            var seat = GetSeat(vs.X, vs.Y);

            if (seat != null)
            {
                seat.Occupied = true;
            }
        });
    }

    private List<ShowSeat> GetViewingSeats()
    {
        return _context.ShowSeats.Where(s => s.Show.Id == _show.Id).ToList();
    }

    private bool SaveOccupiedSeat(Seat seat)
    {
        var listedSeat = GetSeat(seat.Position);

        if (listedSeat == null) return false;

        var viewingSeat = new ShowSeat
        {
            Show = _show,
            X = (int) seat.Position.X,
            Y = (int) seat.Position.Y
        };

        listedSeat.Occupied = true;

        try
        {
            _context.ShowSeats.Add(viewingSeat);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}