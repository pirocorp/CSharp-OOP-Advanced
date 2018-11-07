namespace BashSoft.Exceptions
{
    using System;

    public class DuplicateEntryInStructureException : Exception
    {
        private const string DUPLICATE_ENTRY = "The {0} already exists in {1}.";
        public DuplicateEntryInStructureException(string entry, string course) : base(string.Format(DUPLICATE_ENTRY, entry, course)) { }
        public DuplicateEntryInStructureException(string message) : base(message) { }
    }
}
