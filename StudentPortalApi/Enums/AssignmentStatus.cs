namespace StudentPortalApi.Enums
{
    /// <summary>
    /// Tracks the lifecycle of an assignment from creation through evaluation,
    /// allowing the UI to surface workflow state to students.
    /// </summary>
    public enum AssignmentStatus
    {
        Pending,
        Submitted,
        Graded,
        Late,
        Missing
    }
}
