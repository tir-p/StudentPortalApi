using StudentPortalApi.DTOs;

public static class GradeUtil
{
    private static readonly Dictionary<string, double> GradeScale = new()
    {
        { "A+", 4.0 }, { "A", 4.0 }, { "A-", 3.7 },
        { "B+", 3.3 }, { "B", 3.0 }, { "B-", 2.7 },
        { "C+", 2.3 }, { "C", 2.0 }, { "C-", 1.7 },
        { "D", 1.0 }, { "F", 0.0 }
    };

    public static double CalculateGPA(IEnumerable<StudentGradeDTO> grades)
    {
        if (grades == null || !grades.Any()) return 0;

        double totalPoints = 0;
        int totalCredits = 0;

        foreach (var grade in grades)
        {
            var letter = grade.LetterGrade.ToUpper().Trim();
            var points = GradeScale.ContainsKey(letter) ? GradeScale[letter] : 0;

            totalPoints += points * grade.Credits;
            totalCredits += grade.Credits;
        }

        return totalCredits > 0 ? Math.Round(totalPoints / totalCredits, 2) : 0;
    }

    public static int CalculateTotalCredits(IEnumerable<StudentGradeDTO> grades)
    {
        return grades?.Sum(g => g.Credits) ?? 0;
    }
}
