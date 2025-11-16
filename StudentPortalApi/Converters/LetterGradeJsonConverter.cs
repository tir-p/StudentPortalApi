using System.Text.Json;
using System.Text.Json.Serialization;
using StudentPortalApi.Enums;

namespace StudentPortalApi.Converters
{
    /// <summary>
    /// Custom JSON converter for LetterGrade enum to convert between backend enum values (APlus, AMinus, etc.)
    /// and frontend string values (A+, A-, etc.)
    /// </summary>
    public class LetterGradeJsonConverter : JsonConverter<LetterGrade>
    {
        private static readonly Dictionary<LetterGrade, string> GradeToString = new()
        {
            { LetterGrade.APlus, "A+" },
            { LetterGrade.A, "A" },
            { LetterGrade.AMinus, "A-" },
            { LetterGrade.BPlus, "B+" },
            { LetterGrade.B, "B" },
            { LetterGrade.BMinus, "B-" },
            { LetterGrade.CPlus, "C+" },
            { LetterGrade.C, "C" },
            { LetterGrade.CMinus, "C-" },
            { LetterGrade.D, "D" },
            { LetterGrade.F, "F" }
        };

        private static readonly Dictionary<string, LetterGrade> StringToGrade = GradeToString
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        public override LetterGrade Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            if (stringValue != null && StringToGrade.TryGetValue(stringValue, out var grade))
            {
                return grade;
            }
            throw new JsonException($"Unable to convert \"{stringValue}\" to LetterGrade.");
        }

        public override void Write(Utf8JsonWriter writer, LetterGrade value, JsonSerializerOptions options)
        {
            if (GradeToString.TryGetValue(value, out var stringValue))
            {
                writer.WriteStringValue(stringValue);
            }
            else
            {
                throw new JsonException($"Unable to convert {value} to string.");
            }
        }
    }
}

