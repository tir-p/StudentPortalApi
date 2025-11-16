using Microsoft.EntityFrameworkCore;
using StudentPortalApi.Models;

namespace StudentPortalApi.Extensions
{
    /// <summary>
    /// Extension methods for reusable query operations.
    /// Follows DRY principle by centralizing common LINQ operations.
    /// </summary>
    public static class QueryExtensions
    {
        /// <summary>
        /// Includes all related entities for a Student query.
        /// This extension method reduces code duplication when querying students with related data.
        /// </summary>
        public static IQueryable<Student> IncludeRelatedEntities(this IQueryable<Student> query)
        {
            return query
                .Include(s => s.Address)
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Course);
        }

        /// <summary>
        /// Filters students by year.
        /// Example of a reusable filtering extension method.
        /// </summary>
        public static IQueryable<Student> FilterByYear(this IQueryable<Student> query, int year)
        {
            return query.Where(s => s.Year == year);
        }

        /// <summary>
        /// Filters students by GPA range.
        /// Example of a reusable filtering extension method.
        /// </summary>
        public static IQueryable<Student> FilterByGPARange(this IQueryable<Student> query, double minGPA, double maxGPA)
        {
            return query.Where(s => s.GPA >= minGPA && s.GPA <= maxGPA);
        }
    }
}

