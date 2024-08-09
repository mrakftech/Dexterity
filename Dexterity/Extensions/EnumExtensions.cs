using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dexterity.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue) => enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .FirstOrDefault()?
                       .GetCustomAttribute<DisplayAttribute>()?
                       .GetName() ?? string.Empty;


        public static Dictionary<T, string> ToDictionary<T>() where T : struct
           => Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(e => e, e => (e as Enum).GetDisplayName());
    }

    
}
