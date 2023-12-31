﻿namespace Contracts;
public interface IRepositoryManager
{
    IMovieRepository Movie { get; }
    IDirectorRepository Director { get; }
    Task SaveAsync();
}
