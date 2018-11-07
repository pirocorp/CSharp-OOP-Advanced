﻿namespace BashSoft.Contracts.Models
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }

        void EnrollStudent(IStudent softUniStudent);
    }
}