namespace Horizons.Common
{
    public static class DataConstants
    {
        // Destination constants:
        public const int DestinationNameMinLength = 3;
        public const int DestinationNameMaxLength = 80;

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 250;

        public const string PublishedOnRequiredErrorMsg = "Field 'Published On' is required.";

        public const string DateFormat = "dd-MM-yyyy";
        public const string DateRegex = @"^\d{2}-\d{2}-\d{4}$";
        public const string DateFormatErrorMessage = "Invalid date format.";
        public const string DateInvalidErrorMessage = "Invalid date. Please check again.";

        // Terrain constants:
        public const int TerrainNameMinLength = 3;
        public const int TerrainNameMaxLength = 20;

        public const string TerrainInvalidErrorMessage = "This terrain type does not exist.";

        // Names of actions and controllers:
        public const string IndexAction = "Index";
        public const string DestinationContr = "Destination";
    }
}
