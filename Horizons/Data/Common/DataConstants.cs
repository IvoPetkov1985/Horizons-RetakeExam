namespace Horizons.Data.Common
{
    public static class DataConstants
    {
        // Destination constants:
        public const int DestinationNameMinLength = 3;
        public const int DestinationNameMaxLength = 80;

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 250;

        public const int ImageUrlMaxLength = 500;

        public const string DateFormat = "dd-MM-yyyy";
        public const string DateFormatRegex = @"^\d{2}-\d{2}-\d{4}$";
        public const string DateFormatErrorMessage = "Invalid date. It should be in format DD-MM-YYYY.";
        public const string PublishedOnRequiredErrorMessage = "Field 'Published On' is required.";
        public const string InputDateInvalid = "The input date is not valid.";

        // Terrain constants:
        public const int TerrainNameMinLength = 3;
        public const int TerrainNameMaxLength = 20;

        public const string TerrainInvalidMessage = "This terrain does not exist.";

        // Names of actions and controllers.
        public const string IndexAction = "Index";
        public const string DestinationContr = "Destination";
    }
}
