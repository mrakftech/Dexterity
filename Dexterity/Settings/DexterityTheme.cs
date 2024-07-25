using MudBlazor;
using Button = MudBlazor.Button;

namespace Dexterity.Settings
{
    public static class DexterityTheme
    {
        private static readonly Typography DefaultTypography = new()
        {
            Default = new Default()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = ".01071em"
            },
            H1 = new H1()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "6rem",
                FontWeight = 300,
                LineHeight = 1.167,
                LetterSpacing = "-.01562em"
            },
            H2 = new H2()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "3.75rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.00833em"
            },
            H3 = new H3()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "3rem",
                FontWeight = 400,
                LineHeight = 1.167,
                LetterSpacing = "0"
            },
            H4 = new H4()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "2.125rem",
                FontWeight = 400,
                LineHeight = 1.235,
                LetterSpacing = ".00735em"
            },
            H5 = new H5()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "1.5rem",
                FontWeight = 400,
                LineHeight = 1.334,
                LetterSpacing = "0"
            },
            H6 = new H6()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "1.25rem",
                FontWeight = 400,
                LineHeight = 1.6,
                LetterSpacing = ".0075em"
            },
            Button = new Button()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = ".875rem",
                FontWeight = 500,
                LineHeight = 1.75,
                LetterSpacing = ".02857em"
            },
            Body1 = new Body1()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = ".00938em",
            },
            Body2 = new Body2()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = ".01071em"
            },
            Caption = new Caption()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = ".75rem",
                FontWeight = 400,
                LineHeight = 1.66,
                LetterSpacing = ".03333em"
            },
            Subtitle2 = new Subtitle2()
            {
                FontFamily = new[] {"Open Sans", "Helvetica", "Arial", "sans-serif"},
                FontSize = ".875rem",
                FontWeight = 500,
                LineHeight = 1.57,
                LetterSpacing = ".00714em"
            },
        };

        private static readonly LayoutProperties DefaultLayoutProperties = new()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "1000px",
            DefaultBorderRadius = "8px",
        };

        public static readonly MudTheme DefaultTheme = new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#0077B5",
                TextPrimary = "#0077B5",
                PrimaryContrastText = "#FFF",
                Secondary = "#b94e48",
                Dark = "#000",
                Surface = "#D3D3D3",
                Info = "#FFF",
                HoverOpacity = 0.6,
                TableLines = "#0077B5",
                LinesInputs = "#0077B5",
                LinesDefault = "#0077B5",
                
                
                
            },
            Typography = DefaultTypography,
            LayoutProperties = DefaultLayoutProperties
        };
    }
}