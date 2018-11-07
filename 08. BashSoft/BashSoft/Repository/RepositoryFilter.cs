namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using IO;
    using Static_data;

    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilters, int studentsToTake)
        {
            if (wantedFilters == "excellent")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake); 
            }
            else if (wantedFilters == "average")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 3.5 && x < 5, studentsToTake);
            }
            else if (wantedFilters == "poor")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            var counter = 0;
            foreach (var usernameScore in studentsWithMarks)
            {
                if (counter == studentsToTake)
                    break;

                if (givenFilter(usernameScore.Value))
                {
                    OutputWriter.PrintStudent(usernameScore);
                    counter++;
                }
            }
        }
    }
}
